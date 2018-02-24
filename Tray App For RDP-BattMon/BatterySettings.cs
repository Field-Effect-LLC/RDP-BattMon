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

namespace FieldEffect
{
    public partial class BatterySettings : Form
    {
        private BatteryLevel battStatus;
        public BatterySettings()
        {
            InitializeComponent();
            battStatus = new BatteryLevel("BATTMON");
        }

        private void PollTimer_Tick(object sender, EventArgs e)
        {
            int remaining = battStatus.Poll();
            RdpClientBattery.Text = String.Format("{0}%", remaining);
        }
    }
}
