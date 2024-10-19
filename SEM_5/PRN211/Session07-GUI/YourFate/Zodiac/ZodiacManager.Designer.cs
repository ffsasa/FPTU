namespace Zodiac
{
    partial class ZodiacManager
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
            lblWelcome = new Label();
            btnShowImage = new Button();
            picImage = new PictureBox();
            pnlImage = new Panel();
            btnCheckZodiac = new Button();
            btnExit = new Button();
            lblDay = new Label();
            lblMonth = new Label();
            lblYourZodiac = new Label();
            txtDay = new TextBox();
            txtMonth = new TextBox();
            lblCopyright = new Label();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            pnlImage.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = Color.Red;
            lblWelcome.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lblWelcome.Location = new Point(13, 9);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.RightToLeft = RightToLeft.No;
            lblWelcome.Size = new Size(721, 106);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = " Zodiac Calculator";
            lblWelcome.Click += lblTittle_Click;
            // 
            // btnShowImage
            // 
            btnShowImage.AutoSize = true;
            btnShowImage.Cursor = Cursors.Hand;
            btnShowImage.FlatStyle = FlatStyle.Flat;
            btnShowImage.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnShowImage.ForeColor = Color.Yellow;
            btnShowImage.Location = new Point(222, 381);
            btnShowImage.Name = "btnShowImage";
            btnShowImage.Size = new Size(136, 36);
            btnShowImage.TabIndex = 3;
            btnShowImage.Text = "Show Image";
            btnShowImage.UseVisualStyleBackColor = true;
            btnShowImage.Click += btnShowImage_Click;
            // 
            // picImage
            // 
            picImage.BackColor = Color.Lime;
            picImage.Location = new Point(25, 13);
            picImage.Name = "picImage";
            picImage.Size = new Size(300, 400);
            picImage.SizeMode = PictureBoxSizeMode.AutoSize;
            picImage.TabIndex = 2;
            picImage.TabStop = false;
            picImage.Click += picImage_Click;
            // 
            // pnlImage
            // 
            pnlImage.AutoScroll = true;
            pnlImage.BackColor = Color.FromArgb(255, 128, 255);
            pnlImage.Controls.Add(picImage);
            pnlImage.Location = new Point(628, 118);
            pnlImage.Name = "pnlImage";
            pnlImage.Size = new Size(349, 427);
            pnlImage.TabIndex = 3;
            pnlImage.Paint += pnlImage_Paint;
            // 
            // btnCheckZodiac
            // 
            btnCheckZodiac.AutoSize = true;
            btnCheckZodiac.Cursor = Cursors.Hand;
            btnCheckZodiac.FlatStyle = FlatStyle.Flat;
            btnCheckZodiac.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCheckZodiac.ForeColor = Color.Yellow;
            btnCheckZodiac.Location = new Point(45, 381);
            btnCheckZodiac.Name = "btnCheckZodiac";
            btnCheckZodiac.Size = new Size(149, 36);
            btnCheckZodiac.TabIndex = 2;
            btnCheckZodiac.Text = "Check Zodiac";
            btnCheckZodiac.UseVisualStyleBackColor = true;
            btnCheckZodiac.Click += checkZodiac_Click;
            // 
            // btnExit
            // 
            btnExit.AutoSize = true;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.Yellow;
            btnExit.Location = new Point(386, 381);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(136, 36);
            btnExit.TabIndex = 4;
            btnExit.Text = "Quit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.BackColor = Color.Red;
            lblDay.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblDay.Location = new Point(45, 225);
            lblDay.Margin = new Padding(4, 0, 4, 0);
            lblDay.Name = "lblDay";
            lblDay.RightToLeft = RightToLeft.No;
            lblDay.Size = new Size(167, 31);
            lblDay.TabIndex = 6;
            lblDay.Text = "Your birth day";
            lblDay.Click += lblDay_Click;
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.BackColor = Color.Red;
            lblMonth.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblMonth.Location = new Point(45, 312);
            lblMonth.Margin = new Padding(4, 0, 4, 0);
            lblMonth.Name = "lblMonth";
            lblMonth.RightToLeft = RightToLeft.No;
            lblMonth.Size = new Size(201, 31);
            lblMonth.TabIndex = 7;
            lblMonth.Text = "Your birth month";
            lblMonth.Click += lblMonth_Click;
            // 
            // lblYourZodiac
            // 
            lblYourZodiac.AutoSize = true;
            lblYourZodiac.BackColor = Color.Red;
            lblYourZodiac.Font = new Font("Segoe UI", 19.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblYourZodiac.Location = new Point(28, 567);
            lblYourZodiac.Margin = new Padding(4, 0, 4, 0);
            lblYourZodiac.Name = "lblYourZodiac";
            lblYourZodiac.RightToLeft = RightToLeft.No;
            lblYourZodiac.Size = new Size(335, 45);
            lblYourZodiac.TabIndex = 8;
            lblYourZodiac.Text = "Your zodiac sign is ...";
            // 
            // txtDay
            // 
            txtDay.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtDay.Location = new Point(263, 225);
            txtDay.Name = "txtDay";
            txtDay.Size = new Size(125, 34);
            txtDay.TabIndex = 0;
            txtDay.Text = "1";
            // 
            // txtMonth
            // 
            txtMonth.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtMonth.Location = new Point(263, 312);
            txtMonth.Name = "txtMonth";
            txtMonth.Size = new Size(125, 34);
            txtMonth.TabIndex = 1;
            txtMonth.Text = "1";
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.BackColor = Color.Red;
            lblCopyright.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblCopyright.Location = new Point(13, 639);
            lblCopyright.Margin = new Padding(4, 0, 4, 0);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.RightToLeft = RightToLeft.No;
            lblCopyright.Size = new Size(66, 22);
            lblCopyright.TabIndex = 9;
            lblCopyright.Text = "@ffsasa";
            lblCopyright.Click += lblCopyright_Click;
            // 
            // ZodiacManager
            // 
            AutoScaleDimensions = new SizeF(12F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(1137, 670);
            Controls.Add(lblCopyright);
            Controls.Add(txtMonth);
            Controls.Add(txtDay);
            Controls.Add(lblYourZodiac);
            Controls.Add(lblMonth);
            Controls.Add(lblDay);
            Controls.Add(btnExit);
            Controls.Add(btnCheckZodiac);
            Controls.Add(pnlImage);
            Controls.Add(btnShowImage);
            Controls.Add(lblWelcome);
            Cursor = Cursors.No;
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = Color.Yellow;
            Margin = new Padding(4);
            Name = "ZodiacManager";
            Text = "Welcom to Zodiac Calculator";
            Load += ZodiacManager_Load;
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            pnlImage.ResumeLayout(false);
            pnlImage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnShowImage;
        private PictureBox picImage;
        private Panel pnlImage;
        private Button btnCheckZodiac;
        private Button btnExit;
        private Label lblDay;
        private Label lblMonth;
        private Label lblYourZodiac;
        private TextBox txtDay;
        private TextBox txtMonth;
        private Label lblCopyright;
    }
}
