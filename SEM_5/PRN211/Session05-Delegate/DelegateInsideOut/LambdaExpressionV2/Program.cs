namespace LambdaExpressionV2
{
    internal class Program
    {
        //Viết hàm in ra các số từ 1..n
        delegate void OneInputNoOutputDelegate(int input);
        static void Main(string[] args)
        {
            OneInputNoOutputDelegate f = n => 
            {
                if (n < 1)
                {
                    Console.WriteLine("Invalid n. n must be >0");
                    return;
                }
                Console.WriteLine("The list of number from 1 to " + n);
                for(int i = 1; i <= n; i++)
                {
                    Console.WriteLine(i);
                }            
            };
            f(10);
        }
    }
}
