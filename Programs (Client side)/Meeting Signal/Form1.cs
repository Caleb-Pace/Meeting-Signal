using System;
using System.Windows.Forms;

namespace Meeting_Signal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            } // Show in system tray when minimise
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            // Show
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        public void SetLedColour(System.Drawing.Color newColour) => ledColourPanel.BackColor = newColour;
        public string GetIP() => raspberryPiIPTextBox.Text;
        public void SetIP(string newText) => raspberryPiIPTextBox.Text = newText; // Temp - Debug
    }
}
