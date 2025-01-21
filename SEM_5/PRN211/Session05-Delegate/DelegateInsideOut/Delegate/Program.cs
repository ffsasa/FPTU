namespace DelegateIntro
{
    //Delegate sẽ khai báo ở bên ngoài class khác, và nằm dưới namespace
    //Delegate - Cũng là 1 kiểu dữ liệu Object nhưu Student, Teacher nên nó ngang hàng với 1 class
    //Student, Teacher là kiểu dữ liệu Object, còn delegate thì kiểu dữ liệu của nó là Method, là 1 kiểu hàm.

    //ĐÂY CHÍNH LÀ HÀM KHAI BÁO CLASS VIẾT NGẮN GỌN.
    public delegate void X();
    //Tôi là class X đại diện cho 1 đám hàm ở đâu đó có format: Không đầu vào, không đầu ra.
    //X f = value là tên hàm ở dưới, f là tên gọi khác cho cái hàm ở dưới cùng Style X.
    //X ĐÃ SẴN SÀNG LÀM DATA TYPE NHƯ CÁC STUDENT, TEACHER,...
    internal class Program
    {
        //CHƠI DELEGATE THEO CÁCH NHIỀU HÀM ĐƯỢC NHỒI VÀO BIẾN STYLE X
        static void Main(string[] args)
        {
            X f = new X(TellHer);
            f += NhanEm;
            f += SayHelloToSweetHeart;

            //Gọi 3 hàm cùng lúc
            //1. Gọi lẻ truyền thống TellHer(), NhanEm(), Say...()
            //2. Gọi qua f()
            //3. Gọi qua f.Invoke()
            f();

            //Tại 1 thời điểm f chỉ lưu 1 value, chỉ có thể dùng +=, nếu dùng = nó sẽ lưu value mới
            X f1 =new X(TellHer);
            f1 = NhanEm; 
            f1();

        }





        //static void Main(string[] args)
        //{
        //    X f1 = new X(TellHer);
        //    //f1 là tên gọi khác của TellHer
        //    X f2 = NhanEm;
        //    //Viết tắt, bỏ new cho tự nhiên như Style, giống int, long, ...
        //    //HẾT SỨC LƯU Ý, KHI GÁN BIẾN/NICK NAME CHO 1 HÀM CỤ THỂ NÀO ĐÓ TUYỆT ĐỐI KHÔNG GHI TÊN HÀM KÈM DẤU (). VÌ NẾU () THÌ LÀ RUN HÀM LUÔN RỒI.

        //    TellHer();
        //    //BÂY GIỜ TA KHÔNG GỌI HÀM KIỂU NhanEm() TRUYỀN THỐNG, TA GỌI QUA CON TRỎ HÀM, BIẾN DELEGATE
        //    f2();
        //    //Vì NhanEm = f2 nên NhanEm() = f2()

        //    //Cách thứ 3: gọi hàm bằng Invoke()
        //    Console.WriteLine("Call message by using Invoke()");
        //    f1.Invoke(); 
        //    f2.Invoke();
        //    //X LÀ CLASS CÓ NHIỀU HÀM BÊN TRONG KẾ THỪA TỪ DELEGATE GIỐNG NHƯ STUDENT CÓ TOSTRING.
        //    //
        //}

        static void TellHer() => Console.WriteLine("Cuộc sống em ổn không. Xa anh em phải hạnh phúc!!!");
        static void NhanEm() => Console.WriteLine("Chúc em hạnh phúc bên người!!!");
        static void SayHelloToSweetHeart() => Console.WriteLine("Bánh mì không? Hai ta cùng về một nhà? CHúng ta của tương lai");

        //Còn nhiều hàm nữa trong tương lại ở đây, mà có thể ở Project khác, .DLL khác
        static void HelloWorld() => Console.WriteLine("Hello Delegate");
    }
}
