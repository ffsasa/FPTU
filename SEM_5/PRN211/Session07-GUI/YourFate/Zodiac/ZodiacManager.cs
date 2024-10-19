using Service;

namespace Zodiac
{
    //Class form 1 chính là class kế thừa cái class gốc mà Windowns cung cấp để mà render ra cửa sổ tương tác
    //Form là class cha có khả năng render 1 hình chữ nhật - web page để cung cấp mặt sàn
    //Ta lập trình app GUI, app desktop, tức là cái app chạy trên nền desktop, có icon biểu tượng trên thanh taskbar, chính là tạo ra 1 class kế thừa class form
    //EXTENDS trong JAVA thì trong C# nó là dấu :

    public partial class ZodiacManager : Form
    {
        public ZodiacManager()
        {
            InitializeComponent();
        }

        private void ZodiacManager_Load(object sender, EventArgs e)
        {

        }

        private void btnShowImage_Click(object sender, EventArgs e)
        {
            //Đưa ảnh vào ram
            Image img = Image.FromFile(@"signs\hotgirl.jpg");
            //Show ảnh  
            picImage.Image = img;
        }

        private void picImage_Click(object sender, EventArgs e)
        {

        }

        private void pnlImage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to exit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Hàm này trả về giá trị lựa chọn của user YES / NO
            //Giá trị này thuộc data type DialogResult 
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblDay_Click(object sender, EventArgs e)
        {

        }

        private void lblMonth_Click(object sender, EventArgs e)
        {

        }

        private void checkZodiac_Click(object sender, EventArgs e)
        {
            int day = int.Parse(txtDay.Text);
            int month = int.Parse(txtMonth.Text);

            string ZodiacEn = ZodiacCalculator.GetZodiacEnglish(month, day);

            string ZodiacVn = ZodiacCalculator.GetZodiacVietnamese(ZodiacEn);

            string zodiacImage = @"signs\" + ZodiacEn + ".jpg";

            Image img = Image.FromFile(zodiacImage);
            picImage.Image = img;

            lblYourZodiac.Text = "Your zodiac sign is - Cung hoàng đạo của bạn là: " + ZodiacEn + " | " + ZodiacVn;

            //Nhớ validation trước khi làm những cái này, lấy giá trị day month ra tính.
        }

        private void lblTittle_Click(object sender, EventArgs e)
        {

        }

        private void lblCopyright_Click(object sender, EventArgs e)
        {

        }
    }
}
