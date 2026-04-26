namespace Project_Angile
{
    partial class FormDangKy
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkHienMatKhau = new System.Windows.Forms.CheckBox();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.txtHovaTen = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.lblHovaTen = new System.Windows.Forms.Label();
            this.lblDangKy = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.cbbGender = new System.Windows.Forms.ComboBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.Controls.Add(this.lblClass);
            this.panel1.Controls.Add(this.cbbGender);
            this.panel1.Controls.Add(this.txtClass);
            this.panel1.Controls.Add(this.lblGender);
            this.panel1.Controls.Add(this.chkHienMatKhau);
            this.panel1.Controls.Add(this.btnDangKy);
            this.panel1.Controls.Add(this.txtMatKhau);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtMSSV);
            this.panel1.Controls.Add(this.txtHovaTen);
            this.panel1.Controls.Add(this.lblMatKhau);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.lblMSSV);
            this.panel1.Controls.Add(this.lblHovaTen);
            this.panel1.Controls.Add(this.lblDangKy);
            this.panel1.Location = new System.Drawing.Point(29, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 652);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chkHienMatKhau
            // 
            this.chkHienMatKhau.AutoSize = true;
            this.chkHienMatKhau.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHienMatKhau.Location = new System.Drawing.Point(352, 481);
            this.chkHienMatKhau.Margin = new System.Windows.Forms.Padding(2);
            this.chkHienMatKhau.Name = "chkHienMatKhau";
            this.chkHienMatKhau.Size = new System.Drawing.Size(116, 21);
            this.chkHienMatKhau.TabIndex = 6;
            this.chkHienMatKhau.Text = "Hiện mật khẩu";
            this.chkHienMatKhau.UseVisualStyleBackColor = true;
            this.chkHienMatKhau.CheckedChanged += new System.EventHandler(this.chkHienMatKhau_CheckedChanged);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDangKy.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDangKy.Location = new System.Drawing.Point(275, 525);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(2);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(193, 44);
            this.btnDangKy.TabIndex = 4;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(339, 271);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(2);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(308, 34);
            this.txtMatKhau.TabIndex = 3;
            this.txtMatKhau.TextChanged += new System.EventHandler(this.txtMatKhau_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(339, 222);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(308, 34);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtMSSV
            // 
            this.txtMSSV.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMSSV.Location = new System.Drawing.Point(339, 167);
            this.txtMSSV.Margin = new System.Windows.Forms.Padding(2);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(308, 34);
            this.txtMSSV.TabIndex = 3;
            this.txtMSSV.TextChanged += new System.EventHandler(this.txtMSSV_TextChanged);
            // 
            // txtHovaTen
            // 
            this.txtHovaTen.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHovaTen.Location = new System.Drawing.Point(339, 113);
            this.txtHovaTen.Margin = new System.Windows.Forms.Padding(2);
            this.txtHovaTen.Name = "txtHovaTen";
            this.txtHovaTen.Size = new System.Drawing.Size(308, 34);
            this.txtHovaTen.TabIndex = 3;
            this.txtHovaTen.TextChanged += new System.EventHandler(this.txtTenDangNhap_TextChanged);
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhau.Location = new System.Drawing.Point(12, 269);
            this.lblMatKhau.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(128, 31);
            this.lblMatKhau.TabIndex = 2;
            this.lblMatKhau.Text = "Mật khẩu";
            this.lblMatKhau.Click += new System.EventHandler(this.lblMatKhau_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(12, 220);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(84, 31);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email";
            this.lblEmail.Click += new System.EventHandler(this.lblEmail_Click);
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSSV.Location = new System.Drawing.Point(12, 164);
            this.lblMSSV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(197, 31);
            this.lblMSSV.TabIndex = 1;
            this.lblMSSV.Text = "Mã số sinh viên";
            this.lblMSSV.Click += new System.EventHandler(this.lblMSSV_Click);
            // 
            // lblHovaTen
            // 
            this.lblHovaTen.AutoSize = true;
            this.lblHovaTen.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHovaTen.Location = new System.Drawing.Point(12, 111);
            this.lblHovaTen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHovaTen.Name = "lblHovaTen";
            this.lblHovaTen.Size = new System.Drawing.Size(136, 31);
            this.lblHovaTen.TabIndex = 1;
            this.lblHovaTen.Text = "Họ và Tên";
            this.lblHovaTen.Click += new System.EventHandler(this.lblHovaTen_Click);
            // 
            // lblDangKy
            // 
            this.lblDangKy.AutoSize = true;
            this.lblDangKy.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDangKy.Location = new System.Drawing.Point(243, 41);
            this.lblDangKy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDangKy.Name = "lblDangKy";
            this.lblDangKy.Size = new System.Drawing.Size(208, 45);
            this.lblDangKy.TabIndex = 0;
            this.lblDangKy.Text = "ĐĂNG KÝ";
            this.lblDangKy.Click += new System.EventHandler(this.lblDangKy_Click);
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(12, 322);
            this.lblGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(120, 31);
            this.lblGender.TabIndex = 7;
            this.lblGender.Text = "Giới tính";
            this.lblGender.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtClass
            // 
            this.txtClass.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClass.Location = new System.Drawing.Point(339, 366);
            this.txtClass.Margin = new System.Windows.Forms.Padding(2);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(308, 34);
            this.txtClass.TabIndex = 8;
            this.txtClass.TextChanged += new System.EventHandler(this.txtClass_TextChanged);
            // 
            // cbbGender
            // 
            this.cbbGender.FormattingEnabled = true;
            this.cbbGender.Location = new System.Drawing.Point(339, 322);
            this.cbbGender.Name = "cbbGender";
            this.cbbGender.Size = new System.Drawing.Size(304, 24);
            this.cbbGender.TabIndex = 9;
            this.cbbGender.SelectedIndexChanged += new System.EventHandler(this.cbbGender_SelectedIndexChanged);
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Times New Roman", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.Location = new System.Drawing.Point(12, 369);
            this.lblClass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(62, 31);
            this.lblClass.TabIndex = 10;
            this.lblClass.Text = "Lớp";
            // 
            // FormDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 675);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDangKy";
            this.Text = "FormDangKy";
            this.Load += new System.EventHandler(this.FormDangKy_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtHovaTen;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblHovaTen;
        private System.Windows.Forms.Label lblDangKy;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.CheckBox chkHienMatKhau;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cbbGender;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblClass;
    }
}