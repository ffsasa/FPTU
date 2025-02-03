using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV2.Entities
{
    internal class Student
    {
        private string _id;
        private string _name;   
        private string _email;
        private int _yob;
        private double _gpa;

        //public Student(string id, string name, string email, int yob, double gpa)
        //{
        //    _id = id;
        //    _name = name;
        //    _email = email;
        //    _yob = yob;
        //    _gpa = gpa;
        //}
        //Nếu 1 khuôn không có phễu, không có chổ để đổ vật liệu vào bên trong. Về lí thuyết, ta sẽ có 1 object full of không khí. Khuôn thì rỗng, nếu k đổ sắt đồng thiếc thì bên trong vẫn có không khí lấp đầy. 1 object không khí, 1 object tự có sẵn info, 1 object mang giá trị default
        //Vậy nếu khuông ko có phễu, thì mặc định sdk tool sẽ tự động tạo ra cho bạn 1 cái phếu do-nothings.
        //Lúc thực thi app: public Student() { k cần lenehnj nào bên trong }. Khi đó contrucstor sẽ không làm gì cả, chỉ giúp ta tạo đối tượng rỗng
        //Chuỗi -> rỗng, số -> 0, bool -> false

        //Dù giấu thông tin, nhưng ai hỏi thì vẫn trả lời
        public string GetName() { return _name; }
        public string GetEmail() { return _email; }
        public int GetYob() { return _yob; }
        public double GetGgpa() { return _gpa; }

        public void ShowProfile()
        {
            Console.WriteLine($"{_id} | {_name} | {_email} | {_gpa} | {_yob}");
        }

        //Giả sử object đã được đúc xong, ta có nhu cầu chỉnh sửa nó

        public void SetGpa(double gpa)
        {
            _gpa = gpa;
        }

        public void SetYob(int yob) => _yob = yob;
        
    }
}
