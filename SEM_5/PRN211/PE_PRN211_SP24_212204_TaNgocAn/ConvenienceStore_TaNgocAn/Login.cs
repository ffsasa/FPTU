using ConveinenceStore_TaNgocAn;
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

namespace ConvenienceStore_TaNgocAn
{
    public partial class Login : Form
    {
        private StoreAccountService storeAccountService = new StoreAccountService();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please input your info", "Null or Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StoreAccount storeAccount = storeAccountService.GetStoreAccount(txtEmail.Text, txtPassword.Text);
            if (storeAccount == null)
            {
                MessageBox.Show("Email or Password is invalid", "Invalid Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (storeAccount.Role == 1)
                {
                    ConvenienceStoreMainUI f = new ConvenienceStoreMainUI();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Your account does not have access rights.", "SignIn", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
