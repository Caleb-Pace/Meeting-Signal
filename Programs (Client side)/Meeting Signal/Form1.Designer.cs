namespace Meeting_Signal
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ledColourPanel = new Meeting_Signal.Form1.RoundedPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.raspberryPiIPTextBox = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.inMeetingLabel = new System.Windows.Forms.Label();
            this.webcamStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ledColourPanel
            // 
            this.ledColourPanel.BackColor = System.Drawing.Color.Chartreuse;
            this.ledColourPanel.Location = new System.Drawing.Point(199, 94);
            this.ledColourPanel.Name = "ledColourPanel";
            this.ledColourPanel.Size = new System.Drawing.Size(31, 31);
            this.ledColourPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "LED Colour:";
            // 
            // raspberryPiIPTextBox
            // 
            this.raspberryPiIPTextBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raspberryPiIPTextBox.Location = new System.Drawing.Point(94, 50);
            this.raspberryPiIPTextBox.MaxLength = 15;
            this.raspberryPiIPTextBox.Name = "raspberryPiIPTextBox";
            this.raspberryPiIPTextBox.Size = new System.Drawing.Size(165, 38);
            this.raspberryPiIPTextBox.TabIndex = 1;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Meeting Signal";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // connectionLabel
            // 
            this.connectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.connectionLabel.Location = new System.Drawing.Point(94, 27);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(165, 20);
            this.connectionLabel.TabIndex = 3;
            this.connectionLabel.Text = "Not Connected!";
            this.connectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inMeetingLabel
            // 
            this.inMeetingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inMeetingLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.inMeetingLabel.Location = new System.Drawing.Point(53, 145);
            this.inMeetingLabel.Name = "inMeetingLabel";
            this.inMeetingLabel.Size = new System.Drawing.Size(206, 20);
            this.inMeetingLabel.TabIndex = 4;
            this.inMeetingLabel.Text = "Please";
            this.inMeetingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // webcamStatusLabel
            // 
            this.webcamStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webcamStatusLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.webcamStatusLabel.Location = new System.Drawing.Point(53, 165);
            this.webcamStatusLabel.Name = "webcamStatusLabel";
            this.webcamStatusLabel.Size = new System.Drawing.Size(206, 20);
            this.webcamStatusLabel.TabIndex = 5;
            this.webcamStatusLabel.Text = "Connected!";
            this.webcamStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 201);
            this.Controls.Add(this.webcamStatusLabel);
            this.Controls.Add(this.inMeetingLabel);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.raspberryPiIPTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ledColourPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meeting Signal";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        public System.Windows.Forms.TextBox raspberryPiIPTextBox;
        public Meeting_Signal.Form1.RoundedPanel ledColourPanel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label connectionLabel;
        public System.Windows.Forms.Label inMeetingLabel;
        public System.Windows.Forms.Label webcamStatusLabel;
    }
}

