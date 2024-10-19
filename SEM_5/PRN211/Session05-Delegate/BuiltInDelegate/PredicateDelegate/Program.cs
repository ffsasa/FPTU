namespace PredicateDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Microsoft: Nếu hàm chỉ nhận đúng 1 đầu vào, và trả lại boolean thì ta dùng Predicate.
            //Hàm này được gọi là hàm tiên đoán, hàm dự đoán, hàm mệnh đề => Predicate
            Predicate<double> f = gpa => gpa <= 8;

            var fx = (double a, double b, double c) => a*b*c;
            Func<double, double, double, double> fxx = (a,b,c) => a*b*c;

            var beer = new { };
        }
    }
}
