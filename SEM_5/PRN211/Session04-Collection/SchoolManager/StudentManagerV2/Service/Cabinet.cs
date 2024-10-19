using StudentManagerV2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerV2.Service
{
    internal class Cabinet
    {
        //Tương tự cái tủ đừng hồ sơ ngoài đời
        //Nó có đặc tính, thông tin là: 1 mảng, 1 không gian rộng rãi để cất giữ đồ gì đó
        //Nó sẽ có các hành động: CRUD
        //
        //Tủ cần chỗ chứa đố
        private Student[] _list = new Student[300];
        int _count = 0;
        //tại sao _list nghĩa là backing field mà k chơi property/ẩn backing field chỉ get set
        // Tại sao không Student[] Student {get, set}. Nếu vậy khi set giá trị thì sẽ là .Student = ... NHƯ THẾ NÀY LÀ SET GIÁ TRỊ CHO 1 LÚC 300 HỌC SINH, không sai như méo ai làm thế.
        //Quay về truyền thống. Nhét từ từ add() từng hồ sơ sẽ hợp lý hơn.

        //TƯ DUY THIẾT KẾ KIỂU SOLID
        //S: SIGNLE RESPONSIBILITY - THIẾT KẾ 1 CLASS ĐỪNG LÀM QUÁ NHIỀU VIỆC KHÁC BIỆT
        //Ví dụ ở hàm add chỉ quan tâm đến việc cất hồ sơ vào trong tủ, không quan tấm đến việc hộ sơ như thế nào ghi những gì.
        //Làm riêng phần sử lý ở đây, nhập chỗ khác -> Nguyên lý S
        public void AddNewStudent(String id, String name, String email, int yob, double gpa)
        {
            //add vào vị trí nào trong bảng
            //Cần kiểm tra tràn mảng if
            _list[_count] = new Student() { Id = id, Name = name, Email = email, Gpa = gpa, Yob = yob };
            _count++;
        }

        public void PrintStudents()
        {
            Console.WriteLine($"There is/are {_count} student(s) in the cabinet");
            for(int i = 0; i < _count; i++)
            {
                Console.WriteLine(_list[i]); //Gọi thầm tên em toString().
            }
        }

        //In ra danh sách sinh viên sắp xếp theo thứ tự tăng dần của tên A - Z
        //In ra danh sách sinh viên sắp xếp theo thứ tự tăng dần của năm sinh
        //In ra danh sách sinh viên sắp xếp theo thứ tự giảm dần của điểm
        //Thuật toán Sorting

    }
}
