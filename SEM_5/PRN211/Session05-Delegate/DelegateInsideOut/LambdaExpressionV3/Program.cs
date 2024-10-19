namespace LambdaExpressionV3
{
    //Tính diện tích hình chữ nhật, trả về diện tích
    delegate double TwoInputOneOutput(double x, double y);
    internal class Program
    {
        static void Main(string[] args)
        {
            TwoInputOneOutput f = (a, b) =>  a * b;
            
            f = (x , y) => Math.Pow(x,y);
            Console.WriteLine(f(2,3));

            //Tính chu vi tam giác
            var fx = (double a, double b, double c) => a + b + c;
            Console.WriteLine(fx(3,4,5));
        }
    }
}
