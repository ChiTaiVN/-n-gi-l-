using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class frmEventSearch : Form
    {
        // ĐÃ SỬA: Thêm biến lưu giữ ID của người dùng đang đăng nhập
        private string currentUserID;

        // ĐÃ SỬA: Bổ sung tham số string userId vào constructor
        public frmEventSearch(string userId)
        {
            InitializeComponent();
            currentUserID = userId; // Nhận và lưu lại ID thật
            InitFilters(); // Nạp dữ liệu giả cho các ComboBox
        }

        private void InitFilters()
        {
            // Cài đặt dữ liệu cho Dropdown Danh mục
            cboCategory.Items.Add("Tất cả danh mục");
            cboCategory.Items.Add("Học thuật");
            cboCategory.Items.Add("Kỹ năng");
            cboCategory.Items.Add("Thể thao");
            cboCategory.Items.Add("Triển lãm");
            cboCategory.SelectedIndex = 0; // Mặc định chọn "Tất cả"

            // Cài đặt dữ liệu cho Dropdown Trạng thái
            cboStatus.Items.Add("Tất cả trạng thái");
            cboStatus.Items.Add("Upcoming");
            cboStatus.Items.Add("Completed");
            cboStatus.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QuanLyEventCLBDataContext())
                {
                    // 1. Khởi tạo câu truy vấn gốc (Lấy tất cả)
                    var query = db.Events.AsQueryable();

                    // 2. Thêm điều kiện lọc theo Tên (Tìm kiếm tương đối giống LIKE %...%)
                    if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                    {
                        string searchKeyword = txtSearchName.Text.Trim().ToLower();
                        query = query.Where(ev => ev.Title.ToLower().Contains(searchKeyword));
                    }

                    // 3. Thêm điều kiện lọc Danh mục
                    if (cboCategory.SelectedIndex > 0)
                    {
                        string selectedCategory = cboCategory.SelectedItem.ToString();
                        query = query.Where(ev => ev.Category == selectedCategory);
                    }

                    // 4. Thêm điều kiện lọc Trạng thái
                    if (cboStatus.SelectedIndex > 0)
                    {
                        string selectedStatus = cboStatus.SelectedItem.ToString();
                        query = query.Where(ev => ev.Status == selectedStatus);
                    }

                    // 5. Chọn các cột cần hiển thị và đẩy ra List
                    var result = query.Select(ev => new
                    {
                        EventID = ev.EventID, // Đã tự động là string từ DBML
                        TenSuKien = ev.Title,
                        DanhMuc = ev.Category,
                        ThoiGian = ev.StartTime,
                        TrangThai = ev.Status
                    }).ToList();

                    // 6. Kiểm tra Acceptance Criteria: "Không tìm thấy sự kiện"
                    if (result.Count == 0)
                    {
                        dgvEvents.DataSource = null; // Xóa lưới
                        lblMessage.Visible = true;   // Hiện dòng chữ đỏ (Không tìm thấy...)
                    }
                    else
                    {
                        dgvEvents.DataSource = result; // Đổ dữ liệu vào lưới
                        lblMessage.Visible = false;    // Ẩn dòng chữ đỏ đi

                        // Định dạng lại tiêu đề cột cho đẹp
                        dgvEvents.Columns["EventID"].Visible = false; // Ẩn cột ID đi
                        dgvEvents.Columns["TenSuKien"].HeaderText = "Tên sự kiện";
                        dgvEvents.Columns["DanhMuc"].HeaderText = "Danh mục";
                        dgvEvents.Columns["ThoiGian"].HeaderText = "Thời gian";
                        dgvEvents.Columns["TrangThai"].HeaderText = "Trạng thái";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn LINQ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEvents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra xem người dùng có click trúng một dòng dữ liệu hợp lệ không 
            // (Tránh trường hợp click nhầm vào thanh tiêu đề cột gây lỗi)
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Lấy mã EventID dưới dạng chuỗi (string)
                    string selectedEventId = dgvEvents.Rows[e.RowIndex].Cells["EventID"].Value.ToString();

                    // ĐÃ SỬA: Mở Form Chi tiết sự kiện và truyền đủ 2 tham số: ID sự kiện và ID người dùng
                    frmEventDetail detailForm = new frmEventDetail(selectedEventId, currentUserID);
                    detailForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở chi tiết sự kiện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmEventSearch_Load(object sender, EventArgs e)
        {

        }
    }
}