using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Meeting_Signal
{
    internal static class Program
    {
        public static Action<Color> SetColour;
        public static Action<string> SetIP;
        public static Func<string> GetIP;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setup and start meeting listener
            var form = new Form1();
            MeetingDetection.Form = form;
            new Thread(new ThreadStart(MeetingDetection.MeetingListener)).Start(); // Start meeting the listener in a different thread

            Application.Run(form);
        }
    }
}
