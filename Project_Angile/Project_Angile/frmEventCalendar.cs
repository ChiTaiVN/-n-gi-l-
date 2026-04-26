using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class frmEventCalendar : Form
    {
        // 1. Class Model: Chứa dữ liệu sau khi truy vấn từ DBML
        public class EventModel
        {
            public string EventID { get; set; }
            public string Title { get; set; }
            public DateTime StartTime { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
        }

        private List<EventModel> realEvents;

        // 2. Biến lưu trữ sự kiện đang được chọn để truyền sang Form Chi tiết
        private EventModel currentSelectedEvent = null;

        // ĐÃ SỬA: Thêm biến lưu ID người dùng đang đăng nhập
        private string currentUserID;

        // ĐÃ SỬA: Constructor giờ nhận thêm ID người dùng (userId)
        public frmEventCalendar(string userId)
        {
            InitializeComponent();
            currentUserID = userId; // Nhận và lưu lại ID thật của user
            LoadEventsFromDatabase();
            HighlightEventDates();
        }

        // 3. Hàm kết nối và lấy dữ liệu bằng LINQ
        private void LoadEventsFromDatabase()
        {
            realEvents = new List<EventModel>();

            try
            {
                using (var db = new QuanLyEventCLBDataContext())
                {
                    var query = from ev in db.Events
                                select new EventModel
                                {
                                    EventID = ev.EventID,
                                    Title = ev.Title,
                                    StartTime = ev.StartTime,
                                    Location = ev.Location,
                                    Description = ev.Description
                                };

                    realEvents = query.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. Hàm in đậm ngày
        private void HighlightEventDates()
        {
            foreach (var ev in realEvents)
            {
                monthCalendarEvents.AddBoldedDate(ev.StartTime);
            }
            monthCalendarEvents.UpdateBoldedDates();
        }

        // 5. Hàm click chọn ngày
        private void monthCalendarEvents_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = e.Start.Date;

            currentSelectedEvent = realEvents.FirstOrDefault(ev => ev.StartTime.Date == selectedDate);

            if (currentSelectedEvent != null)
            {
                lblEventTitle.Text = currentSelectedEvent.Title;
                lblEventTime.Text = "Thời gian: " + currentSelectedEvent.StartTime.ToString("HH:mm - dd/MM/yyyy");
                lblEventLocation.Text = "Địa điểm: " + currentSelectedEvent.Location;
                rtbEventDescription.Text = currentSelectedEvent.Description;
            }
            else
            {
                lblEventTitle.Text = "Không có sự kiện";
                lblEventTime.Text = "Thời gian: --/--/----";
                lblEventLocation.Text = "Địa điểm: ---";
                rtbEventDescription.Text = "Ngày này hiện chưa có sự kiện nào được lên lịch.";
            }
        }

        // 6. XỬ LÝ NÚT CHUYỂN SANG FORM CHI TIẾT
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (currentSelectedEvent != null)
            {
                // ĐÃ SỬA: Truyền đủ 2 tham số (ID sự kiện, ID người dùng) sang form chi tiết
                frmEventDetail detailForm = new frmEventDetail(currentSelectedEvent.EventID, currentUserID);
                detailForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ngày có sự kiện (ngày in đậm) trên lịch trước khi xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmEventCalendar_Load(object sender, EventArgs e)
        {

        }
    }
}