using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace MVP
{
    internal class Program
    {
        private static readonly Dictionary<string, string> meetingPrograms = new()
        {
            { "Income Splitter", "IS" },
        }; // Program, Name

        private static readonly int detectionDelay = 1000; // In milliseconds

        // [Communication 2]
        private static readonly HttpClient httpClient = new()
        {
            Timeout = new(0, 0, 100),
        };
        // [Communication 1]
        private static bool Signal
        {
            set
            {
                if (_signal != value)
                {
                    _signal = value;

                    SendHttpRequest();
                    Console.WriteLine($"[Debug] Signal << {(_signal ? "1" : "0")}");
                }
            }
        }
        // [Communication]
        private static bool _signal = false;

        private static string TimeStap => DateTime.Now.ToString("(HH:mm:ss dd/MM/yy) >  ");

        private static string Banner => string.Join("\n", banner);
        private static string[] banner =
        {
            "                                                              ",
            "    ███╗   ███╗███████╗███████╗████████╗██╗███╗   ██╗ ██████╗ ",
            "    ████╗ ████║██╔════╝██╔════╝╚══██╔══╝██║████╗  ██║██╔════╝ ",
            "    ██╔████╔██║█████╗  █████╗     ██║   ██║██╔██╗ ██║██║  ███╗",
            "    ██║╚██╔╝██║██╔══╝  ██╔══╝     ██║   ██║██║╚██╗██║██║   ██║",
            "    ██║ ╚═╝ ██║███████╗███████╗   ██║   ██║██║ ╚████║╚██████╔╝",
            "    ╚═╝     ╚═╝╚══════╝╚══════╝   ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ",
            "                                                              ",
            "            ███████╗██╗ ██████╗ ███╗   ██╗ █████╗ ██╗         ",
            "            ██╔════╝██║██╔════╝ ████╗  ██║██╔══██╗██║         ",
            "            ███████╗██║██║  ███╗██╔██╗ ██║███████║██║         ",
            "            ╚════██║██║██║   ██║██║╚██╗██║██╔══██║██║         ",
            "            ███████║██║╚██████╔╝██║ ╚████║██║  ██║███████╗    ",
            "            ╚══════╝╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝    ",
            "                                                              ",
            "             _____ ______   ___      ___ ________             ",
            "             |\\   _ \\  _   \\|\\  \\    /  /|\\   __  \\           ",
            "             \\ \\  \\\\\\__\\ \\  \\ \\  \\  /  / | \\  \\|\\  \\          ",
            "              \\ \\  \\\\|__| \\  \\ \\  \\/  / / \\ \\   ____\\         ",
            "               \\ \\  \\    \\ \\  \\ \\    / /   \\ \\  \\___|         ",
            "                \\ \\__\\    \\ \\__\\ \\__/ /     \\ \\__\\            ",
            "                 \\|__|     \\|__|\\|__|/       \\|__|            ",
            "                                                              ",
            "\n\n"
        };


        public static void Main()
        {
            BenchmarkRunner.Run<Benchmarking.Communication>();
            BenchmarkRunner.Run<Benchmarking.Detection>();


            //// Print settings
            //var totalWidth = 17 + 5;
            //var spacer = new string(' ', totalWidth);
            //var settings = new string[]
            //{
            //    ">>> [Settings]",
            //    $"{"Meeting Programs:".PadLeft(totalWidth)} [\n{spacer}    \"{string.Join($"\",\n{spacer}    \"", meetingPrograms)}\"\n{spacer} ]",
            //};
            //Console.WriteLine($"{Banner}{string.Join("\n", settings)}\n\n\n>>> [Detection Log]");

            //// Start monitoring
            //while (true)
            //{
            //    // Meeting detection
            //    var program = Detect_1(); // Method 1
            //                              //var program = Detect_2(); // Method 2
            //    var inMeeting = program != null;

            //    if (_signal != inMeeting)
            //    {
            //        // Log detection
            //        if (inMeeting) Console.WriteLine($"{TimeStap}<o>  Detected a {meetingPrograms[program]} meeting");
            //        else Console.WriteLine($"{TimeStap}-=-  No meetings detected!");

            //        // Update signal
            //        Signal = inMeeting; // Method 1
            //        //_signal = inMeeting; // Method 2
            //        //SendSignal(); // Method 2
            //    }

            //    Thread.Sleep(detectionDelay);
            //}
        }


        // [Detection method 1]
        private static string? Detect_1()
        {
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if (meetingPrograms.ContainsKey(process.ProcessName)) return process.ProcessName;
            }

            return null;
        }

        // [Detection method 2]
        private static string? Detect_2()
        {
            foreach (var key in meetingPrograms.Keys)
            {
                if (Process.GetProcessesByName(key).Length > 0) return key;
            }

            return null;
        }

        // [Communication 2]
        private static void SendSignal()
        {
            SendHttpRequest();
            Console.WriteLine($"[Debug] Signal << {(_signal ? "1" : "0")}");
        }

        // TEMP
        private static void SendHttpRequest() => httpClient.Send(new HttpRequestMessage(HttpMethod.Get, $"http://192.168.68.82/?state={(_signal ? "1" : "0")}"));
    }
}