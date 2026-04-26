namespace Project_Angile
{
    partial class frmSuKienCLB
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
            this.btSuKien = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterTrangThai = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtDiaDiem = new System.Windows.Forms.TextBox();
            this.dayNgayKT = new System.Windows.Forms.DateTimePicker();
            this.dayNgayBD = new System.Windows.Forms.DateTimePicker();
            this.txtTenSK = new System.Windows.Forms.TextBox();
            this.txtMSK = new System.Windows.Forms.TextBox();
            this.lbMoTa = new System.Windows.Forms.Label();
            this.lbDiaDiem = new System.Windows.Forms.Label();
            this.lbNgayKT = new System.Windows.Forms.Label();
            this.lbNgayBD = new System.Windows.Forms.Label();
            this.lbTenSk = new System.Windows.Forms.Label();
            this.lbMaSK = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSoLuongMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDanhMuc = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btSuKien);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 665);
            this.panel1.TabIndex = 0;
            // 
            // btSuKien
            // 
            this.btSuKien.Location = new System.Drawing.Point(9, 21);
            this.btSuKien.Margin = new System.Windows.Forms.Padding(2);
            this.btSuKien.Name = "btSuKien";
            this.btSuKien.Size = new System.Drawing.Size(106, 51);
            this.btSuKien.TabIndex = 0;
            this.btSuKien.Text = "Sự Kiện";
            this.btSuKien.UseVisualStyleBackColor = true;
            this.btSuKien.Click += new System.EventHandler(this.btSuKien_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbDanhMuc);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtSoLuongMax);
            this.panel2.Controls.Add(this.cbTrangThai);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbFilterTrangThai);
            this.panel2.Controls.Add(this.txtTimKiem);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.txtMoTa);
            this.panel2.Controls.Add(this.txtDiaDiem);
            this.panel2.Controls.Add(this.dayNgayKT);
            this.panel2.Controls.Add(this.dayNgayBD);
            this.panel2.Controls.Add(this.txtTenSK);
            this.panel2.Controls.Add(this.txtMSK);
            this.panel2.Controls.Add(this.lbMoTa);
            this.panel2.Controls.Add(this.lbDiaDiem);
            this.panel2.Controls.Add(this.lbNgayKT);
            this.panel2.Controls.Add(this.lbNgayBD);
            this.panel2.Controls.Add(this.lbTenSk);
            this.panel2.Controls.Add(this.lbMaSK);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(156, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1063, 662);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Items.AddRange(new object[] {
            "Đang lên kế hoạch",
            "Đang tổ chức",
            "Đã tổ chức"});
            this.cbTrangThai.Location = new System.Drawing.Point(239, 497);
            this.cbTrangThai.Margin = new System.Windows.Forms.Padding(2);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(255, 24);
            this.cbTrangThai.TabIndex = 22;
            this.cbTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbTrangThai_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(579, 263);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tìm Kiếm:";
            // 
            // cbFilterTrangThai
            // 
            this.cbFilterTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterTrangThai.FormattingEnabled = true;
            this.cbFilterTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Đang lên kế hoạch",
            "Đang tổ chức",
            "Đã tổ chức"});
            this.cbFilterTrangThai.Location = new System.Drawing.Point(692, 301);
            this.cbFilterTrangThai.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilterTrangThai.Name = "cbFilterTrangThai";
            this.cbFilterTrangThai.Size = new System.Drawing.Size(204, 24);
            this.cbFilterTrangThai.TabIndex = 20;
            this.cbFilterTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbFilterTrangThai_SelectedIndexChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(692, 266);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(204, 22);
            this.txtTimKiem.TabIndex = 19;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 495);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Trạng Thái :";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(442, 600);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 42);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Xóa Sự Kiện";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(239, 600);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(133, 42);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "Chỉnh Sửa Sự Kiện";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(35, 600);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(133, 42);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm Sự Kiện";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(239, 463);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(2);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(255, 22);
            this.txtMoTa.TabIndex = 13;
            this.txtMoTa.TextChanged += new System.EventHandler(this.txtMoTa_TextChanged);
            // 
            // txtDiaDiem
            // 
            this.txtDiaDiem.Location = new System.Drawing.Point(239, 429);
            this.txtDiaDiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaDiem.Name = "txtDiaDiem";
            this.txtDiaDiem.Size = new System.Drawing.Size(255, 22);
            this.txtDiaDiem.TabIndex = 12;
            this.txtDiaDiem.TextChanged += new System.EventHandler(this.txtDiaDiem_TextChanged);
            // 
            // dayNgayKT
            // 
            this.dayNgayKT.Location = new System.Drawing.Point(239, 384);
            this.dayNgayKT.Margin = new System.Windows.Forms.Padding(2);
            this.dayNgayKT.Name = "dayNgayKT";
            this.dayNgayKT.Size = new System.Drawing.Size(255, 22);
            this.dayNgayKT.TabIndex = 11;
            this.dayNgayKT.ValueChanged += new System.EventHandler(this.dayNgayKT_ValueChanged);
            // 
            // dayNgayBD
            // 
            this.dayNgayBD.Location = new System.Drawing.Point(239, 343);
            this.dayNgayBD.Margin = new System.Windows.Forms.Padding(2);
            this.dayNgayBD.Name = "dayNgayBD";
            this.dayNgayBD.Size = new System.Drawing.Size(255, 22);
            this.dayNgayBD.TabIndex = 10;
            this.dayNgayBD.ValueChanged += new System.EventHandler(this.dayNgayBD_ValueChanged);
            // 
            // txtTenSK
            // 
            this.txtTenSK.Location = new System.Drawing.Point(239, 302);
            this.txtTenSK.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenSK.Name = "txtTenSK";
            this.txtTenSK.Size = new System.Drawing.Size(255, 22);
            this.txtTenSK.TabIndex = 9;
            this.txtTenSK.TextChanged += new System.EventHandler(this.txtTenSK_TextChanged);
            // 
            // txtMSK
            // 
            this.txtMSK.Location = new System.Drawing.Point(239, 266);
            this.txtMSK.Margin = new System.Windows.Forms.Padding(2);
            this.txtMSK.Name = "txtMSK";
            this.txtMSK.Size = new System.Drawing.Size(255, 22);
            this.txtMSK.TabIndex = 8;
            this.txtMSK.TextChanged += new System.EventHandler(this.txtMSK_TextChanged);
            // 
            // lbMoTa
            // 
            this.lbMoTa.AutoSize = true;
            this.lbMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoTa.Location = new System.Drawing.Point(31, 461);
            this.lbMoTa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMoTa.Name = "lbMoTa";
            this.lbMoTa.Size = new System.Drawing.Size(66, 24);
            this.lbMoTa.TabIndex = 7;
            this.lbMoTa.Text = "Mô tả :";
            // 
            // lbDiaDiem
            // 
            this.lbDiaDiem.AutoSize = true;
            this.lbDiaDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiaDiem.Location = new System.Drawing.Point(31, 427);
            this.lbDiaDiem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDiaDiem.Name = "lbDiaDiem";
            this.lbDiaDiem.Size = new System.Drawing.Size(168, 24);
            this.lbDiaDiem.TabIndex = 6;
            this.lbDiaDiem.Text = "Địa Điểm Diễn Ra :";
            this.lbDiaDiem.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbNgayKT
            // 
            this.lbNgayKT.AutoSize = true;
            this.lbNgayKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgayKT.Location = new System.Drawing.Point(31, 383);
            this.lbNgayKT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNgayKT.Name = "lbNgayKT";
            this.lbNgayKT.Size = new System.Drawing.Size(145, 24);
            this.lbNgayKT.TabIndex = 5;
            this.lbNgayKT.Text = "Ngày Kết Thúc :";
            this.lbNgayKT.Click += new System.EventHandler(this.lbNgayKT_Click);
            // 
            // lbNgayBD
            // 
            this.lbNgayBD.AutoSize = true;
            this.lbNgayBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgayBD.Location = new System.Drawing.Point(31, 343);
            this.lbNgayBD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNgayBD.Name = "lbNgayBD";
            this.lbNgayBD.Size = new System.Drawing.Size(134, 24);
            this.lbNgayBD.TabIndex = 4;
            this.lbNgayBD.Text = "Ngày Bắt Đầu :";
            // 
            // lbTenSk
            // 
            this.lbTenSk.AutoSize = true;
            this.lbTenSk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSk.Location = new System.Drawing.Point(31, 301);
            this.lbTenSk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTenSk.Name = "lbTenSk";
            this.lbTenSk.Size = new System.Drawing.Size(120, 24);
            this.lbTenSk.TabIndex = 3;
            this.lbTenSk.Text = "Tên Sự Kiện:";
            this.lbTenSk.Click += new System.EventHandler(this.lbTenSk_Click);
            // 
            // lbMaSK
            // 
            this.lbMaSK.AutoSize = true;
            this.lbMaSK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSK.Location = new System.Drawing.Point(31, 263);
            this.lbMaSK.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMaSK.Name = "lbMaSK";
            this.lbMaSK.Size = new System.Drawing.Size(112, 24);
            this.lbMaSK.TabIndex = 1;
            this.lbMaSK.Text = "Mã Sự Kiện:";
            this.lbMaSK.Click += new System.EventHandler(this.lbMaSK_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1061, 230);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtSoLuongMax
            // 
            this.txtSoLuongMax.Location = new System.Drawing.Point(239, 534);
            this.txtSoLuongMax.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoLuongMax.Name = "txtSoLuongMax";
            this.txtSoLuongMax.Size = new System.Drawing.Size(255, 22);
            this.txtSoLuongMax.TabIndex = 23;
            this.txtSoLuongMax.TextChanged += new System.EventHandler(this.txtSoLuongMax_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 534);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 24);
            this.label3.TabIndex = 24;
            this.label3.Text = "Số lượng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 569);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 24);
            this.label4.TabIndex = 25;
            this.label4.Text = "Danh mục:";
            // 
            // cbDanhMuc
            // 
            this.cbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDanhMuc.FormattingEnabled = true;
            this.cbDanhMuc.Items.AddRange(new object[] {
            "Đang lên kế hoạch",
            "Đang tổ chức",
            "Đã tổ chức"});
            this.cbDanhMuc.Location = new System.Drawing.Point(239, 569);
            this.cbDanhMuc.Margin = new System.Windows.Forms.Padding(2);
            this.cbDanhMuc.Name = "cbDanhMuc";
            this.cbDanhMuc.Size = new System.Drawing.Size(255, 24);
            this.cbDanhMuc.TabIndex = 26;
            this.cbDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cbDanhMuc_SelectedIndexChanged);
            // 
            // frmSuKienCLB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 675);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSuKienCLB";
            this.Text = "Sự Kiện";
            this.Load += new System.EventHandler(this.btnDelete_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btSuKien;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbMaSK;
        private System.Windows.Forms.Label lbMoTa;
        private System.Windows.Forms.Label lbDiaDiem;
        private System.Windows.Forms.Label lbNgayKT;
        private System.Windows.Forms.Label lbNgayBD;
        private System.Windows.Forms.Label lbTenSk;
        private System.Windows.Forms.TextBox txtMSK;
        private System.Windows.Forms.TextBox txtTenSK;
        private System.Windows.Forms.DateTimePicker dayNgayBD;
        private System.Windows.Forms.DateTimePicker dayNgayKT;
        private System.Windows.Forms.TextBox txtDiaDiem;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterTrangThai;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoLuongMax;
        private System.Windows.Forms.ComboBox cbDanhMuc;
        private System.Windows.Forms.Label label4;
    }
}

