using System;
using System.Drawing;
using System.Windows.Forms;

namespace FieldEffect.Interfaces
{
    public interface IBatteryDetail
    {
        string BatteryStatus { get; set; }
        Icon BatteryTrayIcon { get; set; }
        string ClientEstRuntime { get; set; }
        string ClientName { get; set; }
        int EstimatedChargeRemaining { get; set; }
        NotifyIcon BatteryTrayControl { get; }
        bool Visible { get; set; }

        event EventHandler<EventArgs> RequestBatteryUpdate;
        event EventHandler<FormClosingEventArgs> RequestClose;
    }
}