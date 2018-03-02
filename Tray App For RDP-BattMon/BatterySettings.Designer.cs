namespace FieldEffect
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RdpClientName = new System.Windows.Forms.Label();
            this.RdpClientBattery = new System.Windows.Forms.Label();
            this.PollTimer = new System.Windows.Forms.Timer(this.components);
            this.TrayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "RDP Client Battery: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "RDP Client Name:";
            // 
            // RdpClientName
            // 
            this.RdpClientName.AutoSize = true;
            this.RdpClientName.Location = new System.Drawing.Point(284, 76);
            this.RdpClientName.Name = "RdpClientName";
            this.RdpClientName.Size = new System.Drawing.Size(181, 29);
            this.RdpClientName.TabIndex = 2;
            this.RdpClientName.Text = "CLIENT_NAME";
            // 
            // RdpClientBattery
            // 
            this.RdpClientBattery.AutoSize = true;
            this.RdpClientBattery.Location = new System.Drawing.Point(284, 115);
            this.RdpClientBattery.Name = "RdpClientBattery";
            this.RdpClientBattery.Size = new System.Drawing.Size(175, 29);
            this.RdpClientBattery.TabIndex = 3;
            this.RdpClientBattery.Text = "CLIENT_BATT";
            // 
            // PollTimer
            // 
            this.PollTimer.Enabled = true;
            this.PollTimer.Interval = 10000;
            this.PollTimer.Tick += new System.EventHandler(this.PollTimer_Tick);
            // 
            // TrayMenuStrip
            // 
            this.TrayMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TrayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.TrayMenuStrip.Name = "TrayMenuStrip";
            this.TrayMenuStrip.Size = new System.Drawing.Size(245, 84);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(244, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // BatterySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(515, 352);
            this.Controls.Add(this.RdpClientBattery);
            this.Controls.Add(this.RdpClientName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "BatterySettings";
            this.Text = "BatterySettings";
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
    }
}