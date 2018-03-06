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

        protected Lazy<List<IBatteryParameters>> _batteryParameters =
            new Lazy<List<IBatteryParameters>>();

        protected int _totalEstimatedCharge = 0;

        public BatteryDetail()
        {
            InitializeComponent();
            Shown += (s, e) => Visible = false;
        }

        public Icon BatteryTrayIcon
        {
            get { return BatteryTray.Icon; }
            set
            {
                BatteryTray.Icon = value;
                Icon = value;
            }
        }

        public NotifyIcon BatteryTrayControl
        {
            get { return BatteryTray; }
        }

        public String ClientName
        {
            get { return RdpClientName.Text; }
            set { RdpClientName.Text = value; }
        }

        public IEnumerable<IBatteryParameters> Batteries
        {
            get
            {
                //return _batteryParameters.Value;
                foreach (var control in BatteryDetailPanel.Controls)
                {
                    if (control is IBatteryParameters)
                        yield return (IBatteryParameters)control;
                }
            }
        }
        public void ClearBatteries()
        {
            foreach(var battery in Batteries)
            {
                BatteryDetailPanel.Controls.Remove((Control)battery);
                battery.Dispose();
            }
        }
        public void AddBattery(IBatteryParameters parametersView)
        {
            var battView = (Control)parametersView;
            BatteryDetailPanel.Controls.Add(battView);
        }

        protected void OnRequestBatteryData(EventArgs args)
        {
            RequestBatteryUpdate?.Invoke(this, args);
        }

        public int TotalEstimatedCharge
        {
            get { return _totalEstimatedCharge; }
            set
            {
                _totalEstimatedCharge = value;
                RdpTotalEstCharge.Text = String.Format("{0}%", _totalEstimatedCharge);
            }
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
