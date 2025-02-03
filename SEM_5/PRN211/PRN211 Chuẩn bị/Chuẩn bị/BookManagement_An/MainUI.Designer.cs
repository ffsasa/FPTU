namespace BookManagement_An
{
    partial class MainUI
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
            lblBookManager = new Label();
            lblBookName = new Label();
            txtBookName = new TextBox();
            dgvBookList = new DataGridView();
            grbSearch = new GroupBox();
            btnSearch = new Button();
            txtBookDescription = new TextBox();
            lblBookDesciption = new Label();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnQuit = new Button();
            lblCopyRight = new Label();
            lblBookList = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBookList).BeginInit();
            grbSearch.SuspendLayout();
            SuspendLayout();
            // 
            // lblBookManager
            // 
            lblBookManager.AutoSize = true;
            lblBookManager.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookManager.Location = new Point(12, 9);
            lblBookManager.Name = "lblBookManager";
            lblBookManager.Size = new Size(299, 54);
            lblBookManager.TabIndex = 0;
            lblBookManager.Text = "Book Manager";
            // 
            // lblBookName
            // 
            lblBookName.AutoSize = true;
            lblBookName.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookName.Location = new Point(54, 60);
            lblBookName.Name = "lblBookName";
            lblBookName.Size = new Size(79, 20);
            lblBookName.TabIndex = 1;
            lblBookName.Text = "Book name";
            // 
            // txtBookName
            // 
            txtBookName.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBookName.Location = new Point(136, 57);
            txtBookName.Name = "txtBookName";
            txtBookName.Size = new Size(146, 27);
            txtBookName.TabIndex = 7;
            // 
            // dgvBookList
            // 
            dgvBookList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookList.Location = new Point(61, 221);
            dgvBookList.Name = "dgvBookList";
            dgvBookList.RowHeadersWidth = 51;
            dgvBookList.Size = new Size(550, 251);
            dgvBookList.TabIndex = 9;
            dgvBookList.SelectionChanged += dgvBookList_SelectionChanged;
            // 
            // grbSearch
            // 
            grbSearch.Controls.Add(btnSearch);
            grbSearch.Controls.Add(txtBookDescription);
            grbSearch.Controls.Add(lblBookDesciption);
            grbSearch.Controls.Add(txtBookName);
            grbSearch.Controls.Add(lblBookName);
            grbSearch.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grbSearch.Location = new Point(43, 81);
            grbSearch.Name = "grbSearch";
            grbSearch.Size = new Size(757, 107);
            grbSearch.TabIndex = 10;
            grbSearch.TabStop = false;
            grbSearch.Text = " Search ";
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(605, 54);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(135, 30);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtBookDescription
            // 
            txtBookDescription.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBookDescription.Location = new Point(435, 57);
            txtBookDescription.Name = "txtBookDescription";
            txtBookDescription.Size = new Size(146, 27);
            txtBookDescription.TabIndex = 9;
            // 
            // lblBookDesciption
            // 
            lblBookDesciption.AutoSize = true;
            lblBookDesciption.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBookDesciption.Location = new Point(320, 60);
            lblBookDesciption.Name = "lblBookDesciption";
            lblBookDesciption.Size = new Size(112, 20);
            lblBookDesciption.TabIndex = 8;
            lblBookDesciption.Text = "Book description";
            // 
            // btnCreate
            // 
            btnCreate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreate.Location = new Point(648, 244);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(135, 30);
            btnCreate.TabIndex = 11;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(648, 305);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(135, 30);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(648, 365);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 30);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnQuit
            // 
            btnQuit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuit.Location = new Point(648, 427);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(135, 30);
            btnQuit.TabIndex = 14;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuit_Click;
            // 
            // lblCopyRight
            // 
            lblCopyRight.AutoSize = true;
            lblCopyRight.Font = new Font("Arial", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCopyRight.Location = new Point(12, 482);
            lblCopyRight.Name = "lblCopyRight";
            lblCopyRight.Size = new Size(156, 16);
            lblCopyRight.TabIndex = 11;
            lblCopyRight.Text = "CopyRight by Ta Ngoc An";
            // 
            // lblBookList
            // 
            lblBookList.AutoSize = true;
            lblBookList.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookList.Location = new Point(43, 189);
            lblBookList.Name = "lblBookList";
            lblBookList.Size = new Size(95, 28);
            lblBookList.TabIndex = 11;
            lblBookList.Text = "Book list";
            // 
            // MainUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 508);
            ControlBox = false;
            Controls.Add(lblBookList);
            Controls.Add(lblCopyRight);
            Controls.Add(btnQuit);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(grbSearch);
            Controls.Add(dgvBookList);
            Controls.Add(lblBookManager);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookManagerMainUI";
            Load += BookManagerMainUI_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBookList).EndInit();
            grbSearch.ResumeLayout(false);
            grbSearch.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBookManager;
        private Label lblBookName;
        private Label label5;
        private Label label6;
        private TextBox txtBookName;
        private DataGridView dgvBookList;
        private GroupBox grbSearch;
        private Button btnSearch;
        private TextBox txtBookDescription;
        private Label lblBookDesciption;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnQuit;
        private Label lblCopyRight;
        private Label lblBookList;
    }
}