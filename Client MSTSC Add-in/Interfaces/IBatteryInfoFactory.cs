using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldEffect.VCL.CommunicationProtocol;

namespace FieldEffect.Interfaces
{
    public interface IBatteryInfoFactory
    {
        BatteryInfo Create(string clientName, int estimatedChargeRemaining,
            int estimatedRunTime, int batteryStatus);
    }
}
