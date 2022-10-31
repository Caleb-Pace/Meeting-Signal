using System;
using System.Windows.Forms;

namespace Meeting_Signal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClientSize = new System.Drawing.Size(309, 215); // Set correct form size
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

        public void SetLedColour(System.Drawing.Color newColour)
        {
            ledColourPanel.BackColor = newColour;
            connectionLabel.Invoke((MethodInvoker)delegate
            {
                if (newColour == MeetingDetection.SignalColour.waiting) connectionLabel.Text = "Not connected!";
                else connectionLabel.Text = "Connected!";
            }); // Update connection label
        }
        public void SetMeetingStatus(bool inMeeting)
        {
            inMeetingLabel.Invoke((MethodInvoker)delegate
            {
                if (inMeeting) inMeetingLabel.Text = "In meeting";
                else inMeetingLabel.Text = "No meeting detected";
            }); // Update meeting status label
        }
        public void SetWebcamStatus(bool usingWebcam)
        {
            webcamStatusLabel.Invoke((MethodInvoker)delegate
            {
                if (usingWebcam) webcamStatusLabel.Text = "Webcam on";
                else webcamStatusLabel.Text = "Webcam off";
            }); // Update webcam status label
        }
        public string GetIP() => raspberryPiIPTextBox.Text;


        //==/ Custom component
        public class RoundedPanel : Panel
        {
            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.Clear(Parent.BackColor);
                e.Graphics.FillEllipse(new System.Drawing.SolidBrush(BackColor), e.ClipRectangle);
            }
        }
    }
}
