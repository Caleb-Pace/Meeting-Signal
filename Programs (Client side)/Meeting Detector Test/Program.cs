using System.Diagnostics;
using System.Management;

namespace Meeting_Detector_Test
{
#pragma warning disable CA1416 // Validate platform compatibility
    internal class Program
    {
        private static readonly Dictionary<string, string> meetingPrograms = new Dictionary<string, string>()
        {
            { "Zoom", "CptHost" }, // Zoom
        }; // Program name, Meeting indicator (Child process)


        static void Main(string[] args)
        {
            Console.WriteLine($"Programs");
            var detected = DetectMeeting();
            Console.WriteLine($"\n\nDetected zoom? {detected}");
        }

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
                if (meetingPrograms.ContainsKey(process.ProcessName))
                {
                    Console.WriteLine($"  \"{process.ProcessName}\"");

                    var children = GetChildProcesses(process.Id);
                    foreach (var child in children)
                    {
                        Console.WriteLine($"    \"{child.ProcessName}\"");
                        if (meetingPrograms.ContainsValue(child.ProcessName)) return true; // A known meeting program is running
                    }
                }
            }

            return false; // No known meeting programs are running
        }

        /// <summary>
        /// Gets children of a process
        /// </summary>
        /// <remarks>
        /// Adapted from: <see href="https://www.derpturkey.com/c-process-tree/"/>
        /// </remarks>
        /// <param name="parentId"></param>
        /// <returns>
        /// List of child processes
        /// </returns>
        static List<Process> GetChildProcesses(int parentId)
        {
            var childProcesses = new List<Process>();
            var query = $"Select * From Win32_Process Where ParentProcessId = {parentId}";

            // Search for child processes
            using (var searcher = new ManagementObjectSearcher(query))
            {
                foreach (var item in searcher.Get())
                {
                    var data = item.Properties["processid"].Value;
                    if (data != null)
                    {
                        // Get process
                        var child = Process.GetProcessById(Convert.ToInt32(data));

                        // Ensure the process is still alive
                        if (child != null) childProcesses.Add(child);
                    }
                }
            }

            return childProcesses;
        }
    }
#pragma warning restore CA1416 // Validate platform compatibility
}