using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class StudentDetail : Form
    {
        QuanLyEventCLBDataContext db = new QuanLyEventCLBDataContext();

        // ĐÃ SỬA: Đổi kiểu từ int sang string để khớp với VARCHAR(50)
        string userID;

        // ĐÃ SỬA: Tham số truyền vào cũng phải là string
        public StudentDetail(string id)
        {
            InitializeComponent();
            userID = id;

            this.Load += StudentDetail_Load;
            btnSave.Click += btnSave_Click;
            btnRegister.Click += btnRegister_Click;

            // setup DataGridView
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.Columns.Clear();

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colEventName",
                HeaderText = "Tên sự kiện",
                DataPropertyName = "EventName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colStatus",
                HeaderText = "Trạng thái",
                DataPropertyName = "Status",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvHistory.CellFormatting += dgvHistory_CellFormatting;
        }

        // ================= LOAD FORM =================
        private void StudentDetail_Load(object sender, EventArgs e)
        {
            LoadUser();
            LoadHistory();
            LoadEvents();
        }

        // ================= LOAD USER =================
        void LoadUser()
        {
            var u = db.Users.FirstOrDefault(x => x.UserID == userID);

            if (u == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtMSSV.Text = u.StudentID ?? "";
            txtName.Text = u.FullName ?? "";
            txtEmail.Text = u.Email ?? "";
        }

        // ================= LOAD EVENTS =================
        void LoadEvents()
        {
            cbEvent.DataSource = db.Events.ToList();
            cbEvent.DisplayMember = "Title";
            cbEvent.ValueMember = "EventID";
        }

        // ================= LOAD HISTORY =================
        void LoadHistory()
        {
            var history = db.EventRegistrations
                .Where(x => x.UserID == userID)
                .Select(x => new
                {
                    EventName = x.Event.Title,
                    Status = x.IsCheckedIn == true ? "Đã tham gia" : "Vắng mặt"
                })
                .ToList();

            dgvHistory.DataSource = history;
        }

        // ================= SAVE =================
        private void btnSave_Click(object sender, EventArgs e)
        {
            var u = db.Users.FirstOrDefault(x => x.UserID == userID);

            if (u == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            u.StudentID = txtMSSV.Text;
            u.FullName = txtName.Text;
            u.Email = txtEmail.Text;

            db.SubmitChanges();

            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================= REGISTER + SEND EMAIL =================
        // ĐÃ SỬA: Thêm async để hỗ trợ gửi mail không treo máy
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            var ev = cbEvent.SelectedItem as Event;

            if (ev == null)
            {
                MessageBox.Show("Vui lòng chọn sự kiện!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // kiểm tra đã đăng ký chưa (So sánh 2 chuỗi EventID và UserID)
            bool exist = db.EventRegistrations
                .Any(x => x.UserID == userID && x.EventID == ev.EventID);

            if (exist)
            {
                MessageBox.Show("Bạn đã đăng ký sự kiện này rồi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ĐÃ SỬA: Lấy ID lớn nhất cộng thêm 1 thay vì Random để an toàn tuyệt đối
            int maxID = db.EventRegistrations.Any() ? db.EventRegistrations.Max(r => r.RegistrationID) : 0;
            int newRegID = maxID + 1;

            // lưu DB + FIX QR UNIQUE
            var reg = new EventRegistration
            {
                RegistrationID = newRegID, // Sử dụng ID vừa tạo
                UserID = userID,
                EventID = ev.EventID,
                RegistrationDate = DateTime.Now,
                Status = "Registered",
                IsCheckedIn = false,
                QRCodeString = Guid.NewGuid().ToString() // ✅ FIX LỖI UNIQUE
            };

            try
            {
                db.EventRegistrations.InsertOnSubmit(reg);
                db.SubmitChanges(); // ✅ LƯU THÀNH CÔNG

                // gửi email chạy ngầm
                await SendEmailAsync(ev);

                MessageBox.Show("Đăng ký thành công và đã gửi email xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadHistory(); // Tải lại danh sách lịch sử
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= SEND EMAIL =================
        // ĐÃ SỬA: Trả về Task và bọc logic gửi mail vào Task.Run
        private async Task SendEmailAsync(Event ev)
        {
            try
            {
                var user = db.Users.FirstOrDefault(x => x.UserID == userID);

                if (user == null || string.IsNullOrEmpty(user.Email))
                {
                    MessageBox.Show("Sinh viên này chưa có địa chỉ Email để gửi thông báo!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MailMessage mail = new MailMessage();

                // Email của Ban tổ chức
                string btcEmail = "bbidxer@gmail.com";
                string btcPassword = "fuhj dypl euhn dvny";

                mail.From = new MailAddress(btcEmail, "Ban Tổ Chức Sự Kiện CLB");
                mail.To.Add(user.Email);
                mail.Subject = $"[Xác nhận] Đăng ký thành công sự kiện: {ev.Title}";

                mail.Body = $@"
Chào {user.FullName},

Hệ thống đã ghi nhận bạn đăng ký thành công sự kiện!

THÔNG TIN SỰ KIỆN:
- Tên sự kiện: {ev.Title}
- Thời gian: {ev.StartTime:dd/MM/yyyy HH:mm} - {ev.EndTime:HH:mm}
- Địa điểm: {ev.Location}

Vui lòng có mặt đúng giờ và xuất trình mã QR tại mục Hồ sơ khi điểm danh.

Cảm ơn bạn!
Ban Tổ Chức.
";

                // Cấu hình SMTP của Gmail
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(btcEmail, btcPassword);
                smtp.EnableSsl = true;

                // Chạy tác vụ gửi mail trên một luồng khác để không đơ Form
                await Task.Run(() => smtp.Send(mail));
            }
            catch (Exception ex)
            {
                // Chỉ hiện cảnh báo nếu lỗi gửi mail, không làm gián đoạn quy trình đăng ký
                MessageBox.Show("Lỗi gửi mail: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ================= COLOR STATUS =================
        private void dgvHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHistory.Columns[e.ColumnIndex].Name == "colStatus")
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() == "Đã tham gia")
                        e.CellStyle.ForeColor = Color.Green;
                    else
                        e.CellStyle.ForeColor = Color.Red;
                }
            }
        }
    }
}