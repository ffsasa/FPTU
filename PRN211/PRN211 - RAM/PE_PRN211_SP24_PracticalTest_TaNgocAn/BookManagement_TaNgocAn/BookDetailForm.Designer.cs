namespace BookManagement_TaNgocAn
{
    partial class BookDetailForm
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
            btnSave = new Button();
            grbBookInfo = new GroupBox();
            cboCategory = new ComboBox();
            dtpPublicationDate = new DateTimePicker();
            txtPrice = new TextBox();
            txtAuthor = new TextBox();
            txtDescription = new TextBox();
            txtBookName = new TextBox();
            lblPrice = new Label();
            lblCategory = new Label();
            lblAuthor = new Label();
            lblQuantity = new Label();
            lblPublicationDate = new Label();
            lblBookName = new Label();
            txtBookID = new TextBox();
            txtQuantity = new TextBox();
            lblBookDescription = new Label();
            lblBookID = new Label();
            lblHeader = new Label();
            btnCancel = new Button();
            grbBookInfo.SuspendLayout();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Red;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnSave.ForeColor = Color.Yellow;
            btnSave.Location = new Point(897, 177);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(194, 43);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // grbBookInfo
            // 
            grbBookInfo.Controls.Add(cboCategory);
            grbBookInfo.Controls.Add(dtpPublicationDate);
            grbBookInfo.Controls.Add(txtPrice);
            grbBookInfo.Controls.Add(txtAuthor);
            grbBookInfo.Controls.Add(txtDescription);
            grbBookInfo.Controls.Add(txtBookName);
            grbBookInfo.Controls.Add(lblPrice);
            grbBookInfo.Controls.Add(lblCategory);
            grbBookInfo.Controls.Add(lblAuthor);
            grbBookInfo.Controls.Add(lblQuantity);
            grbBookInfo.Controls.Add(lblPublicationDate);
            grbBookInfo.Controls.Add(lblBookName);
            grbBookInfo.Controls.Add(txtBookID);
            grbBookInfo.Controls.Add(txtQuantity);
            grbBookInfo.Controls.Add(lblBookDescription);
            grbBookInfo.Controls.Add(lblBookID);
            grbBookInfo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            grbBookInfo.ForeColor = Color.Yellow;
            grbBookInfo.Location = new Point(32, 128);
            grbBookInfo.Name = "grbBookInfo";
            grbBookInfo.Size = new Size(846, 560);
            grbBookInfo.TabIndex = 0;
            grbBookInfo.TabStop = false;
            grbBookInfo.Text = "Book info ";
            // 
            // cboCategory
            // 
            cboCategory.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            cboCategory.FormattingEnabled = true;
            cboCategory.Location = new Point(258, 470);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(181, 33);
            cboCategory.TabIndex = 7;
            // 
            // dtpPublicationDate
            // 
            dtpPublicationDate.Format = DateTimePickerFormat.Short;
            dtpPublicationDate.Location = new Point(258, 314);
            dtpPublicationDate.Name = "dtpPublicationDate";
            dtpPublicationDate.Size = new Size(205, 38);
            dtpPublicationDate.TabIndex = 3;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(658, 365);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(147, 38);
            txtPrice.TabIndex = 5;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(258, 418);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(547, 38);
            txtAuthor.TabIndex = 6;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(258, 166);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(547, 131);
            txtDescription.TabIndex = 2;
            // 
            // txtBookName
            // 
            txtBookName.Location = new Point(258, 110);
            txtBookName.Name = "txtBookName";
            txtBookName.Size = new Size(547, 38);
            txtBookName.TabIndex = 1;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrice.ForeColor = Color.Yellow;
            lblPrice.Location = new Point(575, 372);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(67, 31);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "Price";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblCategory.ForeColor = Color.Yellow;
            lblCategory.Location = new Point(34, 473);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(111, 31);
            lblCategory.TabIndex = 8;
            lblCategory.Text = "Category";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblAuthor.ForeColor = Color.Yellow;
            lblAuthor.Location = new Point(34, 425);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(90, 31);
            lblAuthor.TabIndex = 7;
            lblAuthor.Text = "Author";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblQuantity.ForeColor = Color.Yellow;
            lblQuantity.Location = new Point(34, 372);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(108, 31);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "Quantity";
            // 
            // lblPublicationDate
            // 
            lblPublicationDate.AutoSize = true;
            lblPublicationDate.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblPublicationDate.ForeColor = Color.Yellow;
            lblPublicationDate.Location = new Point(34, 321);
            lblPublicationDate.Name = "lblPublicationDate";
            lblPublicationDate.Size = new Size(193, 31);
            lblPublicationDate.TabIndex = 5;
            lblPublicationDate.Text = "Publication Date";
            // 
            // lblBookName
            // 
            lblBookName.AutoSize = true;
            lblBookName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblBookName.ForeColor = Color.Yellow;
            lblBookName.Location = new Point(34, 113);
            lblBookName.Name = "lblBookName";
            lblBookName.Size = new Size(139, 31);
            lblBookName.TabIndex = 4;
            lblBookName.Text = "Book Name";
            // 
            // txtBookID
            // 
            txtBookID.Location = new Point(258, 52);
            txtBookID.Name = "txtBookID";
            txtBookID.Size = new Size(547, 38);
            txtBookID.TabIndex = 0;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(258, 365);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(147, 38);
            txtQuantity.TabIndex = 4;
            // 
            // lblBookDescription
            // 
            lblBookDescription.AutoSize = true;
            lblBookDescription.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblBookDescription.ForeColor = Color.Yellow;
            lblBookDescription.Location = new Point(34, 169);
            lblBookDescription.Name = "lblBookDescription";
            lblBookDescription.Size = new Size(138, 31);
            lblBookDescription.TabIndex = 1;
            lblBookDescription.Text = "Description";
            // 
            // lblBookID
            // 
            lblBookID.AutoSize = true;
            lblBookID.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblBookID.ForeColor = Color.Yellow;
            lblBookID.Location = new Point(34, 55);
            lblBookID.Name = "lblBookID";
            lblBookID.Size = new Size(100, 31);
            lblBookID.TabIndex = 3;
            lblBookID.Text = "Book ID";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.Yellow;
            lblHeader.Location = new Point(12, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(826, 106);
            lblHeader.TabIndex = 15;
            lblHeader.Text = "Add | Update a book";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.Yellow;
            btnCancel.Location = new Point(897, 241);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(194, 43);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // BookDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(1118, 737);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(grbBookInfo);
            Controls.Add(lblHeader);
            Name = "BookDetailForm";
            Text = "Add | Update a book";
            Load += BookDetailForm_Load;
            grbBookInfo.ResumeLayout(false);
            grbBookInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private GroupBox grbBookInfo;
        private TextBox txtPrice;
        private TextBox txtAuthor;
        private TextBox txtDescription;
        private TextBox txtBookName;
        private Label lblPrice;
        private Label lblCategory;
        private Label lblAuthor;
        private Label lblQuantity;
        private Label lblPublicationDate;
        private Label lblBookName;
        private TextBox txtBookID;
        private TextBox txtQuantity;
        private Label lblBookDescription;
        private Label lblBookID;
        private Label lblHeader;
        private ComboBox cboCategory;
        private DateTimePicker dtpPublicationDate;
        private Button btnCancel;
    }
}