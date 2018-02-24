using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.Interfaces
{
    interface IManagementObject : IDisposable
    {
        void Get();
        object this[string index] { get; }
    }
}
