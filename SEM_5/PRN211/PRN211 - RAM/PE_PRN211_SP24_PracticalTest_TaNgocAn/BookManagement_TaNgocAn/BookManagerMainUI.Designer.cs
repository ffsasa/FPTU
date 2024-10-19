namespace BookManagement_TaNgocAn
{
    partial class BookManagerMainUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lblHeader = new Label();
            grbSearchCriteria = new GroupBox();
            btnSearch = new Button();
            txtDescription = new TextBox();
            txtName = new TextBox();
            lblBookDescription = new Label();
            lblBookName = new Label();
            lblCopyright = new Label();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnExit = new Button();
            dgvBookList = new DataGridView();
            lblBookList = new Label();
            grbSearchCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookList).BeginInit();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.Yellow;
            lblHeader.Location = new Point(12, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(597, 106);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Book Manager";
            // 
            // grbSearchCriteria
            // 
            grbSearchCriteria.Controls.Add(btnSearch);
            grbSearchCriteria.Controls.Add(txtDescription);
            grbSearchCriteria.Controls.Add(txtName);
            grbSearchCriteria.Controls.Add(lblBookDescription);
            grbSearchCriteria.Controls.Add(lblBookName);
            grbSearchCriteria.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            grbSearchCriteria.ForeColor = Color.Yellow;
            grbSearchCriteria.Location = new Point(47, 128);
            grbSearchCriteria.Name = "grbSearchCriteria";
            grbSearchCriteria.Size = new Size(910, 121);
            grbSearchCriteria.TabIndex = 0;
            grbSearchCriteria.TabStop = false;
            grbSearchCriteria.Text = " Search Criteria ";
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.BackColor = Color.Red;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(747, 55);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(140, 43);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(563, 55);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(147, 38);
            txtDescription.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(179, 55);
            txtName.Name = "txtName";
            txtName.Size = new Size(147, 38);
            txtName.TabIndex = 0;
            // 
            // lblBookDescription
            // 
            lblBookDescription.AutoSize = true;
            lblBookDescription.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblBookDescription.ForeColor = Color.Yellow;
            lblBookDescription.Location = new Point(357, 55);
            lblBookDescription.Name = "lblBookDescription";
            lblBookDescription.Size = new Size(200, 31);
            lblBookDescription.TabIndex = 1;
            lblBookDescription.Text = "Book Description";
            // 
            // lblBookName
            // 
            lblBookName.AutoSize = true;
            lblBookName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblBookName.ForeColor = Color.Yellow;
            lblBookName.Location = new Point(34, 55);
            lblBookName.Name = "lblBookName";
            lblBookName.Size = new Size(139, 31);
            lblBookName.TabIndex = 3;
            lblBookName.Text = "Book Name";
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblCopyright.ForeColor = Color.Yellow;
            lblCopyright.Location = new Point(12, 534);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(72, 23);
            lblCopyright.TabIndex = 4;
            lblCopyright.Text = "Ⓒffsasa";
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.Red;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreate.ForeColor = Color.Yellow;
            btnCreate.Location = new Point(736, 308);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(221, 43);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Create a book";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Red;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.Yellow;
            btnUpdate.Location = new Point(736, 357);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(221, 43);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update a book";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.Yellow;
            btnDelete.Location = new Point(736, 406);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(221, 43);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete a book";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Red;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.Yellow;
            btnExit.Location = new Point(736, 455);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(221, 43);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // dgvBookList
            // 
            dgvBookList.CausesValidation = false;
            dgvBookList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvBookList.DefaultCellStyle = dataGridViewCellStyle1;
            dgvBookList.Location = new Point(47, 295);
            dgvBookList.Name = "dgvBookList";
            dgvBookList.RowHeadersWidth = 51;
            dgvBookList.RowTemplate.Height = 29;
            dgvBookList.Size = new Size(641, 215);
            dgvBookList.TabIndex = 0;
            dgvBookList.CellContentClick += dgvBookList_CellContentClick;
            dgvBookList.SelectionChanged += dgvBookList_SelectionChanged;
            // 
            // lblBookList
            // 
            lblBookList.AutoSize = true;
            lblBookList.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblBookList.ForeColor = Color.Yellow;
            lblBookList.Location = new Point(47, 262);
            lblBookList.Name = "lblBookList";
            lblBookList.Size = new Size(112, 31);
            lblBookList.TabIndex = 12;
            lblBookList.Text = "Book List";
            // 
            // BookManagerMainUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(1010, 574);
            Controls.Add(lblBookList);
            Controls.Add(dgvBookList);
            Controls.Add(btnExit);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(lblCopyright);
            Controls.Add(grbSearchCriteria);
            Controls.Add(lblHeader);
            ForeColor = Color.Black;
            Name = "BookManagerMainUI";
            Text = "BookManager";
            Load += BookManagerMainUI_Load;
            grbSearchCriteria.ResumeLayout(false);
            grbSearchCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeader;
        private GroupBox grbSearchCriteria;
        private Label lblBookDescription;
        private Label lblBookName;
        private Label lblCopyright;
        private TextBox txtDescription;
        private TextBox txtName;
        private Button btnSearch;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnExit;
        private DataGridView dgvBookList;
        private Label lblBookList;
    }
}
