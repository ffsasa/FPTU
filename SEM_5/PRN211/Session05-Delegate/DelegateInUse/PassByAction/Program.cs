namespace PassByAction
{
    //Viết hàm thầu các hành động nào đó bên ngoài đưa vào
    //Hàm thầu các dịch vụ in ấn nào đó: in bài hát, in số,...
    internal class Program
    {
        static void Main(string[] args)
        {
            DoOnDemand(() => { Console.WriteLine("Chúng ta của tương lai!"); });
        }

        static void DoOnDemand(Action f)
        {
            Console.WriteLine("Do - While - For...");
            f(); //Call back
        }
    }
}
