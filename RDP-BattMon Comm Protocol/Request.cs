using FieldEffect.VCL.CommunicationProtocol.Exceptions;
using FieldEffect.VCL.CommunicationProtocol.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FieldEffect.VCL.CommunicationProtocol
{
    [Serializable]
    public class Request : IRequest
    {
        private Lazy<List<String>> _requestValue = new Lazy<List<string>>();
        public List<String> Value { get { return _requestValue.Value; } }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this) + '\0';
        }

        public static Request Deserialize(String value)
        {
            if (!value.EndsWith("\0"))
                throw new BattMonCommunicationException("Request text was garbled");

            value = value.Substring(0, value.Length - 1);

            return JsonConvert.DeserializeObject<Request>(value);
        }
    }
}
