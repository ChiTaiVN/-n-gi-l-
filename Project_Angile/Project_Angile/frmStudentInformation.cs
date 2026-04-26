using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class frmStudentInformation : Form
    {
        QuanLyEventCLBDataContext db = new QuanLyEventCLBDataContext();

        // ĐÃ SỬA: Không fix cứng nữa, hứng giá trị từ Form gọi nó
        public int currentRole;

        // ĐÃ SỬA: Yêu cầu truyền RoleID vào khi mở form
        public frmStudentInformation(int role)
        {
            InitializeComponent();
            currentRole = role;

            // KIỂM TRA QUYỀN ADMIN NGAY LÚC MỞ FORM
            if (currentRole != 1)
            {
                MessageBox.Show("Chỉ tài khoản Admin mới được quyền truy cập quản lý hồ sơ!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Dùng BeginInvoke để đóng form an toàn khi form chưa load xong
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            LoadData();
            LoadKhoa();
        }

        // ================= LOAD DATA (CHỈ LẤY SV ĐÃ ĐĂNG KÝ) =================
        void LoadData()
        {
            // ĐÃ SỬA: JOIN với EventRegistration để lấy đúng những người ĐÃ TỪNG ĐĂNG KÝ
            var query = (from u in db.Users
                         join r in db.EventRegistrations on u.UserID equals r.UserID
                         where u.RoleID == 3 // Chỉ lấy sinh viên
                         select u).Distinct(); // Dùng Distinct để không bị lặp tên nếu SV đó đăng ký nhiều sự kiện

            var ds = query.Select(u => new
            {
                u.UserID,
                MSSV = u.StudentID,
                HoTen = u.FullName,
                Email = u.Email,
                Lop = u.Class // ĐÃ BỔ SUNG: Hiển thị Lớp
            }).ToList();

            dgvStudent.DataSource = ds;

            // Đổi tên cột cho đẹp - ĐÃ SỬA: kiểm tra null trước khi truy cập
            if (dgvStudent.Columns.Count > 0)
            {
                if (dgvStudent.Columns["UserID"] != null) dgvStudent.Columns["UserID"].Visible = false;
                if (dgvStudent.Columns["MSSV"] != null) dgvStudent.Columns["MSSV"].HeaderText = "Mã số SV";
                if (dgvStudent.Columns["HoTen"] != null) dgvStudent.Columns["HoTen"].HeaderText = "Họ và tên";
                if (dgvStudent.Columns["Email"] != null) dgvStudent.Columns["Email"].HeaderText = "Email liên hệ";
                if (dgvStudent.Columns["Lop"] != null) dgvStudent.Columns["Lop"].HeaderText = "Khoa / Lớp";
            }
        }

        void LoadKhoa()
        {
            cbKhoa.Items.Clear();
            cbKhoa.Items.Add("Tất cả"); // Thêm nút Tất cả để dễ reset bộ lọc
            cbKhoa.Items.Add("48");
            cbKhoa.Items.Add("49");
            cbKhoa.Items.Add("50");
            cbKhoa.SelectedIndex = 0;
        }

        // ================= TÌM KIẾM THEO MSSV HOẶC HỌ TÊN =================
        // THÊM MỚI: Xử lý sự kiện khi gõ vào ô tìm kiếm (Giả sử bạn có TextBox tên là txtSearch)
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            var query = (from u in db.Users
                         join r in db.EventRegistrations on u.UserID equals r.UserID
                         where u.RoleID == 3 &&
                               (u.StudentID.ToLower().Contains(keyword) || u.FullName.ToLower().Contains(keyword))
                         select u).Distinct();

            var ds = query.Select(u => new
            {
                u.UserID,
                MSSV = u.StudentID,
                HoTen = u.FullName,
                Email = u.Email,
                Lop = u.Class
            }).ToList();

            dgvStudent.DataSource = ds;
        }

        // ================= FILTER KHOA =================
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cbKhoa.SelectedItem == null) return;

            string khoa = cbKhoa.SelectedItem.ToString();

            if (khoa == "Tất cả")
            {
                LoadData();
                return;
            }

            var query = (from u in db.Users
                         join r in db.EventRegistrations on u.UserID equals r.UserID
                         where u.RoleID == 3 && u.StudentID.StartsWith(khoa)
                         select u).Distinct();

            var ds = query.Select(u => new
            {
                u.UserID,
                MSSV = u.StudentID,
                HoTen = u.FullName,
                Email = u.Email,
                Lop = u.Class
            }).ToList();

            dgvStudent.DataSource = ds;
        }

        // ================= CLICK GRID ĐỂ XEM CHI TIẾT =================
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Đã kiểm tra quyền Admin ngay lúc mở form rồi nên ở đây không cần kiểm tra lại nữa

            dynamic row = dgvStudent.Rows[e.RowIndex].DataBoundItem;
            string userID = row.UserID.ToString();

            // Mở form StudentDetail (Form này đã xử lý việc lưu xuống Database và lịch sử hoạt động)
            StudentDetail f = new StudentDetail(userID);
            f.ShowDialog();

            LoadData(); // Cập nhật lại lưới ngay lập tức sau khi Admin bấm "Lưu" bên form chi tiết
        }

        // ================= CÁC HÀM GIỮ LẠI ĐỂ TRÁNH LỖI DESIGNER =================
        private void label1_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }

        // Hàm này đã có trong code gốc, giữ lại để không bị mất kết nối sự kiện (nếu có)
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            // Gọi lại hàm xử lý chính để tránh trùng lặp logic
            txtSearch_TextChanged(sender, e);
        }
    }
}