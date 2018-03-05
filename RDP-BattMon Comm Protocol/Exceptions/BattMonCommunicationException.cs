using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.VCL.CommunicationProtocol.Exceptions
{
    public class BattMonCommunicationException : Exception
    {
        public BattMonCommunicationException(string message) : base(message) { }
    }
}
