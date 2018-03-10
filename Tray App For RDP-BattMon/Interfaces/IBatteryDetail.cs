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
        bool InvokeRequired { get; }
        object Invoke(Delegate method, params object[] args);

        event EventHandler<FormClosingEventArgs> RequestClose;
    }
}