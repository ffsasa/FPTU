using StudentManager.Entity;

namespace StudentManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PlayWithValueTypeArrayV2();
            PlayWithReferenceTypeArray();
        }
        //Java: xét về cách biến được lưu trong ram thì có 2 loại datatype: Primitive data type(tốn 1 vùng ram), Object data type(tốn 2 vùng ram: 1 vùng cho biến con trỏ, 1 vùng ram bự cho việc new, lưu object)
        //Bên C# gần y chang


        //Tôi muốn lưu trữ danh sách các sinh viên - mỗi sinh viên nào đó chính là 1 object được tạo ra từ khuôn Student
        //Muốn lưu nhiều SV, cần nhiều biến Sv và nhiều new SV()
        static void PlayWithReferenceTypeArray()
        {
            Student s1 = new Student { };
            Student s2 = new Student { };
            //Đây là object nên cần 2 vùng ram
            //Tên gọi biến    và      value

            //Nhiều sv cần nhiều biết và nhiều new
            //Chơi mảng, thì new mảng là 1 chuyện khác so với new Student()
            //New mảng hay new từng Student

            Student[] arr = new Student[30];
            arr[0] = new Student { };
            arr[1] = new Student { Id = "SE10", Name = "An", Email = "an@....", Yob = 2003, Gpa = 9.9 };
            arr[2] = new Student { Id = "SE50", Name = "Bình", Email = "binh@....", Yob = 2003, Gpa = 5.9 };
            arr[3] = new Student { Id = "SE30", Name = "Dũng", Email = "dung@....", Yob = 2003, Gpa = 9.6 };
            arr[4] = new Student { Id = "SE33", Name = "Cường", Email = "cuong@....", Yob = 2003, Gpa = 3.6 };

            //for i hoặc for each , chỉ cần nhớ mỗi phần từ mảng là biến thuộc loại nào
            foreach (Student student in arr) { Console.WriteLine($"{student} "); }

            //for i sẽ for đến chỗ nào mình thích
            //for earch thì sẽ for toàn bộ mảng, khô máu
            //thường thì sẽ có biến count để đếm xem có bao nhiêu biến đã được gán value để for i
        }


        static void PlayWithValueTypeArrayV2()
        {
            int[] a = new int[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };

            //CÓ ƯU VÀ NHƯƠC VS MỖI CÁCH KHAI BÁO
            //V2 NHANH GỌN NHƯNG SỐ PHẦN TỪ LÀ FIX CHỈ 10
            //V1 DÀI HƠN NHƯNG ĐƯỢC CHỌN TẠO 1000 PHẦN TỪ TÙY Ý
            Console.WriteLine("The array is printed by using traditional for");
            for (int i = 0; i < a.Length; i++)
            {
                //Console.WriteLine(a[i]);
                //Console.Write(a[i] + " ");
                //Console.Write("{0} ", a[i]);
                Console.Write($"{a[i]} ");
            }

            Console.WriteLine(@"

The array is printed by using tranditional for each");
            foreach (int i in a) { Console.Write("{0} ", i); }
            Console.WriteLine(@"

");
            foreach (var i in a) { Console.Write("{0} ", i); }
        }


        static void PlayWithValueTypeArrayV1()
        {
            //Bài toán: tôi cần lưu trữ 10 con số nguyên của trò chơi 5 10 15 ...
            //Tính tổng giúp tôi 10 con số này
            //TRẢ LỜI
            //ANSWER 1: Dùng biến lẻ, khai báo biến lẻ, từng miếng
            //ANSWER 2: Dùng biến sỉ, khai báo biến sỉ, mua 1 lốc

            int a1 = 5, a2 = 10, a3 = 15, a4 = 20, a5 = 25, b = 30, c = 35, d = 40, e = 45, f = 50;
            int sum = a1 + a2 + a3 + a4 + a5 + b + c + d + e + f;

            int[] a = new int[100];
            //Có 10 biến đã được tạo ra
            // a[0] a[1] a[2] ...
            //  a1   a2   a3  ...
            //Gán giá trị
            a[0] = 5;
            a[1] = 10;
            a[2] = 15;
            a[3] = 20;
            a[4] = 25;
            a[5] = 30;

            //Ta có quyền xài for cho mảng.

            Console.WriteLine("The array has values of");
            Console.WriteLine(a[0] + " " + a[1] + " " + a[2] + " " + a[3] + " " + a[4] + " " + a[5] + " " + a[6] + " " + a[7] + " " + a[8] + " " + a[9]);
            //Không hiệu quả, chẳng khác gì truyền thống.
            Console.WriteLine("The array is printed by using traditional for");
            for (int i = 0; i <= a.Length; i++)
            {
                //Console.WriteLine(a[i]);
                //Console.Write(a[i] + " ");
                //Console.Write("{0} ", a[i]);
                Console.Write($"{a[i]} ");
            }
        }
    }
}
