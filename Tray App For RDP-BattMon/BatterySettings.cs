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

namespace FieldEffect
{
    public partial class BatterySettings : Form
    {
        private BatteryDataRetriever _batteryStatus;
        private BatteryIcon _batteryIcon;
        private Icon _batteryTemplate;
        private List<IDisposable> _disposables = new List<IDisposable>();

        public BatterySettings()
        {
            InitializeComponent();
            var channel = new RdpServerVirtualChannel("BATTMON");

            _batteryStatus = new BatteryDataRetriever(channel);

            _batteryTemplate = Properties.Resources.BattLevel;

            //4,9 - 25,20
            _batteryIcon = new BatteryIcon(
                    _batteryTemplate,
                    new Rectangle(5, 10, 20, 10),
                    BatteryIcon.BatteryOrientation.HorizontalL
                )
            {
                BatteryLevel = 0
            };

            _disposables.Add(_batteryTemplate);

            //Start with blank battery icon
            BatteryTray.Icon = _batteryTemplate;

            Shown += (s, e) => Visible = false;
        }

        private void PollTimer_Tick(object sender, EventArgs e)
        {
            int remaining = _batteryStatus.Poll();
            _batteryIcon.BatteryLevel = remaining;

            Bitmap template = _batteryTemplate.ToBitmap();
            using (var g = Graphics.FromImage(template))
            {
                _batteryIcon.Render(g);
            }

            IntPtr hIcon = template.GetHicon();

            if (BatteryTray.Icon != null && !_batteryTemplate.Equals(BatteryTray.Icon))
            {
                NativeMethods.DestroyIcon(BatteryTray.Icon.Handle);
                BatteryTray.Icon.Dispose();
            }

            BatteryTray.Icon = Icon.FromHandle(hIcon); //_batteryIcon.RenderedIcon;
            
            RdpClientBattery.Text = String.Format("{0}%", remaining);

            BatteryTray.Text = String.Format("Remote Battery: {0}%", remaining);
        }

        private void BatteryTray_DoubleClick(object sender, EventArgs e)
        {
            Visible = !Visible;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
