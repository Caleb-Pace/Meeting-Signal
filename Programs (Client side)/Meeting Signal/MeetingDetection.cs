using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        };
        private static readonly List<string> meetingPrograms = new List<string>()
        {
            "Zoom Sharing Host" // Zoom
        };

        private static readonly HttpClient httpClient = new HttpClient()
        {
            Timeout = new TimeSpan(0, 0, 2), // 2 Seconds
        };

        // Form objects
        public static TextBox IPTextBox { get; set; }
        public static Panel LedColourPanel { get; set; }


        // Temp - Add ///
        public static async void MeetingListener()
        {
            while (true)
            {
                // Check if in meeting
                if (DetectMeeting())
                {
                    IPTextBox.Text = "true";// Temp - Debug
                    var previousUsingWebcam = false;
                    var previousUsingMicrophone = false;

                    while (true)
                    {
                        var update = false;

                        // Has using webcam state changed
                        var usingWebcam = DetectUsage("webcam");
                        if (usingWebcam != previousUsingWebcam)
                        {
                            previousUsingWebcam = usingWebcam;
                            update = true;
                        } // Update required

                        // Has using microphone state changed
                        var usingMicrophone = DetectUsage("microphone");
                        if (usingMicrophone != previousUsingMicrophone)
                        {
                            previousUsingMicrophone = usingMicrophone;
                            update = true;
                        } // Update required

                        // Update signal
                        if (update) UpdateSignal(true, usingWebcam, usingMicrophone);

                        // Check for state change delay
                        await Task.Delay(TimeSpan.FromSeconds(10));

                        // Check if still in the meeting
                        if (!DetectMeeting()) break; // Exit out of while loop
                    } // Update signal loop
                    UpdateSignal(false, false, false);
                } // Meeting detected!
                else IPTextBox.Text = "false";// Temp - Debug

                // Check for meeting delay
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        }

        // Temp - Add get request
        /// <summary>
        /// Updates signal
        /// </summary>
        /// <remarks>
        /// It does this using a get request
        /// </remarks>
        public static async void UpdateSignal(bool inMeeting, bool usingWebcam, bool usingMicrophone)
        {
            if (usingWebcam)
            {
                if (usingMicrophone) LedColourPanel.BackColor = Color.FromArgb(255, 255, 0, 255); // Webcam and Microphone (Purple)
                else LedColourPanel.BackColor = Color.FromArgb(255, 0, 0, 255);                   // Webcam only (Blue)
            } // Using webcam
            else if (usingMicrophone) LedColourPanel.BackColor = Color.FromArgb(255, 255, 0, 0); // Microphone only (Red)
            else
            {
                if (inMeeting) LedColourPanel.BackColor = Color.FromArgb(255, 255, 174, 66); // In meeting (Yellow/Orange)
                else LedColourPanel.BackColor = Color.FromArgb(255, 0, 0, 0);               // Not in meeting (Off)
            } // Neither

            //// Temp - Add get request
            //var url = $"http://{IPTextBox.Text}/";
            ////var url = $"http://{IPTextBox.Text}/?";
            ////try
            ////{
            //await httpClient.GetAsync(url);
            ////} catch (HttpRequestException)
            ////{
            ////}
        }


        //==/ Detection methods
        /// <summary>
        /// Detects if there is a meeting program running
        /// </summary>
        /// <remarks>
        /// It does this by searching through processes for the <see cref="meetingPrograms"/>
        /// </remarks>
        /// <returns>
        /// <see langword="true"/> if there is a known meeting program running
        /// </returns>
        public static bool DetectMeeting()
        {
            var processes = Process.GetProcesses();

            // Check for meetings
            foreach (var process in processes)
            {
                if (meetingPrograms.Contains(process.ProcessName)) return true; // The known meeting program is running
            }

            return false; // No known meeting programs are running
        }

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
        // Temp - Add colour enum
    }
}
