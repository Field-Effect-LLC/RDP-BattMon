using FieldEffect.Classes;
using FieldEffect.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FieldEffect.VCL.Server;
using FieldEffect.Interfaces;

namespace FieldEffect.Views
{
    public partial class BatteryDetail : Form, IBatteryDetail
    {
        public event EventHandler<EventArgs> RequestBatteryUpdate;
        public event EventHandler<FormClosingEventArgs> RequestClose;

        public BatteryDetail()
        {
            InitializeComponent();
            Shown += (s, e) => Visible = false;
        }

        public Icon BatteryTrayIcon
        {
            get { return BatteryTray.Icon; }
            set { BatteryTray.Icon = value; }
        }

        public NotifyIcon BatteryTrayControl
        {
            get { return BatteryTray; }
        }

        public String BatteryStatus
        {
            get { return RdpClientBattStatus.Text;  }
            set { RdpClientBattStatus.Text = value; }
        }

        public String ClientEstRuntime
        {
            get { return RdpClientEstRuntime.Text; }
            set { RdpClientEstRuntime.Text = value; }
        }

        public String ClientName
        {
            get { return RdpClientName.Text; }
            set { RdpClientName.Text = value; }
        }

        private int _estimatedChargeRemaining = 0;
        public int EstimatedChargeRemaining
        {
            get { return _estimatedChargeRemaining; }
            set
            {
                _estimatedChargeRemaining = value;
                RdpClientBattery.Text = String.Format("{0}%", _estimatedChargeRemaining);
            }
        }

        protected void OnRequestBatteryData(EventArgs args)
        {
            RequestBatteryUpdate?.Invoke(this, args);
        }

        protected void OnRequestClose(FormClosingEventArgs args)
        {
            RequestClose?.Invoke(this, args);
        }

        private void PollTimer_Tick(object sender, EventArgs e)
        {
            OnRequestBatteryData(EventArgs.Empty);
        }

        private void BatteryTray_DoubleClick(object sender, EventArgs e)
        {
            Visible = !Visible;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BatteryDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnRequestClose(e);
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Resources.SourceCode);
        }
    }
}
