using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }

        private void lblHovaTen_Click(object sender, EventArgs e)
        {

        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMSSV_Click(object sender, EventArgs e)
        {

        }

        private void txtMSSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string hoTen = txtHovaTen.Text.Trim();
            string mssv = txtMSSV.Text.Trim();
            string email = txtEmail.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            string gioiTinh = cbbGender.Text.Trim();
            string lopHoc = txtClass.Text.Trim();

            // Không để trống bất kỳ trường nào
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(mssv) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau) ||
                string.IsNullOrEmpty(gioiTinh) || string.IsNullOrEmpty(lopHoc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Bao gồm giới tính và lớp)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ĐÃ SỬA: Định dạng mssv chỉ gồm đúng 10 chữ số viết liền (VD: 5001104001)
            string patternMSSV = @"^\d{10}$";
            if (!Regex.IsMatch(mssv, patternMSSV))
            {
                MessageBox.Show("Mã số sinh viên không đúng!\nVui lòng nhập 10 chữ số viết liền (Ví dụ: 5001104001)", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Định dạng email
            string patternEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, patternEmail))
            {
                MessageBox.Show("Định dạng Email không hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new QuanLyEventCLBDataContext())
            {
                // Kiểm tra trùng lặp
                bool daTonTai = db.Users.Any(u => u.StudentID == mssv || u.Email == email);
                if (daTonTai)
                {
                    MessageBox.Show("Mã số sinh viên hoặc Email đã được đăng ký. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tự động tạo UserID để không bị lỗi database
                string newUserID = "U_" + DateTime.Now.ToString("yyMMddHHmmss");

                // Tạo đối tượng User mới
                User newUser = new User()
                {
                    UserID = newUserID,
                    FullName = hoTen,
                    StudentID = mssv,
                    Email = email,
                    PasswordHash = matKhau,
                    Gender = gioiTinh,
                    Class = lopHoc,
                    RoleID = 3,           // Sinh viên
                    IsActive = true
                };

                // Lệnh lưu vào CSDL của LINQ to SQL
                db.Users.InsertOnSubmit(newUser);
                db.SubmitChanges();

                MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trở về Form Đăng Nhập
                FormDangNhap frmDangNhap = new FormDangNhap();
                frmDangNhap.Show();
                this.Close();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            FormDangNhap frmDangNhap = new FormDangNhap();
            frmDangNhap.Show();
            this.Close();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMatKhau.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                // Ẩn mk
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {
            if (cbbGender.Items.Count == 0)
            {
                cbbGender.Items.Add("Nam");
                cbbGender.Items.Add("Nữ");
                cbbGender.SelectedIndex = 0;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDangKy_Click(object sender, EventArgs e)
        {

        }

        private void cbbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtClass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}