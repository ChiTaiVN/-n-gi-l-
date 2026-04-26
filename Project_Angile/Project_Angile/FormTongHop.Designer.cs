namespace Project_Angile
{
    partial class FormTongHop
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnForm1 = new System.Windows.Forms.Button();
            this.btnLeaderboard = new System.Windows.Forms.Button();
            this.btnSuKienCLB = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.btnStudentInfo = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnfbcheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForm1
            // 
            this.btnForm1.Location = new System.Drawing.Point(30, 30);
            this.btnForm1.Name = "btnForm1";
            this.btnForm1.Size = new System.Drawing.Size(200, 50);
            this.btnForm1.TabIndex = 7;
            this.btnForm1.Text = "Quản lý & Thống kê Sự kiện";
            this.btnForm1.Click += new System.EventHandler(this.btnForm1_Click);
            // 
            // btnLeaderboard
            // 
            this.btnLeaderboard.Location = new System.Drawing.Point(30, 90);
            this.btnLeaderboard.Name = "btnLeaderboard";
            this.btnLeaderboard.Size = new System.Drawing.Size(200, 50);
            this.btnLeaderboard.TabIndex = 6;
            this.btnLeaderboard.Text = "Bảng xếp hạng (Leaderboard)";
            this.btnLeaderboard.Click += new System.EventHandler(this.btnLeaderboard_Click);
            // 
            // btnSuKienCLB
            // 
            this.btnSuKienCLB.Location = new System.Drawing.Point(250, 30);
            this.btnSuKienCLB.Name = "btnSuKienCLB";
            this.btnSuKienCLB.Size = new System.Drawing.Size(200, 50);
            this.btnSuKienCLB.TabIndex = 5;
            this.btnSuKienCLB.Text = "Quản lý Sự kiện CLB";
            this.btnSuKienCLB.Click += new System.EventHandler(this.btnSuKienCLB_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(250, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(200, 50);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm kiếm Sự kiện";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCalendar
            // 
            this.btnCalendar.Location = new System.Drawing.Point(250, 150);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(200, 50);
            this.btnCalendar.TabIndex = 3;
            this.btnCalendar.Text = "Lịch Sự kiện";
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // btnStudentInfo
            // 
            this.btnStudentInfo.Location = new System.Drawing.Point(470, 30);
            this.btnStudentInfo.Name = "btnStudentInfo";
            this.btnStudentInfo.Size = new System.Drawing.Size(200, 50);
            this.btnStudentInfo.TabIndex = 2;
            this.btnStudentInfo.Text = "Thông tin Sinh viên";
            this.btnStudentInfo.Click += new System.EventHandler(this.btnStudentInfo_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Location = new System.Drawing.Point(470, 90);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(200, 50);
            this.btnCheckIn.TabIndex = 1;
            this.btnCheckIn.Text = "Điểm danh (Self Check-in)";
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(30, 220);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(640, 50);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Hệ thống Đăng nhập / Đăng ký";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnfbcheck
            // 
            this.btnfbcheck.Location = new System.Drawing.Point(470, 150);
            this.btnfbcheck.Name = "btnfbcheck";
            this.btnfbcheck.Size = new System.Drawing.Size(200, 50);
            this.btnfbcheck.TabIndex = 8;
            this.btnfbcheck.Text = "Check-in thủ công + Feed back";
            this.btnfbcheck.Click += new System.EventHandler(this.btnfbcheck_Click);
            // 
            // FormTongHop
            // 
            this.ClientSize = new System.Drawing.Size(700, 300);
            this.Controls.Add(this.btnfbcheck);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnStudentInfo);
            this.Controls.Add(this.btnCalendar);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSuKienCLB);
            this.Controls.Add(this.btnLeaderboard);
            this.Controls.Add(this.btnForm1);
            this.Name = "FormTongHop";
            this.Text = "Menu Tổng Hợp Chạy Dự Án";
            this.Load += new System.EventHandler(this.FormTongHop_Load);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnForm1;
        private System.Windows.Forms.Button btnLeaderboard;
        private System.Windows.Forms.Button btnSuKienCLB;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCalendar;
        private System.Windows.Forms.Button btnStudentInfo;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnfbcheck;
    }
}