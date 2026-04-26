using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class frmSuKienCLB : Form
    {
        QuanLyEventCLBDataContext db = new QuanLyEventCLBDataContext();
        public frmSuKienCLB()
        {
            InitializeComponent();
            InitComboBoxes(); // Khởi tạo dữ liệu ComboBox chuẩn
            LoadData();
        }

        // ĐÃ SỬA: Đưa Trạng thái về đúng chuẩn Tiếng Việt của bạn
        private void InitComboBoxes()
        {
            // Set data chuẩn cho Danh mục
            cbDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDanhMuc.Items.Clear();
            cbDanhMuc.Items.Add("Học thuật");
            cbDanhMuc.Items.Add("Kỹ năng");
            cbDanhMuc.Items.Add("Thể thao");
            cbDanhMuc.Items.Add("Triển lãm");

            // Set data chuẩn cho Trạng thái (Tiếng Việt)
            cbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Đang lên kế hoạch");
            cbTrangThai.Items.Add("Đang tổ chức");
            cbTrangThai.Items.Add("Đã tổ chức");
        }

        void LoadData()
        {
            dataGridView1.DataSource = null;

            var dbNew = new QuanLyEventCLBDataContext();

            var ds = dbNew.Events
                .Select(x => new
                {
                    x.EventID,
                    x.Title,
                    x.Category,
                    x.StartTime,
                    x.EndTime,
                    x.Location,
                    x.Description,
                    x.Status,
                    MaxAttendees = x.MaxAttendees,
                    SoLuongDangKy = dbNew.EventRegistrations.Count(r => r.EventID == x.EventID && r.Status == "Registered")
                })
                .Take(50)
                .ToList();

            dataGridView1.DataSource = ds;

            if (dataGridView1.Columns["Category"] != null)
                dataGridView1.Columns["Category"].HeaderText = "Danh mục";
            if (dataGridView1.Columns["MaxAttendees"] != null)
                dataGridView1.Columns["MaxAttendees"].HeaderText = "Sức chứa";
            if (dataGridView1.Columns["SoLuongDangKy"] != null)
                dataGridView1.Columns["SoLuongDangKy"].HeaderText = "Số lượng ĐK";
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        // KT dữ liệu
        bool ValidateForm()
        {
            List<string> loi = new List<string>();

            if (string.IsNullOrWhiteSpace(txtMSK.Text))
                loi.Add("Mã sự kiện");

            if (string.IsNullOrWhiteSpace(txtTenSK.Text))
                loi.Add("Tên sự kiện");

            if (string.IsNullOrWhiteSpace(cbDanhMuc.Text))
                loi.Add("Danh mục sự kiện");

            if (dayNgayKT.Value <= dayNgayBD.Value)
                loi.Add("Thời gian không hợp lệ");

            if (string.IsNullOrWhiteSpace(txtDiaDiem.Text))
                loi.Add("Địa điểm");

            int maxAt = 0;
            if (string.IsNullOrWhiteSpace(txtSoLuongMax.Text) || !int.TryParse(txtSoLuongMax.Text, out maxAt) || maxAt <= 0)
                loi.Add("Số lượng tối đa (phải là số > 0)");

            if (string.IsNullOrWhiteSpace(txtMoTa.Text))
                loi.Add("Mô tả");

            if (loi.Count > 0)
            {
                MessageBox.Show("Thiếu/Sai: " + string.Join(", ", loi), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void lbMaSK_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void lbNgayKT_Click(object sender, EventArgs e) { }
        private void btSuKien_Click(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            txtMSK.Text = row.Cells["EventID"].Value?.ToString().Trim();
            txtTenSK.Text = row.Cells["Title"].Value?.ToString().Trim();
            cbDanhMuc.Text = row.Cells["Category"].Value?.ToString().Trim();
            dayNgayBD.Value = Convert.ToDateTime(row.Cells["StartTime"].Value);
            dayNgayKT.Value = Convert.ToDateTime(row.Cells["EndTime"].Value);
            txtDiaDiem.Text = row.Cells["Location"].Value?.ToString().Trim();
            txtSoLuongMax.Text = row.Cells["MaxAttendees"].Value?.ToString().Trim();
            txtMoTa.Text = row.Cells["Description"].Value?.ToString().Trim();

            // XỬ LÝ TRẠNG THÁI: Dịch data cũ (Tiếng Anh) sang UI mới (Tiếng Việt)
            string statusFromDB = row.Cells["Status"].Value?.ToString().Trim();
            if (statusFromDB == "Upcoming") cbTrangThai.Text = "Đang lên kế hoạch";
            else if (statusFromDB == "Ongoing" || statusFromDB == "Active") cbTrangThai.Text = "Đang tổ chức";
            else if (statusFromDB == "Completed") cbTrangThai.Text = "Đã tổ chức";
            else cbTrangThai.Text = statusFromDB; // Nếu đã là tiếng Việt thì gán bình thường
        }

        private void lbTenSk_Click(object sender, EventArgs e) { }
        private void txtMSK_TextChanged(object sender, EventArgs e) { }
        private void txtTenSK_TextChanged(object sender, EventArgs e) { }
        private void dayNgayBD_ValueChanged(object sender, EventArgs e) { }
        private void dayNgayKT_ValueChanged(object sender, EventArgs e) { }
        private void txtDiaDiem_TextChanged(object sender, EventArgs e) { }
        private void txtMoTa_TextChanged(object sender, EventArgs e) { }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                string newId = txtMSK.Text.Trim();
                if (db.Events.Any(x => x.EventID == newId))
                {
                    MessageBox.Show("Mã sự kiện này đã tồn tại! Vui lòng nhập mã khác (VD: E06).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var ev = new Event()
                {
                    EventID = newId,
                    Title = txtTenSK.Text,
                    Category = cbDanhMuc.Text,
                    StartTime = dayNgayBD.Value,
                    EndTime = dayNgayKT.Value,
                    Location = txtDiaDiem.Text,
                    MaxAttendees = int.Parse(txtSoLuongMax.Text),
                    Description = txtMoTa.Text,
                    Status = cbTrangThai.Text
                };

                db.Events.InsertOnSubmit(ev);
                db.SubmitChanges();

                LoadData();

                MessageBox.Show("Tạo sự kiện thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string id = txtMSK.Text.Trim();

            var ev = db.Events.FirstOrDefault(x => x.EventID == id);

            if (ev == null)
            {
                MessageBox.Show("Không tìm thấy sự kiện", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ev.Title = txtTenSK.Text;
            ev.Category = cbDanhMuc.Text;
            ev.StartTime = dayNgayBD.Value;
            ev.EndTime = dayNgayKT.Value;
            ev.Location = txtDiaDiem.Text;
            ev.MaxAttendees = int.Parse(txtSoLuongMax.Text);
            ev.Description = txtMoTa.Text;
            ev.Status = cbTrangThai.Text;

            db.SubmitChanges();

            LoadData();

            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Load(object sender, EventArgs e) { }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSK.Text))
            {
                MessageBox.Show("Vui lòng chọn sự kiện", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = txtMSK.Text.Trim();

            var ev = db.Events.FirstOrDefault(x => x.EventID == id);

            if (ev == null)
            {
                MessageBox.Show("Không tìm thấy sự kiện", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    db.Events.DeleteOnSubmit(ev);
                    db.SubmitChanges();

                    LoadData();

                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa sự kiện này vì đã có dữ liệu liên quan (Sinh viên đăng ký, Đánh giá...). Lỗi chi tiết: " + ex.Message, "Lỗi Khóa Ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            txtMSK.Text = row.Cells["EventID"].Value?.ToString().Trim();
            txtTenSK.Text = row.Cells["Title"].Value?.ToString().Trim();
            cbDanhMuc.Text = row.Cells["Category"].Value?.ToString().Trim();
            dayNgayBD.Value = Convert.ToDateTime(row.Cells["StartTime"].Value);
            dayNgayKT.Value = Convert.ToDateTime(row.Cells["EndTime"].Value);
            txtDiaDiem.Text = row.Cells["Location"].Value?.ToString().Trim();
            txtSoLuongMax.Text = row.Cells["MaxAttendees"].Value?.ToString().Trim();
            txtMoTa.Text = row.Cells["Description"].Value?.ToString().Trim();

            // XỬ LÝ TRẠNG THÁI: Dịch data cũ (Tiếng Anh) sang UI mới (Tiếng Việt)
            string statusFromDB = row.Cells["Status"].Value?.ToString().Trim();
            if (statusFromDB == "Upcoming") cbTrangThai.Text = "Đang lên kế hoạch";
            else if (statusFromDB == "Ongoing" || statusFromDB == "Active") cbTrangThai.Text = "Đang tổ chức";
            else if (statusFromDB == "Completed") cbTrangThai.Text = "Đã tổ chức";
            else cbTrangThai.Text = statusFromDB; // Nếu đã là tiếng Việt thì gán bình thường
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e) { }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                LoadData();
                return;
            }

            string keyword = txtTimKiem.Text.ToLower();

            var ketQua = db.Events
                .Where(x => x.Title.ToLower().Contains(keyword))
                .Select(x => new
                {
                    x.EventID,
                    x.Title,
                    x.Category,
                    x.StartTime,
                    x.EndTime,
                    x.Location,
                    x.Description,
                    x.Status,
                    MaxAttendees = x.MaxAttendees,
                    SoLuongDangKy = db.EventRegistrations.Count(r => r.EventID == x.EventID && r.Status == "Registered")
                })
                .ToList();

            dataGridView1.DataSource = ketQua;
        }

        private void cbFilterTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string trangThai = cbFilterTrangThai.Text;

            if (trangThai == "Tất cả")
            {
                LoadData();
                return;
            }

            var ketQua = db.Events
                .Where(x => x.Status == trangThai)
                .Select(x => new
                {
                    x.EventID,
                    x.Title,
                    x.Category,
                    x.StartTime,
                    x.EndTime,
                    x.Location,
                    x.Description,
                    x.Status,
                    MaxAttendees = x.MaxAttendees,
                    SoLuongDangKy = db.EventRegistrations.Count(r => r.EventID == x.EventID && r.Status == "Registered")
                })
                .ToList();

            dataGridView1.DataSource = ketQua;
        }

        private void txtSoLuongMax_TextChanged(object sender, EventArgs e) { }
        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}