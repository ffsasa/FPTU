namespace BookManagement_An
{
    partial class BookDetail
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
            txtBookId = new TextBox();
            lblBookId = new Label();
            lblQuantity = new Label();
            lblPrice = new Label();
            lblBookCategory = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            txtBookName = new TextBox();
            lblBookName = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            lblPublicationDate = new Label();
            txtAuthor = new TextBox();
            lblAuthor = new Label();
            grbBookInfo = new GroupBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            dtpPublicationDate = new DateTimePicker();
            cboBookCategory = new ComboBox();
            grbBookInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblAddAndUpdate
            // 
            lblAddAndUpdate.AutoSize = true;
            lblAddAndUpdate.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddAndUpdate.Location = new Point(12, 3);
            lblAddAndUpdate.Name = "lblAddAndUpdate";
            lblAddAndUpdate.Size = new Size(381, 54);
            lblAddAndUpdate.TabIndex = 1;
            lblAddAndUpdate.Text = "Add | Update book";
            // 
            // txtBookId
            // 
            txtBookId.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBookId.Location = new Point(128, 38);
            txtBookId.Name = "txtBookId";
            txtBookId.Size = new Size(419, 27);
            txtBookId.TabIndex = 9;
            // 
            // lblBookId
            // 
            lblBookId.AutoSize = true;
            lblBookId.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookId.Location = new Point(11, 41);
            lblBookId.Name = "lblBookId";
            lblBookId.Size = new Size(55, 20);
            lblBookId.TabIndex = 8;
            lblBookId.Text = "Book Id";
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
            lblPrice.Location = new Point(333, 289);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(40, 20);
            lblPrice.TabIndex = 20;
            lblPrice.Text = "Price";
            // 
            // lblBookCategory
            // 
            lblBookCategory.AutoSize = true;
            lblBookCategory.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookCategory.Location = new Point(11, 343);
            lblBookCategory.Name = "lblBookCategory";
            lblBookCategory.Size = new Size(101, 20);
            lblBookCategory.TabIndex = 22;
            lblBookCategory.Text = "Book Category";
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
            // txtBookName
            // 
            txtBookName.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBookName.Location = new Point(128, 80);
            txtBookName.Name = "txtBookName";
            txtBookName.Size = new Size(419, 27);
            txtBookName.TabIndex = 27;
            // 
            // lblBookName
            // 
            lblBookName.AutoSize = true;
            lblBookName.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookName.Location = new Point(11, 83);
            lblBookName.Name = "lblBookName";
            lblBookName.Size = new Size(79, 20);
            lblBookName.TabIndex = 26;
            lblBookName.Text = "Book name";
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(128, 122);
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
            // lblPublicationDate
            // 
            lblPublicationDate.AutoSize = true;
            lblPublicationDate.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPublicationDate.Location = new Point(11, 200);
            lblPublicationDate.Name = "lblPublicationDate";
            lblPublicationDate.Size = new Size(109, 20);
            lblPublicationDate.TabIndex = 30;
            lblPublicationDate.Text = "Publication Date";
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAuthor.Location = new Point(128, 237);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(419, 27);
            txtAuthor.TabIndex = 33;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuthor.Location = new Point(11, 240);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(51, 20);
            lblAuthor.TabIndex = 32;
            lblAuthor.Text = "Author";
            // 
            // grbBookInfo
            // 
            grbBookInfo.Controls.Add(txtPrice);
            grbBookInfo.Controls.Add(txtQuantity);
            grbBookInfo.Controls.Add(dtpPublicationDate);
            grbBookInfo.Controls.Add(cboBookCategory);
            grbBookInfo.Controls.Add(txtAuthor);
            grbBookInfo.Controls.Add(lblAuthor);
            grbBookInfo.Controls.Add(lblPublicationDate);
            grbBookInfo.Controls.Add(txtDescription);
            grbBookInfo.Controls.Add(lblDescription);
            grbBookInfo.Controls.Add(txtBookName);
            grbBookInfo.Controls.Add(lblBookName);
            grbBookInfo.Controls.Add(lblBookCategory);
            grbBookInfo.Controls.Add(lblPrice);
            grbBookInfo.Controls.Add(lblQuantity);
            grbBookInfo.Controls.Add(txtBookId);
            grbBookInfo.Controls.Add(lblBookId);
            grbBookInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grbBookInfo.Location = new Point(32, 63);
            grbBookInfo.Name = "grbBookInfo";
            grbBookInfo.Size = new Size(567, 378);
            grbBookInfo.TabIndex = 34;
            grbBookInfo.TabStop = false;
            grbBookInfo.Text = "Book info";
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrice.Location = new Point(378, 286);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(169, 27);
            txtPrice.TabIndex = 39;
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuantity.Location = new Point(128, 286);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(169, 27);
            txtQuantity.TabIndex = 38;
            // 
            // dtpPublicationDate
            // 
            dtpPublicationDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpPublicationDate.Format = DateTimePickerFormat.Short;
            dtpPublicationDate.Location = new Point(128, 197);
            dtpPublicationDate.Name = "dtpPublicationDate";
            dtpPublicationDate.Size = new Size(150, 27);
            dtpPublicationDate.TabIndex = 37;
            dtpPublicationDate.Value = new DateTime(2024, 3, 21, 0, 0, 0, 0);
            // 
            // cboBookCategory
            // 
            cboBookCategory.FormattingEnabled = true;
            cboBookCategory.Location = new Point(128, 333);
            cboBookCategory.Name = "cboBookCategory";
            cboBookCategory.Size = new Size(141, 36);
            cboBookCategory.TabIndex = 36;
            // 
            // BookDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grbBookInfo);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblAddAndUpdate);
            Name = "BookDetail";
            Text = "BookDetail";
            Load += BookDetail_Load;
            grbBookInfo.ResumeLayout(false);
            grbBookInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAddAndUpdate;
        private TextBox txtBookId;
        private Label lblBookId;
        private Label lblQuantity;
        private Label lblPrice;
        private Label lblBookCategory;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtBookName;
        private Label lblBookName;
        private TextBox txtDescription;
        private Label lblDescription;
        private Label lblPublicationDate;
        private TextBox txtAuthor;
        private Label lblAuthor;
        private GroupBox grbBookInfo;
        private ComboBox cboBookCategory;
        private DateTimePicker dtpPublicationDate;
        private TextBox txtPrice;
        private TextBox txtQuantity;
    }
}