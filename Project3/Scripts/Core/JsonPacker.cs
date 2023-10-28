using System.IO;
using System.Text.Json;

namespace Project3.Scripts.Core
{
    internal static class JsonPacker
    {
        public static T DeserializeJson<T>(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            string json = streamReader.ReadToEnd();
            return JsonSerializer.Deserialize<T>(json);
        }
        public static void SerializeJson<T>(T serializable, string path)
        {
            string json = JsonSerializer.Serialize(serializable);
            File.WriteAllText(path, json);
        }
    }
}
