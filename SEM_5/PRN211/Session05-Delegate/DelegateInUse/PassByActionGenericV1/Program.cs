namespace PassByActionGenericV1
{
    //Hàm nhận vào 1 con số, in ra con số đố nếu nó là số chẵn
    //Hàm nhận vào 1 con số, in ra con số đố nếu nó là số lẻ
    //Hàm nhận vào 1 con số, in ra con số đố nếu nó > 50
    //Hàm nhận vào 1 con số, in ra con số đố nếu nó là số nguyên tố
    internal class Program
    {
        static void Main(string[] args)
        {
            //PrintEvenNumber(50);
            //PrintNumberGt50(50);
            //PrintOddNumber(50);
            //PrintPrimeNumber(50);

            PrintOnDemand(PrintEvenNumber); //=> Trở nên linh hoạt với việc sử lý data bên trong
            PrintOnDemand(x =>
            {
                if (x % 5 == 0)
                    Console.WriteLine(x);
            });

            PrintOnDemandV2(PrintOddNumber);
        }

        static void PrintOnDemandV2(Action<int> f)
        {
            //Nếu tao có nhiều data, tao đưa hết cho mày qua vòng for. Mày làm gì data của t thì kệ m
            //Có data bên trong, gọi hàm xử lý ở bên ngoài
            List<int> list = new List<int> {5, 10, 15, 20, 25, 36, 31, 543};
            foreach (int x in list) 
            { 
                f(x);
            }

        }

        static void PrintOnDemand(Action<int> f)
        {   
            f(5);
            f(13);
            f(50);
            //Data: 5;13;50
            //Cùng 1 data nhưng trả về nhiều kết quả.
        }

        static void PrintEvenNumber(int n)
        {
            if (n % 2 == 0 )
                Console.WriteLine(n);
        }

        static void PrintOddNumber(int n)
        {
            if (n % 2 != 0)
                Console.WriteLine(n);
        }

        static void PrintNumberGt50(int n)
        {
            if (n > 50)
                Console.WriteLine(n);
        }

        static void PrintPrimeNumber(int n)
        {
            if (n < 2) 
                return;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return;
            }
            Console.WriteLine(n);
        }
    }
}
