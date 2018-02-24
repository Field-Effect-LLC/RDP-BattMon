using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.Interfaces
{
    interface IManagementObjectSearcherFactory
    {
        ManagementObjectSearcher Create();
    }
}
