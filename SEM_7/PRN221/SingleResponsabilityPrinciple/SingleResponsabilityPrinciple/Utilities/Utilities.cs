using Newtonsoft.Json;
using SingleResponsabilityPrinciple.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsabilityPrinciple.Utilities
{
    public class Utilities
    {
        static string ReadFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public static List<Book> ReadData()
        {
            var cadJson = ReadFile("Data/BookStore_01.json");
            return JsonConvert.DeserializeObject<List<Book>>(cadJson);
        }

        public static List <Book> ReadDataExtra()
        {
            List<Book> books = ReadData();
            var cadJson = ReadFile("Data/BookStore_02.json");
            books.AddRange(JsonConvert.DeserializeObject<List<Book>>(cadJson));
            return books;
        }
    }
}
