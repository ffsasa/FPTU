namespace ServiceV2
{
    public class Cabinet<T>
    {
        private List<T> _list = new List<T>();
        //ArrayList<Student> _list = new ArrayList();
        //Bên java cấm new List() vì nó là abstract/interface

        //Bên C# thì new List() oker vì nó thay thế cho ArrayList, còn lại tương đương java
        //Bên C# có ArrayList nhưng dùng nó không an toàn, phải hiểu rõ mới dùng!!!! 

        //Bỏ món đồ vào List thì Java và C# giống nhau
        //Gọi hành động .Add(item đưa vào)
        //_list.Add(5) nếu muốn add con số vào trong giỏ hàng

        //Không cần _count vì nó tự co giãn, vì vậy được quyền for each
        //Bên Java chúng ta có .Size(). Còn C# chúng ta có .Count {get; } giống .Length của mảng
    }
}
