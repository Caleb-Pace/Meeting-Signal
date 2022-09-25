using BenchmarkDotNet.Attributes;
using System.Diagnostics;

namespace MVP
{
    public class Benchmarking
    {
        // Comparing two process search methods
        [MemoryDiagnoser]
        public class Detection
        {
            public static readonly Dictionary<string, string> find = new()
            {
                { "Income Splitter", "IS" },
            }; // Program that is running
            public static readonly Dictionary<string, string> noFind = new()
            {
                { "Decome Splitter", "DS" },
            }; // Program that isn't running

            [Benchmark]
            public string? SearchAll_Find()
            {
                var processes = Process.GetProcesses();
                foreach (var process in processes)
                {
                    if (find.ContainsKey(process.ProcessName)) return process.ProcessName;
                }

                return null;
            }

            [Benchmark]
            public string? SearchAll_NoFind()
            {
                var processes = Process.GetProcesses();
                foreach (var process in processes)
                {
                    if (noFind.ContainsKey(process.ProcessName)) return process.ProcessName;
                }

                return null;
            }

            [Benchmark]
            public string? TargetSearch_Find()
            {
                foreach (var key in find.Keys)
                {
                    if (Process.GetProcessesByName(key).Length > 0) return key;
                }

                return null;
            }

            [Benchmark]
            public string? TargetSearch_NoFind()
            {
                foreach (var key in noFind.Keys)
                {
                    if (Process.GetProcessesByName(key).Length > 0) return key;
                }

                return null;
            }
        }


        // Comparing property vs method
        [MemoryDiagnoser]
        public class Communication
        {
            public static bool _signal_PT = false; // Send request on property update (value: true)
            public static bool _signal_PF = false; // Send request on property update (value: false)
            public static bool _signal_MT = false; // Update var then send request (value: true)
            public static bool _signal_MF = false; // Update var then send request (value: false)
            public static bool Signal_T
            {
                set
                {
                    if (_signal_PT != value)
                    {
                        _signal_PT = value;

                        SendHttpRequest_T();
                    }
                }
            }
            public static bool Signal_F
            {
                set
                {
                    if (_signal_PF != value)
                    {
                        _signal_PF = value;

                        SendHttpRequest_F();
                    }
                }
            }

            [Benchmark]
            public void Property_T()
            {
                Signal_T = true;
            }

            [Benchmark]
            public void Property_F()
            {
                Signal_F = false;
            }

            [Benchmark]
            public void Method_T()
            {
                _signal_MT = true;
                SendHttpRequest_T();
            }

            [Benchmark]
            public void Method_F()
            {
                _signal_MF = false;
                SendHttpRequest_F();
            }

            public static string SendHttpRequest_T()
            {
                return $"[Debug] Signal << {(true ? "1" : "0")}";
            }

            public static string SendHttpRequest_F()
            {
                return $"[Debug] Signal << {(false ? "1" : "0")}";
            }
        }
    }
}
