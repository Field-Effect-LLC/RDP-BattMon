namespace FieldEffect.Views
{
    partial class BatteryParameters
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RdpClientBattStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RdpClientEstRuntime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RdpClientBattery = new System.Windows.Forms.Label();
            this.RdpBatteryName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RdpClientBattStatus
            // 
            this.RdpClientBattStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RdpClientBattStatus.AutoSize = true;
            this.RdpClientBattStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdpClientBattStatus.Location = new System.Drawing.Point(244, 86);
            this.RdpClientBattStatus.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.RdpClientBattStatus.Name = "RdpClientBattStatus";
            this.RdpClientBattStatus.Size = new System.Drawing.Size(113, 29);
            this.RdpClientBattStatus.TabIndex = 13;
            this.RdpClientBattStatus.Text = "Unknown";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 29);
            this.label4.TabIndex = 12;
            this.label4.Text = "Batt. Status:";
            // 
            // RdpClientEstRuntime
            // 
            this.RdpClientEstRuntime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RdpClientEstRuntime.AutoSize = true;
            this.RdpClientEstRuntime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdpClientEstRuntime.Location = new System.Drawing.Point(244, 43);
            this.RdpClientEstRuntime.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.RdpClientEstRuntime.Name = "RdpClientEstRuntime";
            this.RdpClientEstRuntime.Size = new System.Drawing.Size(113, 29);
            this.RdpClientEstRuntime.TabIndex = 11;
            this.RdpClientEstRuntime.Text = "Unknown";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Est. Runtime: ";
            // 
            // RdpClientBattery
            // 
            this.RdpClientBattery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RdpClientBattery.AutoSize = true;
            this.RdpClientBattery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdpClientBattery.Location = new System.Drawing.Point(244, 0);
            this.RdpClientBattery.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.RdpClientBattery.Name = "RdpClientBattery";
            this.RdpClientBattery.Size = new System.Drawing.Size(113, 29);
            this.RdpClientBattery.TabIndex = 9;
            this.RdpClientBattery.Text = "Unknown";
            // 
            // RdpBatteryName
            // 
            this.RdpBatteryName.AutoSize = true;
            this.RdpBatteryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdpBatteryName.Location = new System.Drawing.Point(7, 0);
            this.RdpBatteryName.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.RdpBatteryName.Name = "RdpBatteryName";
            this.RdpBatteryName.Size = new System.Drawing.Size(223, 29);
            this.RdpBatteryName.TabIndex = 8;
            this.RdpBatteryName.Text = "RDP Client Battery: ";
            // 
            // BatteryParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.RdpClientBattStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RdpClientEstRuntime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RdpClientBattery);
            this.Controls.Add(this.RdpBatteryName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "BatteryParameters";
            this.Size = new System.Drawing.Size(481, 138);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RdpClientBattStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label RdpClientEstRuntime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RdpClientBattery;
        private System.Windows.Forms.Label RdpBatteryName;
    }
}
