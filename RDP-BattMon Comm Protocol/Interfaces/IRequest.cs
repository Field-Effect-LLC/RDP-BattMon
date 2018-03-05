using System.Collections.Generic;

namespace FieldEffect.VCL.CommunicationProtocol.Interfaces
{
    public interface IRequest
    {
        List<string> Value { get; }

        string Serialize();
    }
}