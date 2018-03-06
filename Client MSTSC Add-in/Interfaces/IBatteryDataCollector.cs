using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.Interfaces
{
    public interface IBatteryDataCollector : IDisposable
    {
        //Get all batteries for the system
        IEnumerable<IBatteryInfo> GetAllBatteries();
    }
}
