using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class FormThongKe : Form
    {
        // XÓA DÒNG NÀY: QuanLyEventCLBDataContext db = new QuanLyEventCLBDataContext(); 
        // Đưa db vào trong using block để luôn lấy dữ liệu mới nhất.

        public FormThongKe()
        {
            InitializeComponent();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                // Lấy đến 23:59:59 của ngày kết thúc
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

                // 1. Kiểm tra logic ngày tháng
                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Thời gian 'Từ ngày' không được lớn hơn 'Đến ngày'!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Sử dụng 'using' để tự động giải phóng bộ nhớ và luôn lấy data mới nhất từ Database
                using (QuanLyEventCLBDataContext db = new QuanLyEventCLBDataContext())
                {
                    var query = (from r in db.EventRegistrations
                                 join ev in db.Events on r.EventID equals ev.EventID
                                 join u in db.Users on r.UserID equals u.UserID
                                 where r.IsCheckedIn == true
                                    && ev.StartTime >= tuNgay
                                    && ev.StartTime <= denNgay
                                 group r by new { u.StudentID, u.FullName, u.Email } into g
                                 orderby g.Count() descending
                                 select new
                                 {
                                     MSSV = g.Key.StudentID,
                                     HoTen = g.Key.FullName,
                                     Email = g.Key.Email,
                                     TongSuKien = g.Count()
                                 }).ToList();

                    // 3. Đổi tên các Property thành KHÔNG DẤU để tránh lỗi Binding
                    var leaderboard = query.Select((sv, index) => new
                    {
                        Hang = index + 1,
                        MSSV = sv.MSSV,
                        HoTen = sv.HoTen,
                        Email = sv.Email,
                        TongSuKien = sv.TongSuKien
                    }).ToList();

                    // 4. Reset DataGridView trước khi gán data mới
                    dgvLeaderboard.DataSource = null;
                    dgvLeaderboard.DataSource = leaderboard;

                    // 5. Đổi tên hiển thị trên cột thành Tiếng Việt có dấu cho người dùng xem
                    if (dgvLeaderboard.Columns.Count > 0)
                    {
                        dgvLeaderboard.Columns["Hang"].HeaderText = "Hạng";
                        dgvLeaderboard.Columns["MSSV"].HeaderText = "MSSV";
                        dgvLeaderboard.Columns["HoTen"].HeaderText = "Họ và Tên";
                        dgvLeaderboard.Columns["Email"].HeaderText = "Email liên hệ";
                        dgvLeaderboard.Columns["TongSuKien"].HeaderText = "Tổng Sự Kiện";

                        // Tự động giãn cột cho đẹp
                        dgvLeaderboard.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvLeaderboard.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    if (leaderboard.Count == 0)
                    {
                        MessageBox.Show("Không có sinh viên nào tham gia sự kiện trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}