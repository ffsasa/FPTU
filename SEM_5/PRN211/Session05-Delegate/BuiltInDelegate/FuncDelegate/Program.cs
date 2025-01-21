using System.Security.Cryptography;

namespace FuncDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Viết hàm  nhận vào 1 con số, sau đó trả về bình phương của nó, có return
            Func<double, double> f1 = x=> Math.Pow(x,2);
            Console.WriteLine(f1(3));

            //Viết hàm trả về 1 con số bất kì
            Func<int> f2 = () => 123;

            Func<int, Boolean> f3 = n => n <= 8;

            Predicate<int> f4 = n => n <= 8;
        }
    }
}
