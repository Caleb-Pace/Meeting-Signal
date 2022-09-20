using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
            MeetingDetection.MeetingListener(); // Start asynchronous meeting listener

            Application.Run(form);
        }
    }
}
