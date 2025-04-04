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
        private static string loggerFilePath = Directory.GetCurrentDirectory() + @"AN.txt";
        public static string ConvertObjectToJSONString<T>(T entity)
        {
            string JsonString = JsonSerializer.Serialize(entity, new JsonSerializerOptions { WriteIndented = false });

            return JsonString;
        }

        public static void WriteLoggerFile(string message)
        {
            using (StreamWriter sw = File.AppendText(loggerFilePath))
            {
                sw.WriteLine(message);
            }
        }
    }
}
