namespace ConveinenceStore_TaNgocAn
{
    partial class ProductDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblAddAndUpdate = new Label();
            txtProductId = new TextBox();
            lblProductId = new Label();
            lblQuantity = new Label();
            lblPrice = new Label();
            lblVendor = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            txtProductName = new TextBox();
            lblProductName = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            lblExpiredDate = new Label();
            grbProductInfo = new GroupBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            dtpExpiredDate = new DateTimePicker();
            cboVendor = new ComboBox();
            dtpManufactureDate = new DateTimePicker();
            lblManufactureDate = new Label();
            grbProductInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblAddAndUpdate
            // 
            lblAddAndUpdate.AutoSize = true;
            lblAddAndUpdate.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddAndUpdate.Location = new Point(12, 3);
            lblAddAndUpdate.Name = "lblAddAndUpdate";
            lblAddAndUpdate.Size = new Size(435, 54);
            lblAddAndUpdate.TabIndex = 1;
            lblAddAndUpdate.Text = "Add | Update product";
            // 
            // txtProductId
            // 
            txtProductId.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductId.Location = new Point(139, 38);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(419, 27);
            txtProductId.TabIndex = 9;
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductId.Location = new Point(11, 41);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(72, 20);
            lblProductId.TabIndex = 8;
            lblProductId.Text = "Product Id";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuantity.Location = new Point(11, 289);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(61, 20);
            lblQuantity.TabIndex = 18;
            lblQuantity.Text = "Quantity";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(344, 289);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(40, 20);
            lblPrice.TabIndex = 20;
            lblPrice.Text = "Price";
            // 
            // lblVendor
            // 
            lblVendor.AutoSize = true;
            lblVendor.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVendor.Location = new Point(11, 343);
            lblVendor.Name = "lblVendor";
            lblVendor.Size = new Size(54, 20);
            lblVendor.TabIndex = 22;
            lblVendor.Text = "Vendor";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(616, 136);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(135, 30);
            btnSave.TabIndex = 24;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(616, 189);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(135, 30);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductName.Location = new Point(139, 80);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(419, 27);
            txtProductName.TabIndex = 27;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductName.Location = new Point(11, 83);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(96, 20);
            lblProductName.TabIndex = 26;
            lblProductName.Text = "Product name";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(139, 122);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(419, 63);
            txtDescription.TabIndex = 29;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(11, 125);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(79, 20);
            lblDescription.TabIndex = 28;
            lblDescription.Text = "Description";
            // 
            // lblExpiredDate
            // 
            lblExpiredDate.AutoSize = true;
            lblExpiredDate.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExpiredDate.Location = new Point(11, 200);
            lblExpiredDate.Name = "lblExpiredDate";
            lblExpiredDate.Size = new Size(88, 20);
            lblExpiredDate.TabIndex = 30;
            lblExpiredDate.Text = "Expired Date";
            // 
            // grbProductInfo
            // 
            grbProductInfo.Controls.Add(dtpManufactureDate);
            grbProductInfo.Controls.Add(lblManufactureDate);
            grbProductInfo.Controls.Add(txtPrice);
            grbProductInfo.Controls.Add(txtQuantity);
            grbProductInfo.Controls.Add(dtpExpiredDate);
            grbProductInfo.Controls.Add(cboVendor);
            grbProductInfo.Controls.Add(lblExpiredDate);
            grbProductInfo.Controls.Add(txtDescription);
            grbProductInfo.Controls.Add(lblDescription);
            grbProductInfo.Controls.Add(txtProductName);
            grbProductInfo.Controls.Add(lblProductName);
            grbProductInfo.Controls.Add(lblVendor);
            grbProductInfo.Controls.Add(lblPrice);
            grbProductInfo.Controls.Add(lblQuantity);
            grbProductInfo.Controls.Add(txtProductId);
            grbProductInfo.Controls.Add(lblProductId);
            grbProductInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grbProductInfo.Location = new Point(32, 63);
            grbProductInfo.Name = "grbProductInfo";
            grbProductInfo.Size = new Size(567, 378);
            grbProductInfo.TabIndex = 34;
            grbProductInfo.TabStop = false;
            grbProductInfo.Text = "Product info";
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(389, 286);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(169, 27);
            txtPrice.TabIndex = 39;
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuantity.Location = new Point(139, 286);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(169, 27);
            txtQuantity.TabIndex = 38;
            // 
            // dtpExpiredDate
            // 
            dtpExpiredDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpExpiredDate.Format = DateTimePickerFormat.Short;
            dtpExpiredDate.Location = new Point(139, 197);
            dtpExpiredDate.Name = "dtpExpiredDate";
            dtpExpiredDate.Size = new Size(150, 27);
            dtpExpiredDate.TabIndex = 37;
            dtpExpiredDate.Value = new DateTime(2024, 3, 21, 0, 0, 0, 0);
            // 
            // cboVendor
            // 
            cboVendor.FormattingEnabled = true;
            cboVendor.Location = new Point(139, 333);
            cboVendor.Name = "cboVendor";
            cboVendor.Size = new Size(141, 36);
            cboVendor.TabIndex = 36;
            // 
            // dtpManufactureDate
            // 
            dtpManufactureDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpManufactureDate.Format = DateTimePickerFormat.Short;
            dtpManufactureDate.Location = new Point(139, 241);
            dtpManufactureDate.Name = "dtpManufactureDate";
            dtpManufactureDate.Size = new Size(150, 27);
            dtpManufactureDate.TabIndex = 41;
            dtpManufactureDate.Value = new DateTime(2024, 3, 21, 0, 0, 0, 0);
            // 
            // lblManufactureDate
            // 
            lblManufactureDate.AutoSize = true;
            lblManufactureDate.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblManufactureDate.Location = new Point(11, 244);
            lblManufactureDate.Name = "lblManufactureDate";
            lblManufactureDate.Size = new Size(120, 20);
            lblManufactureDate.TabIndex = 40;
            lblManufactureDate.Text = "Manufacture Date";
            // 
            // Detail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(grbProductInfo);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblAddAndUpdate);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Detail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Detail";
            Load += ProductDetail_Load;
            grbProductInfo.ResumeLayout(false);
            grbProductInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAddAndUpdate;
        private TextBox txtProductId;
        private Label lblProductId;
        private Label lblQuantity;
        private Label lblPrice;
        private Label lblVendor;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtProductName;
        private Label lblProductName;
        private TextBox txtDescription;
        private Label lblDescription;
        private Label lblExpiredDate;
        private GroupBox grbProductInfo;
        private ComboBox cboVendor;
        private DateTimePicker dtpExpiredDate;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private DateTimePicker dtpManufactureDate;
        private Label lblManufactureDate;
    }
}