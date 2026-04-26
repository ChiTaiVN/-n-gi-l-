using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class FormThongKeChiTiet : Form
    {
        QuanLyEventCLBDataContext db = new QuanLyEventCLBDataContext();

        // ĐÃ SỬA: Đổi kiểu từ int sang string
        private string eventId;

        // ĐÃ SỬA: Tham số selectedEventId đổi thành string
        public FormThongKeChiTiet(string selectedEventId, string eventName)
        {
            InitializeComponent();
            this.eventId = selectedEventId;
            this.Text = "Thống Kê Chi Tiết - " + eventName;
        }

        private void FormThongKeChiTiet_Load(object sender, EventArgs e)
        {
            LoadDuLieuThongKe();
        }

        private void LoadDuLieuThongKe()
        {
            try
            {
                var query = from u in db.Users
                            join r in db.EventRegistrations on u.UserID equals r.UserID
                            select new
                            {
                                r.EventID,
                                MSSV = u.StudentID,
                                HoTen = u.FullName,
                                // ĐÃ CẬP NHẬT: Lấy trực tiếp từ DB do bạn đã thêm cột Gender và Class
                                GioiTinh = u.Gender != null ? u.Gender : "Chưa cập nhật",
                                Lop = u.Class != null ? u.Class : "Chưa cập nhật",
                                // ĐÃ CẬP NHẬT: Hiển thị trạng thái thực tế
                                TrangThai = r.IsCheckedIn == true ? "Đã tham gia (Check-in)" : "Chỉ mới đăng ký"
                            };

                // ĐÃ SỬA: Vì eventId là chuỗi, ta dùng string.IsNullOrEmpty thay vì > 0
                if (!string.IsNullOrEmpty(eventId))
                {
                    query = query.Where(q => q.EventID == eventId);
                }

                dgvThongKe.DataSource = query.Select(q => new
                {
                    q.HoTen,
                    q.MSSV,
                    q.GioiTinh,
                    q.Lop,
                    q.TrangThai
                }).ToList();

                if (dgvThongKe.Columns.Count > 0)
                {
                    dgvThongKe.Columns["HoTen"].HeaderText = "Họ và Tên";
                    dgvThongKe.Columns["MSSV"].HeaderText = "Mã số SV";
                    dgvThongKe.Columns["GioiTinh"].HeaderText = "Giới tính";
                    dgvThongKe.Columns["Lop"].HeaderText = "Lớp";
                    dgvThongKe.Columns["TrangThai"].HeaderText = "Trạng thái cụ thể";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}