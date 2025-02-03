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

namespace ConveinenceStore_TaNgocAn
{
    public partial class ConvenienceStoreMainUI : Form
    {
        private ProductService productService = new ProductService();

        public Product SelectedProduct;
        public ConvenienceStoreMainUI()
        {
            InitializeComponent();
        }

        private void ConvenienceStoreMainUI_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvProductList.DataSource = null;
            dgvProductList.DataSource = productService.GetProducts();
        }

        private void dgvProductList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductList.SelectedRows.Count > 0)
            {
                SelectedProduct = (Product)dgvProductList.SelectedRows[0].DataBoundItem;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ProductDetail f = new ProductDetail();
            f.ShowDialog();
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (SelectedProduct != null)
            {
                ProductDetail f = new ProductDetail();
                f._selected = SelectedProduct;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pleace select a certain product to edit!!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadData();
            SelectedProduct = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedProduct != null)
            {
                DialogResult result = MessageBox.Show("Do you really want to delete this product?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    productService.DeleteProduct(SelectedProduct);
                }
            }
            else
            {
                MessageBox.Show("Pleace select a certain product to delete!!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadData();

            SelectedProduct = null;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Product> list = productService.GetProducts();
            string txtProductNameEqual = txtProductName.Text.ToLower();
            string txtDescriptionEqual = txtDescription.Text.ToLower();
            if (txtProductNameEqual != "" || txtDescriptionEqual != "")
            {
                if (txtProductNameEqual != "" && txtDescriptionEqual != "")
                {
                    dgvProductList.DataSource = list.Where(x => x.ProductName.ToLower().Contains(txtProductNameEqual) || x.Description.ToLower().Contains(txtDescriptionEqual)).ToList();
                }
                else
                {
                    if (txtProductNameEqual != "")
                        dgvProductList.DataSource = list.Where(x => x.ProductName.ToLower().Contains(txtProductNameEqual)).ToList();
                    if (txtDescriptionEqual != "")
                        dgvProductList.DataSource = list.Where(x => x.Description.ToLower().Contains(txtDescriptionEqual)).ToList();
                }
            }
            else
            {
                dgvProductList.DataSource = list.Where(x => x.ProductName.ToLower().Contains(txtProductNameEqual) || x.Description.ToLower().Contains(txtDescriptionEqual)).ToList();
            }
        }
    }
}



