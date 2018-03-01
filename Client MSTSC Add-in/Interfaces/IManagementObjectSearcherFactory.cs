using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.Interfaces
{
    public interface IManagementObjectSearcherFactory
    {
        ManagementObjectSearcher Create();

        ManagementObjectSearcher Create(string query);
    }
}
