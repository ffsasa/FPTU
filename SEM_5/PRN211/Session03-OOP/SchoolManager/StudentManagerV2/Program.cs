using StudentManagerV2.Entities;

namespace StudentManagerV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            //Toàn bộ info bên trong object không được đổ gì cả
            s1.ShowProfile();
            s1.SetGpa(8.9);
            Console.WriteLine("After upgrading the gpa: ");
            s1.ShowProfile();
        }
    }
}
