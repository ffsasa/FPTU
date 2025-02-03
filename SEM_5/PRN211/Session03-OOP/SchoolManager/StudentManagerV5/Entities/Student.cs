using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV5.Entities
{
    internal class Student
    {
        //Kĩ thuật auto-implement property
        public string Id { get; set; } //ĐƯợc gọi tên mới là property
        public string Name { get; set; } //Đặc điểm của 1 object trong tương lai được đúc
        public string Email { get; set; } //Ngẫm phía sau có _field tương ứng để store
        public int Yob { get; set; }
        public double Gpa { get; set; }
        //K nhớ cú pháp thì gõ prop + tab
        //Khi biên dịch, sdk tự chèn _ tương ứng ở hậu trường
        //Kĩ thuật viết code kiểu này gọi là auto-implemented property
        //Java không có cách này 1 cách chính thức mà phải xài thư viện của bên thứ 3 - lombok dependency 

        //Create object using object initializers

        public void ShowAll() => Console.WriteLine("{0} | {1} | {2} | {3} | {4}", Id, Name, Yob, Email, Gpa);
        public void ShowProfile() => Console.WriteLine($"{Id} | {Name} | {Yob} | {Email} | {Gpa}");

        //Java: Hàm con trùng tên hàm của Cha => @Override
        //C#: @Override và @New
        public override string ToString() => $"{Id} | {Name} | {Yob} | {Email} | {Gpa}";
    }
}

//Công thức chuẩn để làm class
//1. Tạo class - danh từ riêng - tên chung cho 1 nhóm object tương đồng

//2. Khai báo các đặc điểm - property của 1 object class
// - Dùng truyền thống như java
// - Dùng fullprop (Tự gen ra _backing field rõ ràng luôn)
// - Dùng auto-implemented prop (prop tab tab, tự gen ngầm backing field)

//3. Tạo constructor có tham số, không tham số (empty) hoặc cả 2, hoặc không tạo cái phễu nào. Nếu không tạo ctor, phễu thì mặc định runtime sẽ tạo giúp 1 cái default/empty, đảm bảo lúc nào cũng new được

//4. Tạo hàm get/set (truyền thống java), dùng prop thì không cần

//5. Tạo hàm show hầu hết/ toàn bộ info, showall(), showprofile(). Khuyến cáo nên đặt tên hàm này cho chuẩn, và nên trả về giá trị thay vì in trực tiếp, đó là hàm tostring()

//toStrung() là têm hàm chuẩn cho mọi class, được oop khuyến cáo

//6. Tạo các hàm còn lại, bất kì, dùng để xử lí info nào đó trong object được đổ info vào qua constructor hay objefct initializer