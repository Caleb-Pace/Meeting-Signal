using Microsoft.Win32;

namespace Additional_Monitoring_Systems
{
#pragma warning disable CA1416 // Validate platform compatibility
    internal class Program
    {
        private static readonly List<string> meetingAppKeys = new()
        {
            "C:#Users#Caleb#AppData#Roaming#Zoom#bin#Zoom.exe",                   // Zoom
            "C:#Users#Caleb#AppData#Local#Microsoft#Teams#current#Teams.exe",     // Teams
            "C:#Program Files#Google#Chrome#Application#chrome.exe",              // Browser
            "C:#Program Files#BraveSoftware#Brave-Browser#Application#brave.exe", // Browser (TEMP - Demo)
        };

        static void Main(string[] args)
        {
            var webcam = DetectUsage("webcam");
            var mic = DetectUsage("microphone");
            Console.WriteLine($"\nUsing webcam: {webcam}\nUsing mic: {mic}");
        }

        private static bool DetectUsage(string device)
        {
            var deviceRegKey = $"Software\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\{device}\\NonPackaged\\";

            foreach (var appKey in meetingAppKeys)
            {
                using (var key = Registry.CurrentUser.OpenSubKey(deviceRegKey + appKey))
                {
                    if (key != null)
                    {
                        var value = key.GetValue("LastUsedTimeStop");
                        if (value != null)
                        {
                            if (long.TryParse(value.ToString(), out long lastUsedTime))
                            {
                                if (lastUsedTime == 0) // It will be 0 if the device is in use
                                {
                                    Console.WriteLine($"Device: \"{device}\" is being used by {appKey}"); // Temp - debug
                                    return true;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
#pragma warning restore CA1416 // Validate platform compatibility
}