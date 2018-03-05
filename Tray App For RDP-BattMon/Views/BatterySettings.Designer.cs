namespace FieldEffect.Views
{
    partial class BatterySettings
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
            this.BatteryTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RdpClientName = new System.Windows.Forms.Label();
            this.RdpClientBattery = new System.Windows.Forms.Label();
            this.PollTimer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.RdpClientEstRuntime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RdpClientBattStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.TrayMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BatteryTray
            // 
            this.BatteryTray.ContextMenuStrip = this.TrayMenuStrip;
            this.BatteryTray.Text = "Remote Battery Status";
            this.BatteryTray.Visible = true;
            this.BatteryTray.DoubleClick += new System.EventHandler(this.BatteryTray_DoubleClick);
            // 
            // TrayMenuStrip
            // 
            this.TrayMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TrayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.TrayMenuStrip.Name = "TrayMenuStrip";
            this.TrayMenuStrip.Size = new System.Drawing.Size(128, 40);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "RDP Client Battery: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "RDP Client Name:";
            // 
            // RdpClientName
            // 
            this.RdpClientName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RdpClientName.AutoSize = true;
            this.RdpClientName.Location = new System.Drawing.Point(284, 9);
            this.RdpClientName.Name = "RdpClientName";
            this.RdpClientName.Size = new System.Drawing.Size(113, 29);
            this.RdpClientName.TabIndex = 2;
            this.RdpClientName.Text = "Unknown";
            // 
            // RdpClientBattery
            // 
            this.RdpClientBattery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RdpClientBattery.AutoSize = true;
            this.RdpClientBattery.Location = new System.Drawing.Point(284, 51);
            this.RdpClientBattery.Name = "RdpClientBattery";
            this.RdpClientBattery.Size = new System.Drawing.Size(113, 29);
            this.RdpClientBattery.TabIndex = 3;
            this.RdpClientBattery.Text = "Unknown";
            // 
            // PollTimer
            // 
            this.PollTimer.Enabled = true;
            this.PollTimer.Interval = 10000;
            this.PollTimer.Tick += new System.EventHandler(this.PollTimer_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Est. Runtime: ";
            // 
            // RdpClientEstRuntime
            // 
            this.RdpClientEstRuntime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RdpClientEstRuntime.AutoSize = true;
            this.RdpClientEstRuntime.Location = new System.Drawing.Point(284, 94);
            this.RdpClientEstRuntime.Name = "RdpClientEstRuntime";
            this.RdpClientEstRuntime.Size = new System.Drawing.Size(113, 29);
            this.RdpClientEstRuntime.TabIndex = 5;
            this.RdpClientEstRuntime.Text = "Unknown";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Batt. Status:";
            // 
            // RdpClientBattStatus
            // 
            this.RdpClientBattStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RdpClientBattStatus.AutoSize = true;
            this.RdpClientBattStatus.Location = new System.Drawing.Point(284, 138);
            this.RdpClientBattStatus.Name = "RdpClientBattStatus";
            this.RdpClientBattStatus.Size = new System.Drawing.Size(113, 29);
            this.RdpClientBattStatus.TabIndex = 7;
            this.RdpClientBattStatus.Text = "Unknown";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(499, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "BattMon: RDP Client Battery Reporting Add-In";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 258);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(232, 29);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "GitHub Project Page";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // BatterySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(581, 315);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RdpClientBattStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RdpClientEstRuntime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RdpClientBattery);
            this.Controls.Add(this.RdpClientName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BatterySettings";
            this.Text = "BatterySettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BatterySettings_FormClosing);
            this.TrayMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon BatteryTray;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RdpClientName;
        private System.Windows.Forms.Label RdpClientBattery;
        private System.Windows.Forms.Timer PollTimer;
        private System.Windows.Forms.ContextMenuStrip TrayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RdpClientEstRuntime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label RdpClientBattStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}