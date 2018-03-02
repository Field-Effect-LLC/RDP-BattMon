using FieldEffect.VCL.CommunicationProtocol.Exceptions;
using FieldEffect.VCL.CommunicationProtocol.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FieldEffect.VCL.CommunicationProtocol
{
    [Serializable]
    public class Response : IResponse
    {
        private Lazy<Dictionary<String, object>> _responseValue = new Lazy<Dictionary<String, object>>();
        public Dictionary<String, object> Value { get { return _responseValue.Value; } }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this) + '\0';
        }

        public static Response Deserialize(String value)
        {
            if (!value.EndsWith("\0"))
                throw new BattMonCommunicationException("Response text was garbled");

            value = value.Substring(0, value.Length - 1);

            return JsonConvert.DeserializeObject<Response>(value);
        }
    }
}
