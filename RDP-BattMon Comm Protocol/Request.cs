using FieldEffect.VCL.CommunicationProtocol.Exceptions;
using FieldEffect.VCL.CommunicationProtocol.Helpers;
using FieldEffect.VCL.CommunicationProtocol.Interfaces;
using System;
using System.Collections.Generic;

namespace FieldEffect.VCL.CommunicationProtocol
{
    [Serializable]
    public class Request : IRequest
    {
        public List<String> Value { get; private set; }

        public Request()
        {
            Value = new List<String>();
        }

        public string Serialize()
        {
            return Serialization.Serialize<Request>(this) + '\0';
        }

        public static Request Deserialize(String value)
        {
            if (!value.EndsWith("\0"))
                throw new BattMonCommunicationException("Request text was garbled");

            value = value.Substring(0, value.Length - 1);

            return Serialization.Deserialize<Request>(value);
        }
    }
}
