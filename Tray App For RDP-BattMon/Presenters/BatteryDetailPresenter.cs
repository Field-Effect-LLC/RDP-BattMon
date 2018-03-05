using FieldEffect.Interfaces;
using FieldEffect.VCL.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FieldEffect.Presenters
{
    public class BatteryDetailPresenter : IBatteryDetailPresenter
    {
        private IBatteryDataRetriever _batteryDataRetriever;
        private IBatteryIcon _batteryIcon;
        private bool _isDisposed = false;

        public IBatteryDetail BatteryDetailView { get; set; }

        public BatteryDetailPresenter(IBatteryDataRetriever batteryDataRetriever, IBatteryIcon batteryIcon, IBatteryDetail batteryDetailView)
        {
            _batteryDataRetriever = batteryDataRetriever;
            _batteryIcon = batteryIcon;
            BatteryDetailView = batteryDetailView;
            WireEvents();

            //Render the battery right away
            RenderBattery();
        }

        private void WireEvents()
        {
            BatteryDetailView.RequestBatteryUpdate += BatteryDetailView_RequestBatteryUpdate;
            BatteryDetailView.RequestClose += BatteryDetailView_RequestClose;
        }

        private void BatteryDetailView_RequestClose(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                BatteryDetailView.Visible = false;
                BatteryDetailView.BatteryTrayControl.BalloonTipTitle = Properties.Resources.MinimizedTitle;
                BatteryDetailView.BatteryTrayControl.BalloonTipText = Properties.Resources.MinimizedMessage;
                BatteryDetailView.BatteryTrayControl.ShowBalloonTip(5000);
            }
        }

        private void BatteryDetailView_RequestBatteryUpdate(object sender, EventArgs e)
        {
            RenderBattery();
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

        private void RenderBattery()
        {
            IBatteryInfo batteryInfo = _batteryDataRetriever.BatteryInfo;
            if (batteryInfo != null)
            {
                BatteryDetailView.BatteryStatus = BatteryStatus(batteryInfo.BatteryStatus);
                BatteryDetailView.ClientEstRuntime = batteryInfo.EstimatedRunTime.ToString();
                BatteryDetailView.EstimatedChargeRemaining = batteryInfo.EstimatedChargeRemaining;
                BatteryDetailView.ClientName = batteryInfo.ClientName;
                BatteryDetailView.BatteryTrayControl.Text = String.Format(Properties.Resources.RemoteBatteryText, batteryInfo.EstimatedChargeRemaining);
                _batteryIcon.BatteryLevel = batteryInfo.EstimatedChargeRemaining;
                _batteryIcon.Render();
                BatteryDetailView.BatteryTrayIcon = _batteryIcon.RenderedIcon;
            }
            else
            {
                
                BatteryDetailView.BatteryStatus = BatteryStatus(0);
                BatteryDetailView.ClientEstRuntime = Properties.Resources.Unknown;
                BatteryDetailView.EstimatedChargeRemaining = 0;
                BatteryDetailView.ClientName = Properties.Resources.Unknown;

                BatteryDetailView.BatteryTrayControl.Text = Properties.Resources.RemoteBatteryUnknown;
                _batteryIcon.BatteryLevel = 0;
                _batteryIcon.Render();
                BatteryDetailView.BatteryTrayIcon = _batteryIcon.RenderedIcon;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_isDisposed)
                {
                    _batteryIcon.Dispose();
                }
                _isDisposed = true;
            }
        }
    }
}
