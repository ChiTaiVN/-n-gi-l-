using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class Form1 : Form
    {
        // Biến db này chỉ dùng cho việc Hủy đăng ký, còn Load danh sách sẽ dùng db cục bộ để luôn có dữ liệu mới
        QuanLyEventCLBDataContext db = new QuanLyEventCLBDataContext();

        public Form1()
        {
            InitializeComponent();
            LoadComboBoxEvents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadComboBoxEvents()
        {
            try
            {
                var events = db.Events.Select(e => new
                {
                    EventID = e.EventID,
                    Title = e.Title
                }).ToList();

                events.Insert(0, new { EventID = "", Title = "-- Tất cả sự kiện --" });

                cbEvent.DataSource = events;
                cbEvent.DisplayMember = "Title";    // Tên hiển thị
                cbEvent.ValueMember = "EventID";    // Giá trị ẩn để lọc
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sự kiện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEvent.SelectedValue != null)
            {
                string selectedEventID = cbEvent.SelectedValue.ToString();
                LoadDanhSach(selectedEventID);
            }
        }

        // ĐÃ SỬA: Dùng kết nối mới để chống Cache và thêm hiển thị cột Trạng thái Check-in
        private void LoadDanhSach(string eventId)
        {
            try
            {
                using (var dbFresh = new QuanLyEventCLBDataContext())
                {
                    var query = from u in dbFresh.Users
                                join r in dbFresh.EventRegistrations on u.UserID equals r.UserID
                                where r.Status == "Registered"
                                select new
                                {
                                    u.StudentID,
                                    u.FullName,
                                    u.Email,
                                    u.Class,          // Thêm lớp
                                    u.Gender,         // Thêm giới tính
                                    r.EventID,
                                    IsCheckedIn = r.IsCheckedIn ?? false
                                };

                    if (!string.IsNullOrEmpty(eventId))
                    {
                        query = query.Where(q => q.EventID == eventId);
                    }

                    var results = query.ToList();

                    // Tạo danh sách hiển thị có đầy đủ các cột
                    var danhSachHienThi = results.Select(q => new
                    {
                        MSSV = q.StudentID,
                        HoTen = q.FullName,
                        Email = q.Email,
                        Lop = q.Class ?? "Chưa cập nhật",        // Xử lý null
                        GioiTinh = q.Gender ?? "Chưa cập nhật",
                        //TrangThai = q.IsCheckedIn ? "Đã Check-in" : "Chưa Check-in"
                    }).Distinct().ToList();

                    dgvDanhSach.DataSource = danhSachHienThi;

                    // Định dạng cột
                    if (dgvDanhSach.Columns.Count > 0)
                    {
                        if (dgvDanhSach.Columns["MSSV"] != null) dgvDanhSach.Columns["MSSV"].HeaderText = "Mã số SV";
                        if (dgvDanhSach.Columns["HoTen"] != null) dgvDanhSach.Columns["HoTen"].HeaderText = "Họ và Tên";
                        if (dgvDanhSach.Columns["Email"] != null) dgvDanhSach.Columns["Email"].HeaderText = "Địa chỉ Email";
                        if (dgvDanhSach.Columns["Lop"] != null) dgvDanhSach.Columns["Lop"].HeaderText = "Lớp";
                        if (dgvDanhSach.Columns["GioiTinh"] != null) dgvDanhSach.Columns["GioiTinh"].HeaderText = "Giới tính";
                        //if (dgvDanhSach.Columns["TrangThai"] != null) dgvDanhSach.Columns["TrangThai"].HeaderText = "Trạng thái Check-in";
                    }

                    // Cập nhật tiêu đề form với thống kê
                    int tong = results.Count;
                    int checkin = results.Count(r => r.IsCheckedIn);
                    double tyLe = tong > 0 ? Math.Round((double)checkin / tong * 100, 2) : 0;
                    this.Text = $"Quản lý Tham Dự | {tong} Đăng ký | Đã Check-in: {checkin} người ({tyLe}%)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string selectedEventID = "";
            string selectedEventName = cbEvent.Text;

            if (cbEvent.SelectedValue != null)
            {
                selectedEventID = cbEvent.SelectedValue.ToString();
            }

            // Gọi Form thống kê (Dữ liệu bên form đó cũng sẽ tự động lấy mới nhất nếu nó query từ DB)
            FormThongKeChiTiet frmTK = new FormThongKeChiTiet(selectedEventID, selectedEventName);
            frmTK.ShowDialog();

            // ĐÃ THÊM: Sau khi tắt form Thống kê, tự động làm mới lại danh sách lưới bên dưới
            LoadDanhSach(selectedEventID);
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV File|*.csv",
                Title = "Lưu danh sách người tham dự",
                FileName = $"DanhSach_{(cbEvent.Text == "-- Tất cả sự kiện --" ? "TatCa" : cbEvent.Text)}.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                    {
                        // Bổ sung xuất cả trạng thái Check-in ra file Excel
                        sw.WriteLine("MSSV,Họ Tên,Email,Trạng Thái");

                        var exportData = dgvDanhSach.Rows.Cast<DataGridViewRow>()
                            .Where(row => !row.IsNewRow)
                            .Select(row => $"{row.Cells["MSSV"].Value},{row.Cells["HoTen"].Value},{row.Cells["Email"].Value},{row.Cells["TrangThai"].Value}");

                        foreach (var line in exportData)
                        {
                            sw.WriteLine(line);
                        }
                    }

                    MessageBox.Show("Đã xuất danh sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnHuy_Click(object sender, EventArgs e)
        {
            if (dgvDanhSach.CurrentRow == null || dgvDanhSach.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên trong danh sách để hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string eventIdCanHuy = "";
            if (cbEvent.SelectedValue != null)
            {
                eventIdCanHuy = cbEvent.SelectedValue.ToString();
            }

            if (string.IsNullOrEmpty(eventIdCanHuy))
            {
                MessageBox.Show("Vui lòng chọn một sự kiện cụ thể ở ComboBox trước khi hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mssvDuocChon = dgvDanhSach.CurrentRow.Cells["MSSV"].Value.ToString();

            try
            {
                var user = db.Users.FirstOrDefault(u => u.StudentID == mssvDuocChon);
                if (user == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin sinh viên này trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string userIdHienTai = user.UserID;
                var phieuDangKy = db.EventRegistrations.FirstOrDefault(r => r.UserID == userIdHienTai && r.EventID == eventIdCanHuy);

                if (phieuDangKy != null && phieuDangKy.Status != "Canceled")
                {
                    if (phieuDangKy.IsCheckedIn == true)
                    {
                        MessageBox.Show("Không thể hủy! Sinh viên này đã check-in tham gia sự kiện.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    phieuDangKy.Status = "Canceled";
                    var suKien = db.Events.FirstOrDefault(ev => ev.EventID == eventIdCanHuy);

                    db.SubmitChanges();

                    MessageBox.Show("Hủy đăng ký thành công! Hệ thống đang gửi email xác nhận...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadDanhSach(eventIdCanHuy);

                    if (suKien != null && !string.IsNullOrEmpty(user.Email))
                    {
                        await GuiEmailXacNhanAsync(user.Email, suKien.Title);
                    }
                }
                else
                {
                    MessageBox.Show("Sinh viên này chưa đăng ký sự kiện này hoặc phiếu đăng ký đã được hủy trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task GuiEmailXacNhanAsync(string emailNguoiNhan, string tenSuKien)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailNguoiNhan)) return;
                string cleanEmail = emailNguoiNhan.Trim();

                MailMessage mail = new MailMessage();

                string myEmail = "bbidxer@gmail.com";
                string myPass = "fuhj dypl euhn dvny";

                mail.From = new MailAddress(myEmail, "CLB Công nghệ thông tin - HCMUE");
                mail.To.Add(cleanEmail);
                mail.Subject = "[Xác nhận] Hủy đăng ký sự kiện thành công";

                mail.Body = $"Chào bạn,\n\nHệ thống ghi nhận bạn đã hủy tham gia sự kiện: '{tenSuKien}'.\n" +
                            $"Thời gian thực hiện: {DateTime.Now:dd/MM/yyyy HH:mm:ss}.\n\n" +
                            $"Cảm ơn bạn đã thông báo để Ban tổ chức có thể dành vị trí này cho các bạn khác.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(myEmail, myPass);
                smtp.EnableSsl = true;

                await Task.Run(() => smtp.Send(mail));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi gửi Email: " + ex.Message);
            }
        }
    }
}