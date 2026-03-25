using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Agile
{
    public partial class FormRegister : Form
    {
        // Khai báo giới hạn và biến đếm
        private const int MAX_PARTICIPANTS = 10;
        private int currentCount = 0;
        private readonly object _lock = new object(); // Đảm bảo AC 5: Ngăn chặn tranh chấp

        public FormRegister()
        {
            InitializeComponent();
            // Khởi tạo giá trị ban đầu cho lblCount
            UpdateDisplay();

            // Đảm bảo Form luôn hiện ra ở giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            // Hùng có thể để trống hoặc viết code khởi tạo tại đây
            // Ví dụ: nạp danh sách Khoa vào cbKhoa
            cbKhoa.Items.Add("Công nghệ thông tin");
            cbKhoa.Items.Add("Sư phạm Toán");
            cbKhoa.Items.Add("Sư phạm Anh");
            cbKhoa.Items.Add("Tâm lý học");
            cbKhoa.Items.Add("Hóa học");
        }

        // Sự kiện khi nhấn nút Submit (Đăng ký)
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã nhập đủ thông tin chưa
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtMSSV.Text) || cbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xử lý logic đăng ký an toàn
            lock (_lock)
            {
                if (currentCount < MAX_PARTICIPANTS)
                {
                    currentCount++;
                    MessageBox.Show($"đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa dữ liệu cũ để nhập người mới
                    ClearInput();

                    // Cập nhật hiển thị
                    UpdateDisplay();
                }
                else
                {
                    MessageBox.Show("Sự kiện đã hết chỗ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        // Sự kiện khi nhấn nút Back (Thoát)
        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát form đăng ký không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Hàm cập nhật hiển thị và kiểm tra giới hạn
        private void UpdateDisplay()
        {
            if (currentCount >= MAX_PARTICIPANTS)
            {
                lblCount.Text = "Đã hết chỗ";
                lblCount.ForeColor = Color.Red;

                // Khóa các control để sinh viên không thao tác được nữa (AC 3 & 4)
                btnSubmit.Enabled = false;
                txtName.Enabled = false;
                txtMSSV.Enabled = false;
                cbKhoa.Enabled = false;
            }
            else
            {
                lblCount.Text = $"Người đăng ký: {currentCount} / {MAX_PARTICIPANTS}";
                lblCount.ForeColor = Color.Black;
            }
        }

        // Hàm xóa trắng ô nhập liệu
        private void ClearInput()
        {
            txtName.Clear();
            txtMSSV.Clear();
            cbKhoa.SelectedIndex = -1;
            txtName.Focus();
        }

        private void btnCheat_Click(object sender, EventArgs e)
        {
            currentCount = 9;

            // Cập nhật lại giao diện để kiểm tra xem AC 3, 4, 5 có chạy đúng không
            UpdateDisplay();

            MessageBox.Show("Debug: 9 người đăng ký thành công!", "Tester Mode");
        }
    }
}