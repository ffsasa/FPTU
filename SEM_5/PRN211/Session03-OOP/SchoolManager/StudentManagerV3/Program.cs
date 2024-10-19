using StudentManagerV3.Entities;

namespace StudentManagerV3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            //Tool sẽ tự động xổ ra số lượng constructor tương ứng để bạn chọn để đúc object. Đưa đúng tham số mà các constructor đang có.

            //Nếu class đã có sẵn các ctor có tham số thì sdk không tự động tọa thêm ctor rỗng, nếu muốn thì chủ động tọa ctor rỗng = ctor + tab
            //=> Ctor được chủ động tạo explicit, còn nếu không được tạo chủ động mà ngấm ngầm bằng sdk -> implicit
            //1 class luôn luôn phải có constructor

            //Ngoài đười có nhiều các để đúc info
            //name(*):_________
            //email(*):_________
            //yob:_________
            //address:___________
        }
    }
}
