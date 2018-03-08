using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldEffect.Interfaces;

namespace FieldEffect
{
    [Serializable]
    public class BatteryInfo : IBatteryInfo
    {
        public BatteryInfo()
        { }
        public BatteryInfo(string clientName, int estimatedChargeRemaining, 
            int estimatedRunTime, int batteryStatus)
        {
            ClientName = clientName;
            EstimatedChargeRemaining = estimatedChargeRemaining;
            EstimatedRunTime = estimatedRunTime;
            BatteryStatus = batteryStatus;
        }
        virtual public string ClientName { get; protected set; }
        virtual public int EstimatedChargeRemaining { get; protected set; }

        virtual public int EstimatedRunTime { get; protected set; }

        virtual public int BatteryStatus { get; protected set; }
    }
}
