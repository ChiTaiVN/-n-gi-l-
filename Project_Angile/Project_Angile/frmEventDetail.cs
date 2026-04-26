using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class frmEventDetail : Form
    {
        private string currentEventId;

        // ĐÃ SỬA: Xóa currentMockUserID = "U03", thay bằng biến nhận ID thật
        private string currentUserID;
        QuanLyEventCLBDataContext db = new QuanLyEventCLBDataContext();

        // ĐÃ SỬA: Constructor giờ nhận 2 tham số: ID sự kiện và ID người dùng đang đăng nhập
        public frmEventDetail(string eventId, string userId)
        {
            InitializeComponent();
            currentEventId = eventId;
            currentUserID = userId; // Gán ID thật từ form cha truyền sang
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            LoadEventDetails();
        }

        // Hàm tải toàn bộ chi tiết sự kiện bằng LINQ to SQL
        private void LoadEventDetails()
        {
            try
            {
                using (var db = new QuanLyEventCLBDataContext())
                {
                    // --- PHẦN 1: LOAD THÔNG TIN CƠ BẢN VÀ ẢNH BÌA ---
                    var ev = db.Events.SingleOrDefault(x => x.EventID == currentEventId);

                    if (ev == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin sự kiện!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }

                    lblEventTitle.Text = ev.Title;

                    DateTime startTime = ev.StartTime;
                    DateTime endTime = ev.EndTime;
                    lblEventTime.Text = $"Thời gian: {startTime:HH:mm dd/MM/yyyy} - {endTime:HH:mm dd/MM/yyyy}";

                    lblEventLocation.Text = "Địa điểm: " + ev.Location;
                    rtbEventDescription.Text = ev.Description;

                    // Gán trực tiếp (Nếu trường MaxAttendees trong DB cho phép NULL, bạn hãy đổi thành: ev.MaxAttendees ?? 0)
                    int maxAttendees = ev.MaxAttendees.HasValue ? ev.MaxAttendees.Value : 0;

                    // Xử lý Ảnh bìa
                    string imageFolder = Path.Combine(Application.StartupPath, "Images");
                    string expectedFileName = currentEventId + ".jpg";
                    string fullImagePath = Path.Combine(imageFolder, expectedFileName);

                    if (File.Exists(fullImagePath))
                    {
                        try { picCover.Image = Image.FromFile(fullImagePath); }
                        catch { picCover.Image = null; }
                    }
                    else
                    {
                        picCover.Image = null;
                    }

                    // --- PHẦN 2: LOAD TÀI LIỆU ĐÍNH KÈM VÀO RICHTEXTBOX ---
                    var docs = db.EventDocuments.Where(d => d.EventID == currentEventId).ToList();

                    if (docs.Any())
                    {
                        string docText = "\n\n--- TÀI LIỆU SỰ KIỆN ---\n";
                        foreach (var doc in docs)
                        {
                            docText += $"- {doc.FileName}: {doc.FileURL}\n";
                        }
                        rtbEventDescription.AppendText(docText);
                    }

                    // --- PHẦN 3: ĐẾM CHỖ NGỒI VÀ KIỂM TRA TRẠNG THÁI ĐĂNG KÝ ---
                    // Đếm số lượng đã đăng ký
                    int registeredCount = db.EventRegistrations.Count(r => r.EventID == currentEventId && r.Status == "Registered");
                    lblSeats.Text = $"Chỗ ngồi: {registeredCount}/{maxAttendees}";

                    // ĐÃ SỬA: Kiểm tra xem User hiện tại (currentUserID) đã đăng ký chưa
                    bool isAlreadyRegistered = db.EventRegistrations.Any(r => r.EventID == currentEventId && r.UserID == currentUserID && r.Status == "Registered");

                    // Cập nhật giao diện nút bấm
                    CheckRegistrationStatus(maxAttendees, registeredCount, isAlreadyRegistered);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm giao diện đổi màu nút Đăng ký
        private void CheckRegistrationStatus(int maxAttendees, int registeredCount, bool isAlreadyRegistered)
        {
            if (isAlreadyRegistered)
            {
                btnRegister.Text = "ĐÃ ĐĂNG KÝ";
                btnRegister.Enabled = false;
                btnRegister.BackColor = Color.Gray;
            }
            else if (registeredCount >= maxAttendees)
            {
                btnRegister.Text = "SỰ KIỆN ĐÃ FULL";
                btnRegister.Enabled = false;
                btnRegister.BackColor = Color.Red;
            }
            else
            {
                btnRegister.Text = "ĐĂNG KÝ THAM GIA";
                btnRegister.Enabled = true;
                btnRegister.BackColor = Color.FromArgb(0, 120, 215); // Màu xanh dương
            }
        }

        // Sự kiện Click nút Đăng ký (Lưu xuống DB bằng LINQ)
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng ký tham gia sự kiện này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var db = new QuanLyEventCLBDataContext())
                    {
                        // Kiểm tra lại lần nữa với ID user thật
                        bool daDangKy = db.EventRegistrations.Any(r => r.EventID == currentEventId && r.UserID == currentUserID && r.Status == "Registered");

                        if (daDangKy)
                        {
                            MessageBox.Show("Bạn đã đăng ký sự kiện này rồi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Lấy thông tin user và event để gửi email
                        var currentUser = db.Users.FirstOrDefault(u => u.UserID == currentUserID);
                        var currentEvent = db.Events.FirstOrDefault(ev => ev.EventID == currentEventId);

                        int maxID = db.EventRegistrations.Any() ? db.EventRegistrations.Max(r => r.RegistrationID) : 0;
                        int newRegID = maxID + 1;

                        // ĐÃ THÊM: Tạo mã vé (Ticket Code) ngẫu nhiên 8 ký tự
                        string uniqueTicketCode = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

                        // Tạo Object mới cho bảng EventRegistration
                        EventRegistration newRegistration = new EventRegistration
                        {
                            RegistrationID = newRegID,
                            EventID = currentEventId,
                            UserID = currentUserID, // Dùng ID thật
                            RegistrationDate = DateTime.Now,
                            Status = "Registered",
                            IsCheckedIn = false,
                            QRCodeString = uniqueTicketCode // Lưu mã vé vào CSDL
                        };

                        db.EventRegistrations.InsertOnSubmit(newRegistration);
                        db.SubmitChanges(); // Lưu vào Database

                        // Gửi email chạy ngầm
                        if (currentUser != null && currentEvent != null)
                        {
                            // ĐÃ THÊM: Truyền mã vé vào hàm gửi email
                            await SendEmailAsync(currentEvent, currentUser, uniqueTicketCode);
                        }

                        MessageBox.Show("Đăng ký thành công! Mã vé tham gia đã được gửi về Email của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại form để cập nhật số ghế và làm mờ nút
                        LoadEventDetails();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện Click vào Link trong phần Mô tả/Tài liệu
        private void rtbEventDescription_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            // Mở trình duyệt web mặc định để tải tài liệu
            System.Diagnostics.Process.Start(e.LinkText);
        }

        // GIỮ LẠI CÁC HÀM TRỐNG ĐỂ KHÔNG BỊ BỂ FORM
        private void frmEventDetail_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {

        }

        // ĐÃ THÊM: Cập nhật hàm gửi email nhận thêm biến mã vé (ticketCode)
        private async Task SendEmailAsync(Event ev, User user, string ticketCode)
        {
            try
            {
                // Loại bỏ khoảng trắng bị dư ở email để tránh lỗi Format
                if (string.IsNullOrWhiteSpace(user.Email)) return;
                string cleanEmail = user.Email.Trim();

                MailMessage mail = new MailMessage();

                string btcEmail = "bbidxer@gmail.com";
                string btcPassword = "fuhj dypl euhn dvny";

                mail.From = new MailAddress(btcEmail, "Ban Tổ Chức Sự Kiện CLB");
                mail.To.Add(cleanEmail); // Truyền email đã được cắt khoảng trắng

                // Cập nhật tiêu đề Email
                mail.Subject = $"[VÉ THAM GIA] Xác nhận đăng ký sự kiện: {ev.Title}";

                // Cập nhật nội dung Email hiển thị rõ Mã vé
                mail.Body = $@"
Chào {user.FullName},

Chúc mừng bạn đã đăng ký thành công sự kiện của Câu lạc bộ!

THÔNG TIN VÉ THAM GIA:
-----------------------------------------
MÃ VÉ CỦA BẠN: {ticketCode}
-----------------------------------------

CHI TIẾT SỰ KIỆN:
- Tên sự kiện: {ev.Title}
- Thời gian: {ev.StartTime:dd/MM/yyyy HH:mm} - {ev.EndTime:HH:mm}
- Địa điểm: {ev.Location}

* Lưu ý: Vui lòng lưu lại Mã vé này hoặc ảnh chụp màn hình Email để thực hiện Check-in tại cổng vào sự kiện.

Hẹn gặp bạn tại sự kiện!
Ban Tổ Chức CLB.
";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(btcEmail, btcPassword);
                smtp.EnableSsl = true;

                await Task.Run(() => smtp.Send(mail));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}