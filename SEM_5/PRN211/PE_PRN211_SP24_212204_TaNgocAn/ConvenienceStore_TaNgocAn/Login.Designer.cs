namespace ConvenienceStore_TaNgocAn
{
    partial class Login
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
            lblSignIn = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            btnSignIn = new Button();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnCancel = new Button();
            grbAccountInfo = new GroupBox();
            grbAccountInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblSignIn
            // 
            lblSignIn.AutoSize = true;
            lblSignIn.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblSignIn.Location = new Point(222, 37);
            lblSignIn.Name = "lblSignIn";
            lblSignIn.Size = new Size(153, 54);
            lblSignIn.TabIndex = 0;
            lblSignIn.Text = "Sign In";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblEmail.Location = new Point(27, 43);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(73, 31);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            lblPassword.Location = new Point(27, 139);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(114, 31);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // btnSignIn
            // 
            btnSignIn.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnSignIn.Location = new Point(61, 261);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(114, 36);
            btnSignIn.TabIndex = 2;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10.8F);
            txtEmail.Location = new Point(27, 84);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(331, 31);
            txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10.8F);
            txtPassword.Location = new Point(27, 178);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(331, 31);
            txtPassword.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnCancel.Location = new Point(207, 261);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(114, 36);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // grbAccountInfo
            // 
            grbAccountInfo.Controls.Add(btnCancel);
            grbAccountInfo.Controls.Add(btnSignIn);
            grbAccountInfo.Controls.Add(txtPassword);
            grbAccountInfo.Controls.Add(txtEmail);
            grbAccountInfo.Controls.Add(lblPassword);
            grbAccountInfo.Controls.Add(lblEmail);
            grbAccountInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grbAccountInfo.Location = new Point(110, 108);
            grbAccountInfo.Name = "grbAccountInfo";
            grbAccountInfo.Size = new Size(384, 316);
            grbAccountInfo.TabIndex = 4;
            grbAccountInfo.TabStop = false;
            grbAccountInfo.Text = "Account Info";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(618, 501);
            ControlBox = false;
            Controls.Add(grbAccountInfo);
            Controls.Add(lblSignIn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            grbAccountInfo.ResumeLayout(false);
            grbAccountInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSignIn;
        private Label lblEmail;
        private Label lblPassword;
        private Button btnSignIn;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnCancel;
        private GroupBox grbAccountInfo;
    }
}