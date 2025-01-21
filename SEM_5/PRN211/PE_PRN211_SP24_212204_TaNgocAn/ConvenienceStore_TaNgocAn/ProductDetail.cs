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

namespace ConveinenceStore_TaNgocAn
{
    public partial class ProductDetail : Form
    {
        private ProductService productService = new ProductService();

        private VendorService vendorService = new VendorService();
        public Product _selected { get; set; }
        public ProductDetail()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProductDetail_Load(object sender, EventArgs e)
        {
            cboVendor.DataSource = null;
            cboVendor.DataSource = vendorService.GetVendors();
            cboVendor.DisplayMember = "VendorName";
            cboVendor.ValueMember = "VendorId";
            cboVendor.SelectedValue = 1;

            if (_selected != null)
            {
                lblAddAndUpdate.Text = "Update Selected Product";
                txtProductId.Enabled = false;

                txtProductId.Text = _selected.ProductId.ToString();
                txtProductName.Text = _selected.ProductName;
                dtpExpiredDate.Text = _selected.ExpiredDate.ToString();
                dtpManufactureDate.Text = _selected.ManufactureDate.ToString();
                txtDescription.Text = _selected.Description;
                txtPrice.Text = _selected.Price.ToString();
                txtQuantity.Text = _selected.Quantity.ToString();
                cboVendor.SelectedValue = _selected.VendorId;
            }
            lblAddAndUpdate.Text = "Create A Product";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text.IsNullOrEmpty() || txtProductName.Text.IsNullOrEmpty() || txtDescription.Text.IsNullOrEmpty() || txtPrice.Text.IsNullOrEmpty() || txtQuantity.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Please fill in all information completely", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product product = new Product();
            try
            {

                product.ExpiredDate = DateOnly.Parse(dtpExpiredDate.Text);
                product.Description = txtDescription.Text;
                product.Price = decimal.Parse(txtPrice.Text);
                product.ProductId = int.Parse(txtProductId.Text);
                product.ProductName = txtProductName.Text;
                product.ManufactureDate = DateOnly.Parse(dtpManufactureDate.Text);
                product.Quantity = int.Parse(txtQuantity.Text);
                product.VendorId = int.Parse(cboVendor.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong, check your input again please!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (_selected != null)
            {
                productService.UpdateProduct(product);
                Close();
            }
            else
            {
                try
                {
                    productService.AddProduct(product);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something wrong, may be ProductID is existed", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}

