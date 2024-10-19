namespace DelegateReview
{
    internal class Program
    {
        //Delegate là một class đặc biệt. Thay vì giống như Lecturer, Student để lưu info như các class khác thì Delegate là 1 class chuyên đi lưu trữ tên các hàm theo cùng style nào đó.
        //Ta coi tên hàm là value, cái mà đại diện cho value là Data Type.

        public delegate void NoInputNoOutputDelegate();
        public class Lecturer
        {

        }

        public class Student
        {

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
