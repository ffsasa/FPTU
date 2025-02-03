using StudentManagerV2.Service;

namespace StudentManagerV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cabinet seBox = new Cabinet();
            Cabinet bizBox = new Cabinet();

            seBox.AddNewStudent("SE50", "An", "an@...", 2003, 9.9);
            seBox.AddNewStudent("SE34", "Bình", "binh@...", 2003, 7.9);
            
            bizBox.AddNewStudent("SS55", "Cường", "cuong@...", 2003, 7.2);
            bizBox.AddNewStudent("SS21", "Dũng", "dung@...", 2003, 5.6);

            Console.WriteLine("The BIZ students");
            bizBox.PrintStudents();

            Console.WriteLine("The SE students");
            seBox.PrintStudents();
        }
    }
}
