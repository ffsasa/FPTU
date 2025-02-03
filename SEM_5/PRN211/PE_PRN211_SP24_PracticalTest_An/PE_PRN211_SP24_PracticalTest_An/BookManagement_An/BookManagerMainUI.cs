using Repositories.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BookManagement_An
{
    public partial class BookManagerMainUI : Form
    {
        private BookService BookService = new BookService();

        private Book SelectedBook;
        public BookManagerMainUI()
        {
            InitializeComponent();
        }

        private void BookManagerMainUI_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvBookList.DataSource = null;
            dgvBookList.DataSource = BookService.GetAllBooks();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            BookDetail f = new BookDetail();
            f.ShowDialog();

            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SelectedBook != null)
            {
                BookDetail f = new BookDetail();
                f._selected = SelectedBook;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pleace select a certain book to edit!!", "Select one book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadData();
            SelectedBook = null;
        }

        private void dgvBookList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBookList.SelectedRows.Count > 0)
            {
                SelectedBook = (Book)dgvBookList.SelectedRows[0].DataBoundItem;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Book> list = BookService.GetAllBooks();
            string txtBookNameEqual = txtBookName.Text.ToLower();
            string txtDescriptionEqual = txtBookDescription.Text.ToLower();
            if (txtBookNameEqual != "" || txtDescriptionEqual != "")
            {
                if (txtBookNameEqual != "" && txtDescriptionEqual != "")
                {
                    dgvBookList.DataSource = list.Where(x => x.BookName.ToLower().Contains(txtBookNameEqual) || x.Description.ToLower().Contains(txtDescriptionEqual)).ToList();
                }
                else
                {
                    if (txtBookNameEqual != "")
                        dgvBookList.DataSource = list.Where(x => x.BookName.ToLower().Contains(txtBookNameEqual)).ToList();
                    if (txtDescriptionEqual != "")
                        dgvBookList.DataSource = list.Where(x => x.Description.ToLower().Contains(txtDescriptionEqual)).ToList();
                }
            }
            else
            {
                dgvBookList.DataSource = list.Where(x => x.BookName.ToLower().Contains(txtBookNameEqual) || x.Description.ToLower().Contains(txtDescriptionEqual)).ToList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedBook != null)
            {
                DialogResult result = MessageBox.Show("Do you really want to delete this book?", "Delete a book", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    BookService.DeleteBook(SelectedBook);
                }
            }
            else
            {
                MessageBox.Show("Pleace select a certain book to delete!!", "Select one book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadData();

            SelectedBook = null;
        }
    }
}
