using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Meeting_Signal
{
    internal static class MeetingDetection
    {
        private static readonly List<string> meetingAppKeys = new List<string>()
        {
            "C:#Users#Caleb#AppData#Roaming#Zoom#bin#Zoom.exe",                   // Zoom
            "C:#Users#Caleb#AppData#Local#Microsoft#Teams#current#Teams.exe",     // Teams
            "C:#Program Files#Google#Chrome#Application#chrome.exe",              // Browser
            "C:#Program Files#BraveSoftware#Brave-Browser#Application#brave.exe", // Browser (TEMP - Demo)
        }; // Registry keys for meeting apps

        private static readonly HttpClient httpClient = new HttpClient()
        {
            Timeout = new TimeSpan(0, 0, 2), // 2 Seconds
        };

        // Form objects
        public static Form1 Form { get; set; }


        /// <summary>
        /// Manages meeting detection and signalling
        /// </summary>
        public static void MeetingListener()
        {
            Program.SetColour = new Action<Color>(Form.SetLedColour);
            Program.GetIP = new Func<string>(Form.GetIP);

            while (true)
            {
                // Check if in meeting
                if (DetectUsage("microphone"))
                {
                    var previousUsingWebcam = false;
                    var update = true;

                    while (true)
                    {
                        // Has using webcam state changed
                        var usingWebcam = DetectUsage("webcam");
                        if (usingWebcam != previousUsingWebcam)
                        {
                            previousUsingWebcam = usingWebcam;
                            update = true;
                        } // Update required

                        // Update signal
                        if (update)
                        {
                            UpdateSignalAsync(SignalColour.GetColour(true, usingWebcam), usingWebcam).GetAwaiter().GetResult();
                            update = false;
                        }

                        // Check for state change delay
                        Thread.Sleep(TimeSpan.FromSeconds(10));

                        // Check if still in the meeting
                        if (!DetectUsage("microphone")) break; // Exit out of while loop
                    } // Update signal loop

                    UpdateSignalAsync(SignalColour.off, false).GetAwaiter().GetResult();
                } // Meeting detected!

                // Check for meeting delay
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }

        /// <summary>
        /// Updates signal
        /// </summary>
        /// <remarks>
        /// It does this using a get request
        /// </remarks>
        public static async Task UpdateSignalAsync(Color signalColour, bool usingWebcam)
        {
            Program.SetColour.Invoke(signalColour);
            var IP = Program.GetIP.Invoke();
            if (string.IsNullOrWhiteSpace(IP)) return; // Check if IP is blank

            var colour = $"{signalColour.R:x2}{signalColour.G:x2}{signalColour.B:x2}";
            var url = $"http://{IP}/?rgb={colour}&lcd_line_1=/@s/@s/@sMic:/@sUnknown&lcd_line_2=Webcam:/@s{(usingWebcam ? "On" : "Off")}";
            try
            {
                await httpClient.GetAsync(url);
            }
            catch (UriFormatException) { return; } // Invalid URL
            catch (TaskCanceledException) { return; } // Couldn't reach URL
        }


        //==/ Detection
        /// <summary>
        /// Detects if the device is being used by specified meeting programs
        /// </summary>
        /// <remarks>
        /// It detects if the device is in use by querying the Registry
        /// </remarks>
        /// <param name="device">"webcam" or "microphone"</param>
        /// <returns>
        /// <see langword="true"/> if the device is in use
        /// </returns>
        private static bool DetectUsage(string device)
        {
            var deviceRegKey = $"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\{device}\\NonPackaged\\";

            // Search registry for each meeting program
            foreach (var appKey in meetingAppKeys)
            {
                using (var key = Registry.CurrentUser.OpenSubKey(deviceRegKey + appKey))
                {
                    if (key != null)
                    {
                        // Check if one of the programs is currently using the camera
                        var value = key.GetValue("LastUsedTimeStop"); // It will be 0 if the device is in use
                        if (value != null)
                        {
                            if (long.TryParse(value.ToString(), out long lastUsedTime))
                            {
                                if (lastUsedTime == 0) return true; // The Meeting program is currently using the device
                            }
                        }
                    }
                }
            }

            return false; // The device is not in use by a known meeting program
        }


        //==/ Data structure
        /// <summary>
        /// Signal colour reference
        /// </summary>
        private static class SignalColour
        {
            public static readonly Color off = Color.FromArgb(255, 0, 0, 0);                      // Black (Off)
            private static readonly Color onlyMicrophone = Color.FromArgb(255, 255, 0, 0);        // Red
            private static readonly Color both = Color.FromArgb(255, 255, 0, 255);                // Purple


            /// <summary>
            /// Gets signal colour based on detection data
            /// </summary>
            public static Color GetColour(bool inMeeting, bool usingWebcam)
            {
                if (inMeeting)
                {
                    if (usingWebcam) return both;

                    return onlyMicrophone;
                }

                return off;
            }
        }
    }
}
