using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace Project_Angile
{
    public partial class frmSelfCheckIn : Form
    {
        private string connectionString = Project_Angile.Properties.Settings.Default.QuanLyEnventCLBConnectionString;
        private readonly string tsvUrl = "https://docs.google.com/spreadsheets/d/e/2PACX-1vTyc4FWCaf4N97H5doqLOs8BF8WzJmEIOlSMupQD2OFQgvHH0s70og5CKLJl-yqArurEU1pE2D_GJlu/pub?output=tsv";

        public frmSelfCheckIn()
        {
            InitializeComponent();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            SetupUI();
            LoadEventList();
            clbEvents.ItemCheck += (s, e) => this.BeginInvoke(new MethodInvoker(RefreshGridWithFilter));
        }

        private void SetupUI()
        {
            this.Text = "DASHBOARD ĐIỂM DANH - QUẢN LÝ EVENT CLB";
            dgvLiveCheckIn.ReadOnly = true;
            dgvLiveCheckIn.BackgroundColor = Color.White;
            dgvLiveCheckIn.RowHeadersVisible = false;
            dgvLiveCheckIn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            timerSync.Interval = 5000;
            timerSync.Enabled = true;
        }

        private void LoadEventList()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT EventID, Title FROM [Event]", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    clbEvents.DataSource = dt;
                    clbEvents.DisplayMember = "Title";
                    clbEvents.ValueMember = "EventID";
                }
                catch (Exception ex) { MessageBox.Show("Lỗi tải Event: " + ex.Message); }
            }
        }

        private async void timerSync_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "Đang quét Cloud: " + DateTime.Now.ToString("HH:mm:ss");
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string noCacheUrl = tsvUrl + "&t=" + DateTime.Now.Ticks;
                    string tsvData = await client.GetStringAsync(noCacheUrl);
                    string[] rows = tsvData.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string row in rows.Skip(1))
                    {
                        string[] cols = row.Split('\t');

                        if (cols.Length >= 5)
                        {
                            string mssv = cols[1].Trim();
                            string name = cols[2].Trim();
                            string mail = cols[3].Trim();
                            string eId = ExtractId(cols[4]);

                            string gender = cols.Length > 5 ? cols[5].Trim() : "";
                            string className = cols.Length > 6 ? cols[6].Trim() : "";

                            if (!string.IsNullOrEmpty(eId) && !string.IsNullOrEmpty(mssv))
                            {
                                SyncToDatabase(eId, mssv, name, mail, gender, className);
                            }
                        }
                    }
                    RefreshGridWithFilter();
                }
            }
            catch (Exception ex) { lblStatus.Text = "Lỗi kết nối: " + ex.Message; }
        }

        private void SyncToDatabase(string eId, string mssv, string name, string mail, string gender, string className)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string tempQR = "GF_" + eId + "_" + mssv;

                    // ĐÃ SỬA: Logic ràng buộc chặt chẽ - Chỉ cho phép check-in nếu ĐÃ CÓ TÀI KHOẢN và ĐÃ ĐĂNG KÝ
                    string masterSql = @"
                        DECLARE @ActualUID VARCHAR(50);
                        
                        -- 1. Tìm tài khoản dựa trên MSSV nhập từ Google Form
                        SELECT @ActualUID = UserID FROM [User] WHERE StudentID = @MSSV;

                        -- KIỂM TRA ĐIỀU KIỆN 1: TÀI KHOẢN CÓ TỒN TẠI KHÔNG?
                        IF @ActualUID IS NOT NULL
                        BEGIN
                            -- (Tùy chọn) Vẫn cập nhật lại thông tin cá nhân mới nhất
                            UPDATE [User] 
                            SET FullName = @Name, Email = @Mail, Gender = @Gender, Class = @Class 
                            WHERE UserID = @ActualUID;

                            -- KIỂM TRA ĐIỀU KIỆN 2: ĐÃ ĐĂNG KÝ SỰ KIỆN NÀY CHƯA?
                            IF EXISTS (SELECT 1 FROM EventRegistration WHERE EventID = @EID AND UserID = @ActualUID)
                            BEGIN
                                -- THỎA MÃN CẢ 2 ĐIỀU KIỆN: Tiến hành Check-in
                                UPDATE EventRegistration 
                                SET IsCheckedIn = 1, CheckInTime = GETDATE(), CheckInMethod = N'Google Form' 
                                WHERE EventID = @EID AND UserID = @ActualUID AND (IsCheckedIn = 0 OR IsCheckedIn IS NULL);
                            END
                            -- Nếu chưa đăng ký sự kiện, khối IF này bị bỏ qua (không check-in)
                        END
                        -- Nếu @ActualUID IS NULL (chưa có tài khoản), toàn bộ khối lệnh bị bỏ qua (không làm gì cả)
                    ";

                    SqlCommand cmdMaster = new SqlCommand(masterSql, conn, trans);
                    cmdMaster.Parameters.AddWithValue("@EID", eId);
                    cmdMaster.Parameters.AddWithValue("@MSSV", mssv);
                    cmdMaster.Parameters.AddWithValue("@Name", name);
                    cmdMaster.Parameters.AddWithValue("@Mail", mail);
                    cmdMaster.Parameters.AddWithValue("@QR", tempQR);

                    cmdMaster.Parameters.AddWithValue("@Gender", string.IsNullOrEmpty(gender) ? (object)DBNull.Value : gender);
                    cmdMaster.Parameters.AddWithValue("@Class", string.IsNullOrEmpty(className) ? (object)DBNull.Value : className);

                    cmdMaster.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    System.Diagnostics.Debug.WriteLine("Lỗi đồng bộ dòng " + mssv + ": " + ex.Message);
                }
            }
        }

        private void RefreshGridWithFilter()
        {
            List<string> selectedIds = new List<string>();
            foreach (var item in clbEvents.CheckedItems)
            {
                DataRowView row = item as DataRowView;
                selectedIds.Add(row["EventID"].ToString());
            }

            if (selectedIds.Count == 0)
            {
                dgvLiveCheckIn.DataSource = null;
                lblEventName.Text = "VUI LÒNG CHỌN SỰ KIỆN";
                lblEventName.ForeColor = Color.Gray;
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT E.Title AS [SỰ KIỆN], U.StudentID AS [MSSV], 
                           U.FullName AS [HỌ TÊN], 
                           U.Gender AS [GIỚI TÍNH], U.Class AS [LỚP],
                           CASE WHEN R.IsCheckedIn = 1 THEN N'Đã Check-in' ELSE N'Mới đăng ký' END AS [TRẠNG THÁI],
                           FORMAT(R.CheckInTime, 'HH:mm:ss') AS [GIỜ VÀO]
                    FROM EventRegistration R 
                    JOIN [User] U ON R.UserID = U.UserID 
                    JOIN [Event] E ON R.EventID = E.EventID
                    WHERE E.EventID IN (" + string.Join(",", selectedIds.Select(id => $"'{id}'")) + ")" +
                  " ORDER BY R.CheckInTime DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLiveCheckIn.DataSource = dt;

                if (dgvLiveCheckIn.Columns.Count > 0)
                {
                    dgvLiveCheckIn.Columns["SỰ KIỆN"].FillWeight = 25;
                    dgvLiveCheckIn.Columns["HỌ TÊN"].FillWeight = 20;
                    dgvLiveCheckIn.Columns["MSSV"].FillWeight = 15;
                    dgvLiveCheckIn.Columns["GIỚI TÍNH"].FillWeight = 10;
                    dgvLiveCheckIn.Columns["LỚP"].FillWeight = 10;
                    dgvLiveCheckIn.Columns["TRẠNG THÁI"].FillWeight = 10;
                    dgvLiveCheckIn.Columns["GIỜ VÀO"].FillWeight = 10;
                }

                if (selectedIds.Count == 1)
                {
                    lblEventName.Text = "ĐANG XEM: " + dt.Rows.Count + " NGƯỜI ĐĂNG KÝ";
                    lblEventName.ForeColor = Color.DarkBlue;
                }
                else
                {
                    lblEventName.Text = "BÁO CÁO TỔNG HỢP " + selectedIds.Count + " SỰ KIỆN (" + dt.Rows.Count + " người)";
                    lblEventName.ForeColor = Color.DarkGreen;
                }
            }
        }

        private string ExtractId(string input)
        {
            try
            {
                int eventNumber = int.Parse(input.Split('-')[0].Trim());
                return "E" + eventNumber.ToString("D2");
            }
            catch { return string.Empty; }
        }

        private void frmSelfCheckIn_Load(object sender, EventArgs e)
        {

        }
    }
}