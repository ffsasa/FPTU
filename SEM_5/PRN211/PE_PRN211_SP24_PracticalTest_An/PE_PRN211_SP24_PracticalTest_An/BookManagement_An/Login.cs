using BookManagement_An;
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

namespace BookManagement_TaNgocAn
{
    public partial class Login : Form
    {
        UserAccountService UserAccountService = new UserAccountService();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) ||string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please input your info", "Null or Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UserAccount userAccount = UserAccountService.GetUserAccounts(txtEmail.Text, txtPassword.Text);
            if (userAccount == null)
            {
                MessageBox.Show("Email or Password is invalid", "Invalid Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (userAccount.Role == 1)
                {
                    BookManagerMainUI f = new BookManagerMainUI();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Your account does not have access rights.", "Can't Access", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
