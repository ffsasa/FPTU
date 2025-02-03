using Repositories.Entities;
using Service;

namespace BookManagement_TaNgocAn
{
    public partial class BookManagerMainUI : Form
    {
        private Book _selected = null;
        public BookManagerMainUI()
        {
            InitializeComponent();
        }
        private void BookManagerMainUI_Load(object sender, EventArgs e)
        {
            BookService bookService = new BookService();
            dgvBookList.DataSource = null;
            dgvBookList.DataSource = bookService.GetAllBooks();
        }

        private void dgvBookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
                Application.Exit();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            BookDetailForm f = new BookDetailForm();
            f.ShowDialog();
        }

        private void dgvBookList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBookList.SelectedRows.Count > 0)
            {
                _selected = (Book)dgvBookList.SelectedRows[0].DataBoundItem;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selected != null)
            {
                BookDetailForm f = new BookDetailForm();
                f.SelectedBook = _selected;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pleace select a certain book to edit!!", "Select one book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Book> list = new BookService().GetAllBooks();
            dgvBookList.DataSource = list.Where(x => x.BookName.ToLower().Contains(txtName.Text.ToLower()) ||
                                                     x.Description.ToLower().Contains(txtDescription.Text.ToLower())
                                                     ).ToList();
        }
    }
}
