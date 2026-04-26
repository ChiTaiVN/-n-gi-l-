namespace Project_Angile
{
    partial class frmEventCalendar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthCalendarEvents = new System.Windows.Forms.MonthCalendar();
            this.lblEventTitle = new System.Windows.Forms.Label();
            this.lblEventTime = new System.Windows.Forms.Label();
            this.lblEventLocation = new System.Windows.Forms.Label();
            this.rtbEventDescription = new System.Windows.Forms.RichTextBox();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendarEvents
            // 
            this.monthCalendarEvents.Location = new System.Drawing.Point(35, 22);
            this.monthCalendarEvents.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.monthCalendarEvents.Name = "monthCalendarEvents";
            this.monthCalendarEvents.TabIndex = 0;
            this.monthCalendarEvents.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendarEvents_DateChanged);
            // 
            // lblEventTitle
            // 
            this.lblEventTitle.AutoSize = true;
            this.lblEventTitle.Location = new System.Drawing.Point(410, 35);
            this.lblEventTitle.Name = "lblEventTitle";
            this.lblEventTitle.Size = new System.Drawing.Size(81, 16);
            this.lblEventTitle.TabIndex = 1;
            this.lblEventTitle.Text = "lblEventTitle";
            // 
            // lblEventTime
            // 
            this.lblEventTime.AutoSize = true;
            this.lblEventTime.Location = new System.Drawing.Point(410, 78);
            this.lblEventTime.Name = "lblEventTime";
            this.lblEventTime.Size = new System.Drawing.Size(86, 16);
            this.lblEventTime.TabIndex = 2;
            this.lblEventTime.Text = "lblEventTime";
            // 
            // lblEventLocation
            // 
            this.lblEventLocation.AutoSize = true;
            this.lblEventLocation.Location = new System.Drawing.Point(410, 115);
            this.lblEventLocation.Name = "lblEventLocation";
            this.lblEventLocation.Size = new System.Drawing.Size(106, 16);
            this.lblEventLocation.TabIndex = 3;
            this.lblEventLocation.Text = "lblEventLocation";
            // 
            // rtbEventDescription
            // 
            this.rtbEventDescription.Location = new System.Drawing.Point(350, 154);
            this.rtbEventDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbEventDescription.Name = "rtbEventDescription";
            this.rtbEventDescription.ReadOnly = true;
            this.rtbEventDescription.Size = new System.Drawing.Size(325, 118);
            this.rtbEventDescription.TabIndex = 4;
            this.rtbEventDescription.Text = "";
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Location = new System.Drawing.Point(371, 286);
            this.btnXemChiTiet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(113, 26);
            this.btnXemChiTiet.TabIndex = 5;
            this.btnXemChiTiet.Text = "Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = true;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // frmEventCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.btnXemChiTiet);
            this.Controls.Add(this.rtbEventDescription);
            this.Controls.Add(this.lblEventLocation);
            this.Controls.Add(this.lblEventTime);
            this.Controls.Add(this.lblEventTitle);
            this.Controls.Add(this.monthCalendarEvents);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmEventCalendar";
            this.Text = "frmEventCalendar";
            this.Load += new System.EventHandler(this.frmEventCalendar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendarEvents;
        private System.Windows.Forms.Label lblEventTitle;
        private System.Windows.Forms.Label lblEventTime;
        private System.Windows.Forms.Label lblEventLocation;
        private System.Windows.Forms.RichTextBox rtbEventDescription;
        private System.Windows.Forms.Button btnXemChiTiet;
    }
}

