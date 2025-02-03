using Repositories.Entities;

namespace Services
{
    public class Cabinet<T> 
        //Cái tủ truyền thống có nhiều không gian lưu trữ chính là mảng của gì đó: SV, GV,....
        //Mảng CRUD
        //T: type nào đó bạn muốn dùng
        //Ví dụ Cabinet<Student> box = new Cabinet<Student>()
        //Ví dụ Cabinet<Lecturer> box = new Cabinet<Lecturer>()
        //Coi Data type là tham số, hàm hoặc class nhận vào 1 tham số mà là datatype
        //Class thiết kế tổng quát với nhiều loại data type
    {
        //private Student[] _list1 = new Student[300];
        //private int _count1 = 0;

        //private Lecturer[] _list2 = new Lecturer[300];
        //private int _count2 = 0;

        private T[] _list = new T[300];
        private int _count = 0;
        public void AddItem(T item) //T có thể là student, lecturer, food, beer,...
        {
            //Chơi với mảng: Phải kiểm tra xem mảng đã full chưa
            if (_count < 300)
            {
                //add vào vị trí thứ [count]
                _list[_count] = item;
                _count++;
            }
        }

        public void PrintObject()
        {
            Console.WriteLine($"There is/are {_count} item(s) in the list");
            for(int i = 0; i < _count; i++)
            {
                Console.WriteLine(_list[i] );
            }
        }

    }
}
