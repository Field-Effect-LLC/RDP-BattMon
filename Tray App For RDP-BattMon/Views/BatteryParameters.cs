using FieldEffect.Interfaces;
using System;
using System.Windows.Forms;

namespace FieldEffect.Views
{
    public partial class BatteryParameters : UserControl, IBatteryParameters
    {
        public BatteryParameters()
        {
            InitializeComponent();
        }

        public String BatteryName
        {
            get { return RdpBatteryName.Text; }
            set { RdpBatteryName.Text = value; }
        }

        public String BatteryStatus
        {
            get { return RdpClientBattStatus.Text; }
            set { RdpClientBattStatus.Text = value; }
        }

        public String ClientEstRuntime
        {
            get { return RdpClientEstRuntime.Text; }
            set { RdpClientEstRuntime.Text = value; }
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
    }
}
