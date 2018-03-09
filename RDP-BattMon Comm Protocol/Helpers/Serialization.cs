using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace FieldEffect.VCL.CommunicationProtocol.Helpers
{
    public static class Serialization
    {
        public static string Serialize<SerializableType>(object serializableObject)
        {
            return JsonConvert.SerializeObject(serializableObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
            });
        }

        public static SerializableType Deserialize<SerializableType>(string serializedObject)
        { 
            return JsonConvert.DeserializeObject<SerializableType>(serializedObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
            });
        }
    }
}
