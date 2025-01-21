namespace ConveinenceStore_TaNgocAn
{
    partial class ConvenienceStoreMainUI
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
            lblConvenienceStore = new Label();
            lblProductName = new Label();
            txtProductName = new TextBox();
            dgvProductList = new DataGridView();
            grbSearch = new GroupBox();
            btnSearch = new Button();
            txtDescription = new TextBox();
            lblDesciption = new Label();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnQuit = new Button();
            lblCopyRight = new Label();
            lblProductList = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductList).BeginInit();
            grbSearch.SuspendLayout();
            SuspendLayout();
            // 
            // lblConvenienceStore
            // 
            lblConvenienceStore.AutoSize = true;
            lblConvenienceStore.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConvenienceStore.Location = new Point(12, 9);
            lblConvenienceStore.Name = "lblConvenienceStore";
            lblConvenienceStore.Size = new Size(372, 54);
            lblConvenienceStore.TabIndex = 0;
            lblConvenienceStore.Text = "Convenience Store";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductName.Location = new Point(34, 60);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(99, 20);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductName.Location = new Point(136, 57);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(146, 27);
            txtProductName.TabIndex = 7;
            // 
            // dgvProductList
            // 
            dgvProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductList.Location = new Point(61, 221);
            dgvProductList.Name = "dgvProductList";
            dgvProductList.RowHeadersWidth = 51;
            dgvProductList.Size = new Size(550, 251);
            dgvProductList.TabIndex = 9;
            dgvProductList.SelectionChanged += dgvProductList_SelectionChanged;
            // 
            // grbSearch
            // 
            grbSearch.Controls.Add(btnSearch);
            grbSearch.Controls.Add(txtDescription);
            grbSearch.Controls.Add(lblDesciption);
            grbSearch.Controls.Add(txtProductName);
            grbSearch.Controls.Add(lblProductName);
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
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(435, 57);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(146, 27);
            txtDescription.TabIndex = 9;
            // 
            // lblDesciption
            // 
            lblDesciption.AutoSize = true;
            lblDesciption.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDesciption.Location = new Point(354, 60);
            lblDesciption.Name = "lblDesciption";
            lblDesciption.Size = new Size(79, 20);
            lblDesciption.TabIndex = 8;
            lblDesciption.Text = "Description";
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
            // lblProductList
            // 
            lblProductList.AutoSize = true;
            lblProductList.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductList.Location = new Point(43, 189);
            lblProductList.Name = "lblProductList";
            lblProductList.Size = new Size(121, 28);
            lblProductList.TabIndex = 11;
            lblProductList.Text = "Product list";
            // 
            // MainUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(855, 508);
            ControlBox = false;
            Controls.Add(lblProductList);
            Controls.Add(lblCopyRight);
            Controls.Add(btnQuit);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(grbSearch);
            Controls.Add(dgvProductList);
            Controls.Add(lblConvenienceStore);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Convenience Store MainUI";
            Load += ConvenienceStoreMainUI_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductList).EndInit();
            grbSearch.ResumeLayout(false);
            grbSearch.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConvenienceStore;
        private Label lblProductName;
        private Label label5;
        private Label label6;
        private TextBox txtProductName;
        private DataGridView dgvProductList;
        private GroupBox grbSearch;
        private Button btnSearch;
        private TextBox txtDescription;
        private Label lblDesciption;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnQuit;
        private Label lblCopyRight;
        private Label lblProductList;
    }
}