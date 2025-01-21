namespace LambdaExpression
{
    delegate void PlayNumberDelegate(int x);
    delegate void PlayDelegate();
    //C1. làm hàm thực tế sau đó sử dụng delegate để gọi
    //C2. làm hàm ẩn danh - anonymous
    //C3. từ cách 2 cắt bớt code dư thừa (code khá giống expression body)
    internal class Program
    {
        static void Main(string[] args)
        {
            //C1: TƯỜNG MINH
            PlayNumberDelegate playNumber = MakeTriple;
            playNumber(3);
            //C2: ANONYMOUS
            playNumber = delegate (int n) { Console.WriteLine($"{n}{n}{n}"); };
            playNumber(4);
            //C3: LAMBDA. ANONYMOUS RÚT GỌN THÀNH LAMBDA
            playNumber = (int n) => { Console.WriteLine($"{n}{n}{n}"); };
            playNumber(5);
            //C3: LAMBDA. ANONYMOUS RÚT GỌN THÀNH LAMBDA SIÊU MỎNG
            playNumber = (n) => { Console.WriteLine($"{n}{n}{n}"); }; //playNumber có khuôn mẫu rồi, chỉ cần tên đầu vào, và làm gì với nó.
            playNumber(6);
            //C3: LAMBDA. ANONYMOUS RÚT GỌN THÀNH LAMBDA SUPER
            playNumber = n => { Console.WriteLine($"{n}{n}{n}"); }; //playNumber có khuôn mẫu rồi, chỉ cần tên đầu vào, và làm gì với nó.
            playNumber(7);

            PlayDelegate f = () =>
            {
                int sum =0;
                for (int i = 1; i <= 10; i++)
                {
                    if (i % 2 == 0)
                        sum+= i;
                }
                Console.WriteLine("The sum of even numbers from 1...10: " + sum);
            };

            f();
        }

        //Làm hàm thực tế
        static void MakeTriple(int n) => Console.WriteLine($"{n}{n}{n}");
    }
}
