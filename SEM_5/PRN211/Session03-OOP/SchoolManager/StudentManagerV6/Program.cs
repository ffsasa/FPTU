using StudentManagerV6.Entities;
using System.Security.Cryptography;

namespace StudentManagerV6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            PlayWithAnnonymousTypeV2();
        }

        static void PlayWithAnnonymousTypeV2()
        {
            Student s = new Student() { Id = "SE1", Name = "An", Email = "An@", Yob = 2003, Gpa = 9.9 };
            Student s2 = new () { Id = "SE2", Name = "Bình", Email = "An@", Yob = 2003, Gpa = 9.9 };
            var s3 = new Student() { Id = "SE3", Name = "Cường", Email = "An@", Yob = 2003, Gpa = 9.9 };
            var s4 = new { Id = "QE170035", FullName = "AnTaNgoc"}; //=>Anonymous data type vì không nói rõ khuôn tạo đối tượng
            var s5 = new { s3.Id, s3.Name };

            Console.WriteLine("Check check s4: " + s4);
            Console.WriteLine("Check check s5: " + s5);
        }

        static void PlayWithAnnonymousTypeV1()
        {
            //Muốn lưu thông tin của 1 lon bia bao gồm: Mã vạch, loại bia: Heineken, giá tiền: 23000, Số ml: 330
            //var aBeer = new Beer(){....} => Object initializer

            var aBeer = new { Code = "BA001", Name = "Heineken", Price = 23000, Ml = 330 };

            //Thiếu mỗi tên class, còn lại thì mình truyền data vào qua kĩ thuật object initializer
            //Về lí thuyết, nó chính là class ngầm beer(Coded, Name, Price, Ml) do ta làm biếng tạo sẵn class như vậy. Những vẫn cần có class và property để điền giá trị vào backing field
            //Runtime sẽ ngầm tọa ra 1 class gì đó ứng với các property này, ta khồng cần quan tâm tên class mà chỉ quan tâm vùng new này chứa các cột info đã được điền sẵn value
            //Kĩ thuật này gọi là anonymous data type => Không định nghĩa sẵn cụ thể 1 class - tạo class ngầm
            //Runtime sẽ tự làm giúp mình hàm tostring()

            Console.WriteLine("Print the detail of an object created by using anonymous data type");
            Console.WriteLine(aBeer);

            Console.WriteLine($"{aBeer.Code} | {aBeer.Name} | {aBeer.Price} | {aBeer.Ml}");
        }
    }
}
