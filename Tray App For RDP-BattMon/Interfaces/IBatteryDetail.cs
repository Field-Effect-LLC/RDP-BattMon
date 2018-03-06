using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FieldEffect.Interfaces
{
    public interface IBatteryDetail
    {
        Icon BatteryTrayIcon { get; set; }
        string ClientName { get; set; }
        NotifyIcon BatteryTrayControl { get; }
        bool Visible { get; set; }
        IEnumerable<IBatteryParameters> Batteries { get; }
        int TotalEstimatedCharge { get; set; }
        void AddBattery(IBatteryParameters parametersView);
        void ClearBatteries();

        event EventHandler<EventArgs> RequestBatteryUpdate;
        event EventHandler<FormClosingEventArgs> RequestClose;
    }
}