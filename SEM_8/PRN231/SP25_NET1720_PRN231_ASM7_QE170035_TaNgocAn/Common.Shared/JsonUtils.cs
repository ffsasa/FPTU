using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Shared
{
    public class JsonUtils
    {
        public static void WriteJson<T>(List<T> list, string path)
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };
            string json = JsonSerializer.Serialize(list, option);
            System.IO.File.WriteAllText(path, json);
        }

        public static List<T> ReadJson<T>(string path)
        {
            string json = System.IO.File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}
