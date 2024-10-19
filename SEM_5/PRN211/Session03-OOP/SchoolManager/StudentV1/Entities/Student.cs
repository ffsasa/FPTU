using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentV1.Entities
{//Class chính là cái khuôn, bên trong chứa các place holder ứng với các đặc điểm của mỗi object thuộc về nhóm/class này
    //Để có đc 1 sản phẩm tuwfk huông clone ra objecct, ta cần phải đúc - hành động đổ vật liệu vào trong khuôn
    internal class Student
    {
        private string _id; //Cú pháp con lạc đà, và _ ở đầu từ.
        private string _name;
        private string _email;
        private int _yob;
        private double _gpa;

        public Student(string id, string name, string email, int yob, double gpa)
        {
            _id = id;
            _name = name;
            _email = email;
            _yob = yob;
            _gpa = gpa;
        }

        //Tạo phễu để hứng vật liệu đổ vào khuôn. Giống hứng các data đưa vào place holder
        //Hàm dùng để hứng data bên ngoài đổ và đặc điểm của object, place holder, hàm này gọi là constructor dùng để construct/create/clone object
        // Ctrl . tạo phễu

        //Để lấy về và thiết lập thông tin info đã được private là get và set

        public string GetId() => _id;
        public string GetName() => _name;
        public int GetYob() => _yob;
        public double GetGpa() => _gpa;

        public void ShowProfile()
        {
            Console.WriteLine(@$"Here is my info:
Id: {_id}
Name: {_name}
Yob: {_yob}
Gpa: {_gpa}
Email: {_email}");
        }
    }
}
