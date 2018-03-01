using FieldEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.Classes
{
    public class Win32BatteryManagementObject : System.Management.ManagementObject, IManagementObject
    {
        public Win32BatteryManagementObject(string query) : base(query)
        { }
    }
}
