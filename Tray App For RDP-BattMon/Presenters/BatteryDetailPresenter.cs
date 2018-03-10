using FieldEffect.Interfaces;
using FieldEffect.VCL.Server.Interfaces;
using log4net;
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
        private IBatteryParametersFactory _batteryParametersFactory;
        private ILog _log;
        private System.Timers.Timer _timer;

        public IBatteryDetail BatteryDetailView { get; set; }

        public BatteryDetailPresenter(IBatteryDataRetriever batteryDataRetriever, IBatteryIcon batteryIcon, IBatteryDetail batteryDetailView, IBatteryParametersFactory batteryParametersFactory, ILog log, System.Timers.Timer timer)
        {
            _batteryDataRetriever = batteryDataRetriever;
            _batteryIcon = batteryIcon;
            _batteryParametersFactory = batteryParametersFactory;
            _log = log;
            _timer = timer;

            BatteryDetailView = batteryDetailView;

            WireEvents();

            //Render the battery right away
            RenderBattery();

            _timer.Start();

            _log.Info(Properties.Resources.InfoMsgBattMonStart);

        }

        private void WireEvents()
        {
            _timer.Elapsed += Timer_Elapsed;
            BatteryDetailView.RequestClose += BatteryDetailView_RequestClose;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            RenderBattery();
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
            if (BatteryDetailView.InvokeRequired)
            {
                BatteryDetailView.Invoke(new Action(() => {
                    RenderBattery();
                }));
                return;
            }

            List<IBatteryInfo> batteryInfo = new List<IBatteryInfo>(_batteryDataRetriever.BatteryInfo);

            //TODO: Count() method is probably going to be slow. Rethink the Batteries::IEnumerable?
            if (batteryInfo.Count != BatteryDetailView.Batteries.Count())
            {
                //Dispose of existing
                BatteryDetailView.ClearBatteries();
                foreach (var battery in batteryInfo)
                {
                    BatteryDetailView.AddBattery(_batteryParametersFactory.Create());
                }
            }

            int i = 0; double totalBattery = 0; double totalPercent = 0;
            foreach (var battery in BatteryDetailView.Batteries)
            {
                battery.BatteryStatus = BatteryStatus(batteryInfo[i].BatteryStatus);
                battery.ClientEstRuntime = new TimeSpan(0,0,batteryInfo[i].EstimatedRunTime).ToString();
                battery.EstimatedChargeRemaining = batteryInfo[i].EstimatedChargeRemaining;
                battery.BatteryName = String.Format(Properties.Resources.BatteryName, i+1);
                totalBattery += batteryInfo[i].EstimatedChargeRemaining;
                totalPercent += 100;
                i++;
            }

            if (batteryInfo.Count > 0)
            {
                int estCharge = (int)((totalBattery / totalPercent) * 100.0);
                BatteryDetailView.ClientName = batteryInfo[0].ClientName;
                BatteryDetailView.TotalEstimatedCharge = estCharge;
                BatteryDetailView.BatteryTrayControl.Text = String.Format(Properties.Resources.RemoteBatteryText, estCharge);
                _batteryIcon.BatteryLevel = estCharge;
                _batteryIcon.Render();
                BatteryDetailView.BatteryTrayIcon = _batteryIcon.RenderedIcon;
            }
            else
            {
                BatteryDetailView.ClientName = Properties.Resources.NoBattFound;
                BatteryDetailView.BatteryTrayIcon = Properties.Resources.NoBatt;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            _log.Info(Properties.Resources.InfoMsgBattMonExit);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_isDisposed)
                {
                    if (_batteryIcon != null)
                        _batteryIcon.Dispose();

                    if (_timer != null)
                        _timer.Dispose();
                }
                _isDisposed = true;
            }
        }
    }
}
