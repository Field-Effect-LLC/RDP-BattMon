using System.Collections.Generic;

namespace FieldEffect.VCL.CommunicationProtocol.Interfaces
{
    public interface IResponse
    {
        Dictionary<string, object> Value { get; }

        string Serialize();
    }
}