using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement_An
{
    public partial class BookDetail : Form
    {
        public Book _selected { get; set; }

        private BookCategoryService bookCategoryService = new BookCategoryService();

        private BookService bookService = new BookService();
        public BookDetail()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BookDetail_Load(object sender, EventArgs e)
        {
            cboBookCategory.DataSource = null;
            cboBookCategory.DataSource = bookCategoryService.GetBookCategories();
            cboBookCategory.DisplayMember = "BookGenreType";
            cboBookCategory.ValueMember = "BookCategoryId";
            cboBookCategory.SelectedValue = 1;

            if (_selected != null)
            {
                lblAddAndUpdate.Text = "Update Selected Book";
                txtBookId.Enabled = false;

                txtBookId.Text = _selected.BookId.ToString();
                txtBookName.Text = _selected.BookName;
                txtAuthor.Text = _selected.Author;
                txtDescription.Text = _selected.Description;
                dtpPublicationDate.Text = _selected.PublicationDate.ToString();
                txtPrice.Text = _selected.Price.ToString();
                txtQuantity.Text = _selected.Quantity.ToString();
                cboBookCategory.SelectedValue = _selected.BookCategoryId;
            }
            lblAddAndUpdate.Text = "Create A Book";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookId.Text.IsNullOrEmpty() || txtBookName.Text.IsNullOrEmpty() || txtAuthor.Text.IsNullOrEmpty() || txtDescription.Text.IsNullOrEmpty() || txtPrice.Text.IsNullOrEmpty() || txtQuantity.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Please fill in all information completely", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Book book = new Book();
            book.BookId = int.Parse(txtBookId.Text);
            book.BookName = txtBookName.Text;
            book.Author = txtAuthor.Text;
            book.Description = txtDescription.Text;
            book.Price = double.Parse(txtPrice.Text);
            book.BookCategoryId = int.Parse(cboBookCategory.SelectedValue.ToString());
            book.Quantity = int.Parse(txtQuantity.Text);
            book.PublicationDate = dtpPublicationDate.Value;

            if (_selected != null)
            {
                bookService.UpdateBook(book);
                Close();
            }
            else
            {

                try
                {
                    bookService.AddBook(book);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something wrong, may be BookID is existed", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
