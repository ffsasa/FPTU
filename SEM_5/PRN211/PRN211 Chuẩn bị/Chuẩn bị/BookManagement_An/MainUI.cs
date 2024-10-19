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
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void BookManagerMainUI_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Detail f = new Detail();
            f.ShowDialog();
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        private void dgvBookList_SelectionChanged(object sender, EventArgs e)
        {
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
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }
    }
}
