using System;
using System.Linq;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class frmFeedBack : Form
    {
        public frmFeedBack()
        {
            InitializeComponent();
        }

        private void btncheckin_Click(object sender, EventArgs e)
        {
            string mssv = txtmssv.Text.Trim();
            string mave = txtmave.Text.Trim();
            // ĐÃ SỬA: Giữ nguyên kiểu chuỗi (string) cho EventID
            string eventId = txtmasukiencheckin.Text.Trim();

            if (string.IsNullOrEmpty(eventId))
            {
                MessageBox.Show("Vui lòng nhập mã sự kiện!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(mssv) && string.IsNullOrEmpty(mave))
            {
                MessageBox.Show("Vui lòng nhập MSSV hoặc Mã vé!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new QuanLyEventCLBDataContext())
                {
                    EventRegistration reg = null;

                    // 1. Tìm thông tin đăng ký dựa theo MSSV hoặc Mã vé
                    if (!string.IsNullOrEmpty(mssv))
                    {
                        // Truy xuất thông qua bảng User được LINQ nối sẵn (er.User.StudentID)
                        reg = db.EventRegistrations.FirstOrDefault(er => er.User.StudentID == mssv && er.EventID == eventId);
                    }
                    else
                    {
                        reg = db.EventRegistrations.FirstOrDefault(er => er.QRCodeString == mave && er.EventID == eventId);
                    }

                    // 2. Kiểm tra tồn tại
                    if (reg == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin đăng ký cho sự kiện này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // 3. Kiểm tra xem đã Check-in trước đó chưa (Xử lý an toàn với kiểu nullable bool)
                    if (reg.IsCheckedIn == true)
                    {
                        // Nếu đã check-in rồi, thông báo rõ là bằng phương thức nào luôn
                        string phuongThuc = string.IsNullOrEmpty(reg.CheckInMethod) ? "không xác định" : reg.CheckInMethod;
                        MessageBox.Show($"Bạn đã check-in trước đó rồi! (Phương thức: {phuongThuc})", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // 4. Tiến hành Check-in
                    reg.IsCheckedIn = true;
                    reg.CheckInTime = DateTime.Now;
                    // ĐÃ THÊM: Lưu phương thức check-in là "Trực tiếp" để khóa luồng Google Form (SelfCheckIn) lại
                    reg.CheckInMethod = "Trực tiếp";

                    db.SubmitChanges(); // Lưu thay đổi xuống CSDL

                    MessageBox.Show("Check-in trực tiếp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndanhgia_Click(object sender, EventArgs e)
        {
            string mssv = txtmssv.Text.Trim();
            string eventId = txtmasukiencheckin.Text.Trim(); // Giữ nguyên chuỗi
            string ratingText = txtdanhgia.Text.Trim();
            string comment = txtComment.Text.Trim();

            if (string.IsNullOrEmpty(mssv) || string.IsNullOrEmpty(eventId) || string.IsNullOrEmpty(ratingText))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (MSSV, Mã sự kiện, Đánh giá)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Rating thì vẫn là số nguyên (từ 1 đến 5) nên giữ nguyên int.TryParse
            if (!int.TryParse(ratingText, out int rating) || rating < 1 || rating > 5)
            {
                MessageBox.Show("Đánh giá phải là số (từ 1 đến 5)!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new QuanLyEventCLBDataContext())
                {
                    // 1. Kiểm tra xem sinh viên này đã check-in sự kiện chưa
                    var reg = db.EventRegistrations.FirstOrDefault(er => er.User.StudentID == mssv && er.EventID == eventId && er.IsCheckedIn == true);

                    if (reg == null)
                    {
                        MessageBox.Show("Bạn chưa check-in nên không thể đánh giá sự kiện này!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // ĐÃ SỬA: Tạo mã FeedbackID bằng cách lấy ID lớn nhất + 1 để tránh trùng lặp
                    int maxFeedbackID = db.Feedbacks.Any() ? db.Feedbacks.Max(f => f.FeedbackID) : 0;
                    int newFeedbackID = maxFeedbackID + 1;

                    // 2. Tạo record Đánh giá mới
                    Feedback newFeedback = new Feedback
                    {
                        FeedbackID = newFeedbackID,
                        EventID = eventId,
                        UserID = reg.UserID,
                        Rating = rating,
                        Comment = comment,
                        SubmittedAt = DateTime.Now
                    };

                    db.Feedbacks.InsertOnSubmit(newFeedback);
                    db.SubmitChanges(); // Lưu xuống DB

                    MessageBox.Show("Gửi đánh giá thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset ô comment và rating sau khi đánh giá xong
                    txtdanhgia.Clear();
                    txtComment.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmssv_TextChanged(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void txtmave_TextChanged(object sender, EventArgs e) { }
        private void txtdanhgia_TextChanged(object sender, EventArgs e) { }
        private void txtmask_TextChanged(object sender, EventArgs e) { }
        private void lbmask_Click(object sender, EventArgs e) { }
        private void txtmasukiencheckin_TextChanged(object sender, EventArgs e) { }
        private void txtComment_TextChanged(object sender, EventArgs e) { }
        private void lbgopy_Click(object sender, EventArgs e) { }
        private void txtmaskcheckin_TextChanged(object sender, EventArgs e) { }
        private void txtmasukiencheckin_TextChanged_1(object sender, EventArgs e) { }

        private void frmFeedBack_Load(object sender, EventArgs e)
        {

        }
    }
}