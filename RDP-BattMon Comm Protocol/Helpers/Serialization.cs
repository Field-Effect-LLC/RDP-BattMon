using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Polenter.Serialization;

namespace FieldEffect.VCL.CommunicationProtocol.Helpers
{
    public static class Serialization
    {
        public static string Serialize<SerializableType>(object serializableObject)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (TextReader stringReader = new StreamReader(memoryStream))
            {
                SharpSerializer serializer = new SharpSerializer(false);
                serializer.Serialize(serializableObject, memoryStream);
                memoryStream.Flush();
                memoryStream.Position = 0;
                return stringReader.ReadToEnd();
            }
        }

        public static SerializableType Deserialize<SerializableType>(string serializedObject)
        {
            SharpSerializer serializer = new SharpSerializer(false);
            using (MemoryStream memoryStream = new MemoryStream())
            using (TextWriter stringWriter = new StreamWriter(memoryStream))
            {
                stringWriter.Write(serializedObject);
                stringWriter.Flush();
                memoryStream.Position = 0;
                return (SerializableType)serializer.Deserialize(memoryStream);
            }
        }
    }
}
