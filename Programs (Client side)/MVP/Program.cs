using System.Diagnostics;

namespace MVP
{
    internal class Program
    {
        private static readonly Dictionary<string, string> meetingPrograms = new()
        {
            { "Income Splitter", "IS" },
        }; // Program, Name

        private static bool _signal = false;
        private static readonly string raspberryPiIP = "192.168.68.82";
        private static readonly HttpClient httpClient = new()
        {
            Timeout = new(0, 0, 2), // 2 Seconds
        };

        private static string TimeStap => DateTime.Now.ToString("(HH:mm:ss dd/MM/yy) >  ");

        private static string Banner => string.Join("\n", banner);
        private static readonly string[] banner =
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
            // Print settings
            var totalWidth = 17 + 5;
            var spacer = new string(' ', totalWidth);
            var settings = new string[]
            {
                ">>> [Settings]",
                $"{"Meeting Programs:".PadLeft(totalWidth)} [\n{spacer}    \"{string.Join($"\",\n{spacer}    \"", meetingPrograms)}\"\n{spacer} ]",
            };
            Console.WriteLine($"{Banner}{string.Join("\n", settings)}\n\n\n>>> [Detection Log]");

            // Start monitoring
            while (true)
            {
                // Meeting detection
                var inMeeting = false;
                var program = "";
                var processes = Process.GetProcesses();
                foreach (var process in processes)
                {
                    if (meetingPrograms.ContainsKey(process.ProcessName))
                    {
                        program = process.ProcessName;
                        inMeeting = true;
                        break;
                    }
                }

                if (_signal != inMeeting)
                {
                    // Log detection
                    if (inMeeting) Console.WriteLine($"{TimeStap}<o>  Detected a {meetingPrograms[program]} meeting");
                    else Console.WriteLine($"{TimeStap}-=-  No meetings detected!");

                    // Update signal
                    _signal = inMeeting;
                    try
                    {
                        httpClient.Send(new HttpRequestMessage(HttpMethod.Get, $"http://{raspberryPiIP}/?state={(_signal ? "1" : "0")}"));
                    }
                    catch (TaskCanceledException)
                    {
                        Console.WriteLine($"{TimeStap} !   Unable to reach {raspberryPiIP} (Timed out!)");
                    }
                    catch (HttpRequestException)
                    {
                        Console.WriteLine($"{TimeStap} !   Unable to reach {raspberryPiIP}");
                    } // Send request to Raspberry Pi
                }

                Thread.Sleep(1000); // In milliseconds
            }
        }
    }
}
