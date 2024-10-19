using System.Threading.Channels;

namespace Numerology
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberService.PrintNumbers(x =>
            {
                if (x<0)
                {
                    Console.WriteLine(x);
                }
            });
        }
    }
}
