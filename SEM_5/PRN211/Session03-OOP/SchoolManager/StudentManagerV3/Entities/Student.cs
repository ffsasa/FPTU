using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV3.Entities
{
    internal class Student
    {
        private string _id;
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

        //constructor có tham số
        //Để tạo riêng constructor default/empty ta có thể chủ động tạo ra nó bằng các gõ phím ctor + tab
        public Student()
        {
            
        }

    }
}
