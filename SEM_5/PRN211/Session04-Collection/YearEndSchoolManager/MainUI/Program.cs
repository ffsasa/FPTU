using Repositories.Entities; //Bắc cầu: MainUI xài Service. Service xài Repo => MainUI xài Repo
using Services;

namespace MainUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ta có thể tọa được n cái tủ khác nhau, chứa đa dạng object bên trong
            //1 tủ chứa 2 hồ sơ sv SE
            //1 tủ chứa 1 hồ sơ sv Biz
            //1 tủ chứa 2 hồ sơ gv SE

            Cabinet<Student> seBox = new Cabinet<Student>();
            Cabinet<Student> bizBox = new Cabinet<Student>();

            Cabinet<Lecturer> seLecBox = new Cabinet<Lecturer>();
            //3 vùng ram riêng biệt, mỗi vùng 300 hồ sơ có sẵn
            seBox.AddItem(new Student() { Id="SE170035", Name="An", Gpa=9.9});
            seBox.AddItem(new Student() { Id="SE170125", Name="Bình", Gpa=5.6});

            bizBox.AddItem(new Student() { Id="SE170321", Name="Cường", Gpa=7.9});

            seLecBox.AddItem(new Lecturer() { Id="0000001", Name="Dũng"});
            seLecBox.AddItem(new Lecturer() { Id="0000002", Name="Em"});

            Console.WriteLine("SE students (2)");
            seBox.PrintObject();

            Console.WriteLine("Biz students (1)");
            bizBox.PrintObject();

            Console.WriteLine("SE lecturers (2)");
            seLecBox.PrintObject();
        }
    }
}
