using StudentV1.Entities;

namespace StudentV1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           CreateAStudentObjectV1();
        }

        static void CreateAStudentObjectV1()
        {//tạo mới 1 object sinh viên, 1 sv cụ thê, 1 thing complex, style truyền thống
            //Con người luôn có xu hướng đặt tên cho mọi thứ quanh họ, sau khi đã mô tả chúng
            Student an = new Student("QE170035", "AnTN", "antnqe170035@fpt.edu.vn", 2003, 9.9);
            //an -> biến object
            //new student(...) là 1 thing cụ thể, thứ phức tạp
            an.ShowProfile();
        }

        static void CreateAStudentObjectV2()
        {//tạo mopiws 1 object sinh viên, 1 sv cụ thê, 1 thing complex, style truyền thống
            //Con người luôn có xu hướng đặt tên cho mọi thứ quanh họ, sau khi đã mô tả chúng
            var an1 = new Student("QE1700351", "AnTN1", "antnqe170035@fpt.edu.vn1", 2003, 9.9);
            //an -> biến object
            //new student(...) là 1 thing cụ thể, thứ phức tạp
            an1.ShowProfile();
        }

        static void CreateAStudentObjectV3()
        {//tạo mopiws 1 object sinh viên, 1 sv cụ thê, 1 thing complex, style truyền thống
            //Con người luôn có xu hướng đặt tên cho mọi thứ quanh họ, sau khi đã mô tả chúng
            Student an = new (yob: 2003,id: "QE170035",name: "AnTN",email: "antnqe170035@fpt.edu.vn",gpa: 9.9); //Đây là cách name argument
            //an -> biến object
            //new student(...) là 1 thing cụ thể, thứ phức tạp
            an.ShowProfile();
        }
    }
}
