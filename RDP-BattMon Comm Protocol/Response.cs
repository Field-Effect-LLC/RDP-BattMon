using FieldEffect.VCL.CommunicationProtocol.Exceptions;
using FieldEffect.VCL.CommunicationProtocol.Interfaces;
using System;
using System.Collections.Generic;
using FieldEffect.VCL.CommunicationProtocol.Helpers;

namespace FieldEffect.VCL.CommunicationProtocol
{
    [Serializable]
    public class Response : IResponse
    {
        public Dictionary<String, object> Value { get; private set; }

        public Response()
        {
            Value = new Dictionary<String, object>();
        }

        public string Serialize()
        {
            return Serialization.Serialize<Response>(this) + '\0';
        }

        public static Response Deserialize(String value)
        {
            if (!value.EndsWith("\0"))
                throw new BattMonCommunicationException("Response text was garbled");

            value = value.Substring(0, value.Length - 1);

            return Serialization.Deserialize<Response>(value);
        }
    }
}
