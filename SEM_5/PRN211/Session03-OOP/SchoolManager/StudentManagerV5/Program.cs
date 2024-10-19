using StudentManagerV5.Entities;

namespace StudentManagerV5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student() { Id = "SE1", Name = "An", Email = "ann@fpt.edu", Yob = 2003, Gpa = 9.9 };  //ĐÂY LÀ KĨ THUẬT OBJECT INITIALIZER

            Console.WriteLine("Check the student info after creating an object");

            s1.ShowProfile();
            s1.ShowAll();
            Console.WriteLine(s1.ToString());

            //Nếu 1 class không có toString ta vẫn gọi được hàm này, do mọi class đều thuộc về class tên là object
            //Và class object thì có sẵn hàm toString, hàm này không làm gì nhiều vì nó không biết class con có info gì. Do đó class object chỉ trả về tên của class con và loại mà class con thuộc về
            //Tức là trả về data type của object đang hỏi toString
            //Bên java thì trả ra địa chỉ, con số hexa tọa độ vùng new

            //Dân java và C# nếu pro thì không ai .ToString hết mà ToString sẽ được gọi ngầm qua tên biến
            Console.WriteLine(s1); // => Gọi thầm toString
        }















        //static void Main(string[] args)
        //{
        //    Student s1 = new Student();
        //    //Cách sử dụng get set vừa học ở bên dưới. Coi các hàm get set như biết, vì khai báo nó giống như 1 biến
        //    s1.Name = "AN"; //Đây chính là set
        //    Console.WriteLine(s1.Name);//Đây chính là get
        //    //Có thêm 1 cách nữa để new object
        //    Student s2 = new Student() {Id="SE1",Name="NT"}; //Create object using property initiation => Tạo object và khởi động gán giá trị cho các đặc tính
        //    Console.WriteLine(s2.Name);
        //}
    }
}
