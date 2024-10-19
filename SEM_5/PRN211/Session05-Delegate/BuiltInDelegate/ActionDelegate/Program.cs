namespace ActionDelegate
{
    //Challenge 1: Viết hàm in ra câu thông báo: Nam Em đã ra viện rồi!
    //             Viết theo Style truyền thống.
    //Challenge 2: Viết hàm in ra câu thông báo: Nam Em và 35 triệu
    //             Dùng delegate và anonymous function
    //Challenge 3: Viết hàm in ra câu thông báo: 8/3/2024: Chúng ta của tương lai
    //             Dùng delegate và lambda
    //Challenge 4: hàm 1 sử dụng delegate

    //Sử dụng delegate của MICROSOFT. NoInputNoOutput = Action
    
    //Challenge 5: Viết hàm in ra câu thông báo: "8/3/2024": Chúng ta của tương lai | SƠN TÙNG M-TP vs HẢI TÚ 
    delegate void NoInputNoOutputDelegate();
    internal class Program
    {
        static void Main(string[] args)
        {
            Action f3 = () => Console.WriteLine("\"8/3/2024\": Chúng ta của tương lai | SƠN TÙNG M-TP vs HẢI TÚ");
            f3();
        }






        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Challenge 1!");
        //    ShowNotification();

        //    NoInputNoOutputDelegate f = delegate () { Console.WriteLine("Nam Em và 35 triệu\n"); };
        //    f();

        //    NoInputNoOutputDelegate f2 = () => Console.WriteLine("8/3/2024: Chúng ta của tương lai\n"); 
        //    f2();

        //    NoInputNoOutputDelegate f3 = ShowNotification;
        //    f3();
        //}

        static void ShowNotification() => Console.WriteLine("2/3/2023: Nam Em đã ra viện.\n");
    }
}
