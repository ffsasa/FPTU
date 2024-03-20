using Repositories.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement_TaNgocAn
{
    public partial class BookDetailForm : Form
    {
        public Book SelectedBook { get; set; } = null;
        public BookDetailForm()
        {
            InitializeComponent();
        }

        private void BookDetailForm_Load(object sender, EventArgs e)
        {
            BookCategoryService bookCategoryService = new BookCategoryService();
            //Để full data vào combo
            cboCategory.DataSource = bookCategoryService.GetAllCategories();
            //Chọn cột để hiển thị trên combo
            cboCategory.DisplayMember = "BookGenreType";
            //Chọn cột để lấy value thực sự cần dùng
            cboCategory.ValueMember = "BookCategoryId";
            //Nhảy đến giá trị bất kì 
            cboCategory.SelectedValue = 1;

            if (SelectedBook != null)
            {
                txtBookID.Text = SelectedBook.BookId.ToString();
                txtBookName.Text = SelectedBook.BookName;
                txtDescription.Text = SelectedBook.Description;
                txtAuthor.Text = SelectedBook.Author;
                txtPrice.Text = SelectedBook.Price.ToString();
                txtQuantity.Text = SelectedBook.Quantity.ToString();

                cboCategory.SelectedValue = SelectedBook.BookCategoryId;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
