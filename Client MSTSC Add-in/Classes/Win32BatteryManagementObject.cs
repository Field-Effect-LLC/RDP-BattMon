using FieldEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.Classes
{
    internal class Win32BatteryManagementObject : System.Management.ManagementObject, IManagementObject
    {
        public Win32BatteryManagementObject() : base("Win32_Battery.DeviceID=\"{BATTERY_ID}\"")
        { }
    }
}
