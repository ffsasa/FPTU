namespace Numbers
{
    internal class Program
    {
        //Lưu trữ 1 danh sách các số nguyên cho trước
        //Sau đó in ra các số dương
        //              Các số âm
        //              In ra toàn bộ
        //              In ra các số chia hết cho 5
        static void Main(string[] args)
        {
            Console.WriteLine("Print All");
            PrintOnDeman(x => true);

            Console.WriteLine("Print +");
            PrintOnDeman(x => x > 0);

            PlayWithBuiltInOnDemandMethods();

            PlayWithBuiltInOnDemandMethodsV2();
        }

        static void PlayWithBuiltInOnDemandMethodsV2()
        {
            List<int> list = new List<int>() { -10, -100, 50, 2, 1, 5, 10, 13, -2 };

            var result = from x in list
                         where x > 0
                         select x;
            //LINQ - Style Query

            Console.WriteLine("> 0 using query");
            foreach (var x in result) { Console.WriteLine(x); }

            Console.WriteLine("Divisable by 2");
            result = from x in list
                     where x % 2 == 0
                     select x;
            foreach (var x in result) { Console.WriteLine(x); }
        }

        static void PlayWithBuiltInOnDemandMethods()
        {
            List<int> list = new List<int>() { -10, -100, 50, 2, 1, 5, 10, 13, -2 };

            list.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            list.ForEach(x => { if (x < 0) Console.Write(x + " "); });

            Console.WriteLine("< 0 LIST =======================");

            List<int> list2 = list.Where(x => x > 0).ToList();
            list2.ForEach(x => Console.Write(x + " "));

        }

        static void PrintOnDeman(Predicate<int> f)
        {
            List<int> list = new List<int>() { -10, -100, 50, 2, 1, 5, 10, 13, -2 };

            foreach (int i in list)
            {
                //Giao hết cho bên ngoài in
                //Check bằng hàm bên ngoài và tự in
                if (f(i))
                    Console.WriteLine(i);
            }
        }
    }
}
