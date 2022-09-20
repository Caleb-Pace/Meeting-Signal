using System;
using System.Windows.Forms;

namespace Meeting_Signal
{
    internal static class Program
    {
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
            MeetingDetection.IPTextBox = form.raspberryPiIPTextBox;
            MeetingDetection.LedColourPanel = form.ledColourPanel;
            MeetingDetection.MeetingListener(); // Start asynchronous meeting listener

            Application.Run(form);
        }
    }
}
