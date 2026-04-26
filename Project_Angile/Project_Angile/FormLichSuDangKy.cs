using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class FormLichSuDangKy : Form
    {
        // Khởi tạo DataContext để kết nối Database
        QuanLyEventCLBDataContext db = new QuanLyEventCLBDataContext();

        public FormLichSuDangKy()
        {
            InitializeComponent();
        }

        private async void btnHuyDangKy_Click(object sender, EventArgs e)
        {
            // ĐÃ SỬA: Chuyển int -> string để khớp với VARCHAR(50) và VARCHAR(10) trong DB
            // Giả sử: Mã User là 'U03' và Mã sự kiện là 'E01' để test
            string userIdHienTai = "U03";
            string eventIdCanHuy = "E01";

            try
            {
                // Bước 1: Tìm phiếu đăng ký dựa trên cặp ID chuỗi
                var phieuDangKy = db.EventRegistrations.FirstOrDefault(r => r.UserID == userIdHienTai && r.EventID == eventIdCanHuy);

                // Kiểm tra nếu tìm thấy và trạng thái chưa bị hủy
                if (phieuDangKy != null && phieuDangKy.Status != "Canceled")
                {
                    // AC 1: Cập nhật trạng thái hủy
                    phieuDangKy.Status = "Canceled";

                    // Tìm thông tin sự kiện và người dùng để lấy Email/Tên phục vụ gửi thư
                    var suKien = db.Events.FirstOrDefault(ev => ev.EventID == eventIdCanHuy);
                    var user = db.Users.FirstOrDefault(u => u.UserID == userIdHienTai);

                    // Lưu thay đổi xuống SQL Server
                    db.SubmitChanges();

                    MessageBox.Show("Hủy đăng ký thành công! Hệ thống đang gửi email xác nhận...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // AC 2: Gửi email thông báo ngầm (không làm đơ giao diện nhờ async/await)
                    if (user != null && suKien != null && !string.IsNullOrEmpty(user.Email))
                    {
                        await GuiEmailXacNhanAsync(user.Email, suKien.Title);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa đăng ký sự kiện này hoặc phiếu đăng ký đã được hủy trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------ HÀM GỬI EMAIL XỬ LÝ BẤT ĐỒNG BỘ ------------------
        private async Task GuiEmailXacNhanAsync(string emailNguoiNhan, string tenSuKien)
        {
            try
            {
                MailMessage mail = new MailMessage();

                // Chú ý: Cần sử dụng App Password nếu dùng Gmail
                string myEmail = "email_cua_nhom@gmail.com";
                string myPass = "mat_khau_ung_dung_cua_nhom";

                mail.From = new MailAddress(myEmail, "CLB Công nghệ thông tin - HCMUE");
                mail.To.Add(emailNguoiNhan);
                mail.Subject = "[Xác nhận] Hủy đăng ký sự kiện thành công";

                // Nội dung thư trình bày rõ ràng hơn
                mail.Body = $"Chào bạn,\n\nHệ thống ghi nhận bạn đã hủy tham gia sự kiện: '{tenSuKien}'.\n" +
                            $"Thời gian thực hiện: {DateTime.Now:dd/MM/yyyy HH:mm:ss}.\n\n" +
                            $"Cảm ơn bạn đã thông báo để Ban tổ chức có thể dành vị trí này cho các bạn khác.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(myEmail, myPass);
                smtp.EnableSsl = true;

                // Chạy tác vụ gửi mail trên một luồng khác để tránh treo UI
                await Task.Run(() => smtp.Send(mail));
            }
            catch (Exception ex)
            {
                // Lỗi gửi mail không nên làm dừng quy trình hủy của người dùng
                Console.WriteLine("Lỗi gửi Email: " + ex.Message);
            }
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Logic xử lý khi click vào Grid (nếu cần)
        }

        private void FormLichSuDangKy_Load(object sender, EventArgs e)
        {

        }
    }
}