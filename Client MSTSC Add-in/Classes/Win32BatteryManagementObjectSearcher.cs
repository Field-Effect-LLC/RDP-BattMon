using FieldEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.Classes
{
    public class Win32BatteryManagementObjectSearcher : ManagementObjectSearcher, IWin32BatteryManagementObjectSearcher
    {
        public Win32BatteryManagementObjectSearcher(string query) : base(query)
        { }
    }
}
