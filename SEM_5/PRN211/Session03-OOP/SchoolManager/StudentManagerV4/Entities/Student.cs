using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV4.Entities
{
    internal class Student
    {
        private string _id;
        private string _name;
        private string _email;
        private int _yob;
        private double _gpa;

        //Câu truyện của get và set
        //public string GetName() { return _name; }
        //public void SetName(string name) { _name = name; }

        //public string GetEmail() { return _email; }
        //public void SetEmail(string email) { _email = email; }

        //GetX() và SetX bản chất là đang thao tác trên X cho nên C# đưa ra cách viết gộp, quy 2 hàm về chung 1 tên gọi X. X thay thế = Name, Email, Yob tùy căp jđặc điểm mình muốn làm get set.

        public int Yob
        {
            get { return _yob; }
            set { _yob = value; }
        }

        public double Gpa
        {
            get => _gpa;
            set => _gpa = value;
        }
        //Kĩ thuật viết get set kiểu này gọi là full-proprety vì nói gọi đầy đủ tên hàm get set và 1 field để lưu info get set
        //Field được gọi tên mới là: backing field, em chống lưng cho get và set
        //Nếu lỡ quên cú pháp gõ: Propfull + tab + tab
    }
}
