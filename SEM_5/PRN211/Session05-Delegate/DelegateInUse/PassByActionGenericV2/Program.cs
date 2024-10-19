namespace PassByActionGenericV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SumOnDemand(CheckEven);

            SumOnDemand(x => x % 2 != 0);

            SumOnDemand(x => true);

            //Đếm số âm
            Count(x => x > 0);
        }

        static void Count(Predicate<int> f)
        {
            List<int> arr = new List<int>() { 5, 10, 15, 20, 2, 4, 6, 8, 1 };
            int count = 0;
            foreach (int i in arr)
            {
                if (f(i))
                    count++;
            }
            Console.WriteLine(count);
        }

        static bool CheckEven(int value) => value % 2 == 0;

        //Viết hàm tính tổng của 1 dãy số cho trước
        //Tính tổng các số chẵn
        //Đếm các số lẻ

        static void SumOnDemand(Func<int, bool> f)
        {
            List<int> arr = new List<int>() { 5, 10, 15, 20, 2, 4, 6, 8, 1 };
            int result = 0;
            foreach (var item in arr)
            {
                if (f(item) == true) //Điều kiện mày đừa vào trong f
                {
                    result += item; //T làm việc của t
                }
            }// =>>>>>>> Tao tính toán theo điều kiện mày đưa vào.
            Console.WriteLine(result);
        }
        static void DoOnDemand(Predicate<int> f)
        {
            List<int> arr = new List<int>() { 5, 10, 15, 20, 2, 4, 6, 8, 1 };
            int result = 0;
            foreach (var item in arr)
            {
                result += item;
            }

            result = 0;
            foreach (var item in arr)
            {
                if (item % 2 == 0)
                    result += item;
            }

            result = 0;
            foreach (var item in arr)
            {
                if (item % 2 != 0)
                    result++;
            }
        }
    }
}
