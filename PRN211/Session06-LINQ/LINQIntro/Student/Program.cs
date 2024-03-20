namespace Student
{
    //Ta có danh sách sinh viên
    //In toàn bộ sv, ta in sv ở tỉnh này, ta in sv có điểm GPA >= 8
    //Có 2 cách thực hiện: Phụ thuộc hoàn toàn vào hàm bên ngoài. Cách 2 hàm bên ngoài chỉ là filter lọc ra, còn làm gì là do mình

    internal class Program
    {
        static List<Student> students = new List<Student>() { new Student() { id = 2, name = "An", age = 3 }, 
                                                       new Student() { id = 3, name = "Bình", age = 5 }, 
                                                       new Student() { id = 4, name = "Cường", age = 6 } 
                                                      };
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            PlayWithStudent( s => s.age>3 );
        }

        public static void PlayWithStudent(Predicate<Student> f)
        {
            foreach(Student x in students)
                if (f(x))
                    Console.WriteLine(x);
        }
    }

    internal class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Age: {age}";
        }
    }
}
