namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void form(object sender, EventArgs e)
        //{
        //    label1.Text = "Ta";
        //}

        private void label(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int i = 0;
        void Addbtn()
        {
            Random random = new Random();
            Button btn = new Button()
            {
                Text = i.ToString(),
                Location = new Point(random.Next(0, 100), random.Next(0, 100))
            };
            this.Controls.Add(btn);
            i++;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Addbtn();
        }
    }
}
