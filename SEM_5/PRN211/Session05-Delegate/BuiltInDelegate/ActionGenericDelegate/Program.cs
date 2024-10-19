namespace ActionGenericDelegate
{
    //Chalenge: Viết hàm nhận vào 1 số nguyên dương, in ra bình phương của nó
    internal class Program
    {
        static void Main(string[] args)
        {
            //Void không đầu vào và có đầu vào
            Action f0 = () => { Console.WriteLine("Kaka"); };
            Action<int, long> f = (n, y) => Console.WriteLine($"{n} {y}");
           
            //Có output và không đầu vào vs có đầu vào. Input cuối cùng sẽ là giá trị trả về của hàm.
            Func<int, long, long> f1 = (x, y) => x * y;
            Func<int> f2 = () => 2 * 3;

            //Dùng action<> tình mũ 3 của 1 số và in ra, dùng lambda và action.
            Action<int> fx = x => Console.WriteLine(Math.Pow(x,3));
            fx(2);

            //Viết hàm in ra diện tích hình chữ nhận
            Action<int, int> fcn = (x, y) => Console.WriteLine($"Diện tích hình chữ nhật: {x*y}");
            fcn(3,4);

            //In ra các số chẵn từ 1 - n
            Action<int> fcchan = x =>
            {
                if (x < 1) 
                {
                    Console.WriteLine("n must be > 0");
                    return;
                }

                for (int i = 1; i <= x; i++)
                {
                    if((i % 2) == 0)
                        Console.Write(i + " ");
                }
            };
        }
    }
}
