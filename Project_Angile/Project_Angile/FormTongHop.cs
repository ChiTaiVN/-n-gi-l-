using System;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class FormTongHop : Form
    {
        // Biến lưu trữ quyền của người dùng hiện tại
        private int userRole;

        // ĐÃ SỬA: Thêm biến lưu trữ ID người dùng hiện tại
        private string currentUserID;

        // ĐÃ SỬA: Yêu cầu truyền cả RoleID và UserID vào khi khởi tạo Form này từ Form Đăng Nhập
        public FormTongHop(int roleID, string userId)
        {
            InitializeComponent();
            this.userRole = roleID;
            this.currentUserID = userId; // Nhận ID từ form đăng nhập và cất giữ ở đây
        }

        private void FormTongHop_Load(object sender, EventArgs e)
        {
            // Chạy hàm phân quyền ngay khi form vừa load lên
            PhanQuyenGiaoDien();
        }

        // HÀM XỬ LÝ ẨN/HIỆN GIAO DIỆN THEO QUYỀN (RBAC)
        private void PhanQuyenGiaoDien()
        {
            switch (userRole)
            {
                case 1:
                    // ADMIN: Full quyền truy cập
                    btnSuKienCLB.Visible = true;    // Quản lý sự kiện
                    btnStudentInfo.Visible = true;  // Quản lý sinh viên
                    btnForm1.Visible = true;        // Quản lý người tham gia
                    btnLeaderboard.Visible = true;  // Thống kê BXH
                    btnCheckIn.Visible = true;      // Quét mã Check-in
                    btnSearch.Visible = true;       // Tìm kiếm SK
                    btnCalendar.Visible = true;     // Lịch SK
                    btnfbcheck.Visible = true;      // Facebook Check-in

                    this.Text = "Dashboard - Quyền: Quản Trị Viên (Admin)";
                    break;

                case 2:
                    // BAN TỔ CHỨC: Quản lý sự kiện, thống kê, check-in. KHÔNG quản lý danh sách sinh viên.
                    btnSuKienCLB.Visible = true;
                    btnStudentInfo.Visible = false; // Ẩn
                    btnForm1.Visible = true;
                    btnLeaderboard.Visible = true;
                    btnCheckIn.Visible = true;
                    btnSearch.Visible = true;
                    btnCalendar.Visible = true;
                    btnfbcheck.Visible = true;


                    this.Text = "Dashboard - Quyền: Ban Tổ Chức";
                    break;

                case 3:
                case 4:
                case 5:
                    // SINH VIÊN / KHÁCH MỜI / CỐ VẤN: Chỉ xem lịch, tìm kiếm để đăng ký
                    btnSuKienCLB.Visible = false;   // Ẩn Quản lý sự kiện
                    btnStudentInfo.Visible = false; // Ẩn Quản lý sinh viên
                    btnForm1.Visible = false;       // Ẩn Quản lý người tham gia
                    btnLeaderboard.Visible = false; // Ẩn Thống kê
                    btnCheckIn.Visible = false;     // Ẩn Quét mã Check-in (chỉ BTC mới cầm máy quét)

                    btnSearch.Visible = true;       // Mở Tìm kiếm
                    btnCalendar.Visible = true;     // Mở Lịch
                    btnfbcheck.Visible = false;


                    this.Text = "Dashboard - Quyền: Thành Viên";
                    break;

                default:
                    // Nếu lỗi role, ẩn hết các nút quản trị để bảo mật
                    btnSuKienCLB.Visible = false;
                    btnStudentInfo.Visible = false;
                    btnForm1.Visible = false;
                    btnLeaderboard.Visible = false;
                    btnCheckIn.Visible = false;
                    btnfbcheck.Visible = false;

                    this.Text = "Dashboard";
                    break;
            }
        }

        // ================= CÁC SỰ KIỆN CLICK NÚT MỞ FORM =================

        // 1. Chức năng Quản lý & Thống kê Sự kiện (Form1 gọi FormThongKeChiTiet)
        private void btnForm1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        // 2. Chức năng Bảng xếp hạng (Leaderboard tổng hợp theo ngày)
        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            FormThongKe f = new FormThongKe();
            f.ShowDialog();
        }

        // 3. Chức năng Quản lý sự kiện CLB (frmSuKienCLB gọi frmEventDetail)
        private void btnSuKienCLB_Click(object sender, EventArgs e)
        {
            frmSuKienCLB f = new frmSuKienCLB();
            f.ShowDialog();
        }

        // 4. Chức năng Tìm kiếm sự kiện (frmEventSearch gọi frmEventDetail)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // ĐÃ SỬA: Truyền ID người dùng đang đăng nhập sang form Tìm kiếm
            frmEventSearch f = new frmEventSearch(currentUserID);
            f.ShowDialog();
        }

        // 5. Chức năng Lịch sự kiện
        private void btnCalendar_Click(object sender, EventArgs e)
        {
            // ĐÃ SỬA: Truyền ID người dùng đang đăng nhập sang form Lịch
            frmEventCalendar f = new frmEventCalendar(currentUserID);
            f.ShowDialog();
        }

        // 6. Chức năng Thông tin sinh viên
        private void btnStudentInfo_Click(object sender, EventArgs e)
        {
            frmStudentInformation f = new frmStudentInformation(userRole);
            f.ShowDialog();
        }

        // 7. Chức năng Tự điểm danh (Self Check-in)
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            frmSelfCheckIn f = new frmSelfCheckIn();
            f.ShowDialog();
        }

        // 8. Hệ thống Đăng nhập & Đăng ký (Có thể dùng làm nút Đăng xuất)
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Nếu click vào đây từ Form Tổng Hợp thì thường là để Đăng Xuất
            DialogResult rs = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                FormDangNhap f = new FormDangNhap();
                f.Show();
                this.Hide(); // Ẩn form tổng hợp
            }
        }

        private void btnfbcheck_Click(object sender, EventArgs e)
        {
            frmFeedBack f = new frmFeedBack(); // liên kết với checkin + feedback
            f.ShowDialog();
        }
    }
}