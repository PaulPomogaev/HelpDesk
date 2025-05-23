using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.IO;

namespace HelpDesk.Common
{
    public static class JsonProvider
    {
        private static readonly JsonSerializerSettings settings = new()
        {
            TypeNameHandling = TypeNameHandling.None,
            Formatting = Formatting.Indented,
            Converters = { new StringEnumConverter() }
        };

        public static List<T> Deserialize<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new List<T>();
            }

            var text = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<List<T>>(text) ?? new List<T>();
        }

        public static void Serialize<T>(List<T> values, string fileName)
        {
            var jsonData = JsonConvert.SerializeObject(values, settings);
            File.WriteAllText(fileName, jsonData);
        }
    }
}
