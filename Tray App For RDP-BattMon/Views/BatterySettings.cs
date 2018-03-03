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

namespace FieldEffect.Views
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

            RdpClientName.Text = _batteryStatus.ClientName;

            Shown += (s, e) => Visible = false;
        }

        private string BatteryStatus(int status)
        {

            return new Dictionary<int, String>()
            {
                { 0, "Unknown"                    },
                { 1, "Discharging"                },
                { 2, "Unknown"                    },
                { 3, "Fully Charged"              },
                { 4, "Low"                        },
                { 5, "Critical"                   },
                { 6, "Charging"                   },
                { 7, "Charging and High"          },
                { 8, "Charging and Low"           },
                { 9, "Charging and Critical"      },
                { 10, "Undefined"                 },
                { 11, "Partially Charged"         }
            }[status];

            
        }

        private void PollTimer_Tick(object sender, EventArgs e)
        {
            int chargeRemaining = _batteryStatus.EstimatedChargeRemaining;
            _batteryIcon.BatteryLevel = chargeRemaining;
            
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
            
            RdpClientBattery.Text = String.Format("{0}%", chargeRemaining);

            BatteryTray.Text = String.Format("Remote Battery: {0}%", chargeRemaining);

            RdpClientEstRuntime.Text = _batteryStatus.EstimatedRunTime;
            RdpClientBattStatus.Text = BatteryStatus(_batteryStatus.BatteryStatus);
        }

        private void BatteryTray_DoubleClick(object sender, EventArgs e)
        {
            Visible = !Visible;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BatterySettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
                e.Cancel = true;

            Visible = false;
            BatteryTray.BalloonTipTitle = "BattMon has been minimized";
            BatteryTray.BalloonTipText = "The BattMon remote battery monitor is still running in the background.  To exit, right-click on this icon, and choose \"Exit\".";
            BatteryTray.ShowBalloonTip(5000);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Resources.SourceCode);
        }
    }
}
