namespace AnonymousFunc
{
    delegate void PlayNumberDelegate(int number);
    internal class Program
    {
        static void Main(string[] args)
        {
            //Làm hàm mũ 5
            //C1: Viết hàm bình thường, gọi bằng delegate
            //C2: Tạo hàm Anonymous
            //C1:
            PlayNumberDelegate playNumber = Power5Number;
            playNumber(10);
            //C2:
            PlayNumberDelegate playNumber1 = delegate (int number) { Console.WriteLine($"The {number}^5 = {number * number * number * number * number}"); };
            playNumber1(3);

        }

        static void Power5Number(int number) => Console.WriteLine($"The {number}^5 = {number * number * number * number * number}");


        //static void Main(string[] args)
        //    // Tạo 1 hàm nhận vào 1 con số nguyên: Nhưng in ra 4 số
        //    //C1: Tạo hàm in ra 4 số giống hàm in 3 số.
        //    //C2: Dùng AnonymuosFunc: Thiết kế 1 hàm không thèm có tên, chỉ cần đầu vào tuân theo định dạng của Delegate đã khai báo
        //{
        //    PlayNumberDelegate playNumber = CloneNumbersLikeGoldFormat;
        //    playNumber(9);

        //    PlayNumberDelegate Anonymous = delegate (int n) 
        //                                   { 
        //                                       Console.WriteLine($"{n}{n}{n}{n}"); 
        //                                   };
        //                                    //Đem code ngay đây, làm biếng làm hàm rời. Tên hàm không quan trọng, đặt là gì cũng được.
        //                                    //Chữ delegate ở lệnh gán chính là thay cho tên hàm.
        //                                    //Chữ Anonymous chính là nickname thay cho tên thật
        //    Anonymous(4);
        //}


        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Play method with an input and return nothing-void.");
        //    PlayNumberDelegate playNumber = CloneNumbers;
        //    playNumber(5);

        //    Console.WriteLine("In ra bình phương");
        //    playNumber = Power2Number;
        //    playNumber(3);

        //    playNumber += CloneNumbers;
        //    playNumber(6);
        //}

        static void CloneNumbers(int n) => Console.WriteLine($"{n}{n}{n}");

        static void Power2Number(int n) => Console.WriteLine($"The {n}^2 = {n * n}");

        static void CloneNumbersLikeGoldFormat(int n) => Console.WriteLine($"{n}{n}{n}{n}");
    }
}
