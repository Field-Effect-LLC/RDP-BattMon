using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.VCL.Exceptions
{
    public class VirtualChannelException : Exception
    {
        public VirtualChannelException(string message) : base(message)
        { }
    }
}
