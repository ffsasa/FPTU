namespace StudentManager.Entity
{
    internal class Student
    {
        public String Id { get; set; } //Backing field sẽ tự động tạo ra khi Compile/Run
        public String Name { get; set; } //_name, _id, _yob, _email, _gpa
        public String Email { get; set; } //Prop sẽ che giúp qua 2 hàm get và set
        public int Yob { get; set; }
        public double Gpa { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Email} {Yob} {Gpa}";
        }


    }
}
