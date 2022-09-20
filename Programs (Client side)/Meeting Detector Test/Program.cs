using System.Diagnostics;

namespace Meeting_Detector_Test
{
    internal class Program
    {
        private static readonly List<string> meetingPrograms = new List<string>()
        {
            "Zoom Sharing Host" // Zoom
        };


        static void Main(string[] args)
        {
            Console.WriteLine($"Programs");
            var detected = DetectMeeting();
            Console.WriteLine($"\n\nDetected zoom? {detected}");
        }

        // Temp - Add ///
        public static bool DetectMeeting()
        {
            var processes = Process.GetProcesses();

            // Check for meetings
            foreach (var process in processes)
            {
                if (meetingPrograms.Contains(process.ProcessName)) return true; // The known meeting program is running
                Console.WriteLine($"  \"{process.ProcessName}\"");
            }

            return false; // No known meeting programs are running
        }
    }
}