using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class FormDangNhap : Form
    {
        private int soLanSai = 0;
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void lblTenDangNhap_Click(object sender, EventArgs e)
        {

        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            string mssv = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã số sinh viên và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new QuanLyEventCLBDataContext())
            {
                var user = db.Users.FirstOrDefault(u => u.StudentID == mssv && u.PasswordHash == matKhau);

                if (user != null)
                {
                    if (user.IsActive == false)
                    {
                        MessageBox.Show("Tài khoản của bạn đã bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    soLanSai = 0;

                    //Đăng nhập thành công
                    FormTongHop frm = new FormTongHop(user.RoleID.Value, user.UserID); //HOÀNG CHỈNH SỬA LẠI SAU
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    
                    soLanSai++;

                    if (soLanSai == 3)
                    {
                        MessageBox.Show("Bạn đã nhập sai 3 lần. Tính năng đăng nhập sẽ bị khóa trong 10 giây.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        await ThucHienKhoaDangNhap(10); // Khóa 10 giây
                    }
                    else if (soLanSai >= 4)
                    {
                        MessageBox.Show($"Bạn đã nhập sai {soLanSai} lần. Tính năng đăng nhập sẽ bị khóa trong 30 giây.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        await ThucHienKhoaDangNhap(30); // Khóa 30 giây
                    }
                    else
                    {
                        MessageBox.Show($"Tên đăng nhập (MSSV) hoặc mật khẩu không đúng!\n(Bạn đã nhập sai {soLanSai}/3 lần)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Hàm xử lý logic khóa UI
        private async Task ThucHienKhoaDangNhap(int soGiay)
        {
            //vo hieu hoa khi dang cho
            btnDangNhap.Enabled = false;
            txtTenDangNhap.Enabled = false;
            txtMatKhau.Enabled = false;

            //Doi khi nhap sai mk
            await Task.Delay(soGiay * 1000);

            //het tg cho
            btnDangNhap.Enabled = true;
            txtTenDangNhap.Enabled = true;
            txtMatKhau.Enabled = true;

            //Xoa trang o
            txtMatKhau.Clear();
            txtMatKhau.Focus();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMatKhau.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                //ẩn mạt khẩu
                txtMatKhau.PasswordChar = '*';
            }
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            FormDangKy frmDangKy = new FormDangKy();
            frmDangKy.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}