namespace Project_Angile
{
    partial class frmEventDetail
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
            this.lblEventTitle = new System.Windows.Forms.Label();
            this.lblEventTime = new System.Windows.Forms.Label();
            this.lblEventLocation = new System.Windows.Forms.Label();
            this.lblSeats = new System.Windows.Forms.Label();
            this.rtbEventDescription = new System.Windows.Forms.RichTextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.picCover = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEventTitle
            // 
            this.lblEventTitle.AutoSize = true;
            this.lblEventTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventTitle.Location = new System.Drawing.Point(435, 60);
            this.lblEventTitle.Name = "lblEventTitle";
            this.lblEventTitle.Size = new System.Drawing.Size(131, 25);
            this.lblEventTitle.TabIndex = 1;
            this.lblEventTitle.Text = "lblEventTitle";
            // 
            // lblEventTime
            // 
            this.lblEventTime.AutoSize = true;
            this.lblEventTime.Location = new System.Drawing.Point(436, 110);
            this.lblEventTime.Name = "lblEventTime";
            this.lblEventTime.Size = new System.Drawing.Size(86, 16);
            this.lblEventTime.TabIndex = 2;
            this.lblEventTime.Text = "lblEventTime";
            // 
            // lblEventLocation
            // 
            this.lblEventLocation.AutoSize = true;
            this.lblEventLocation.Location = new System.Drawing.Point(436, 153);
            this.lblEventLocation.Name = "lblEventLocation";
            this.lblEventLocation.Size = new System.Drawing.Size(106, 16);
            this.lblEventLocation.TabIndex = 3;
            this.lblEventLocation.Text = "lblEventLocation";
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.Location = new System.Drawing.Point(436, 202);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(56, 16);
            this.lblSeats.TabIndex = 4;
            this.lblSeats.Text = "lblSeats";
            // 
            // rtbEventDescription
            // 
            this.rtbEventDescription.Location = new System.Drawing.Point(168, 138);
            this.rtbEventDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbEventDescription.Name = "rtbEventDescription";
            this.rtbEventDescription.ReadOnly = true;
            this.rtbEventDescription.Size = new System.Drawing.Size(230, 139);
            this.rtbEventDescription.TabIndex = 5;
            this.rtbEventDescription.Text = "";
            this.rtbEventDescription.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbEventDescription_LinkClicked);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(439, 246);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(138, 31);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Đăng ký tham gia";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click_1);
            // 
            // picCover
            // 
            this.picCover.Location = new System.Drawing.Point(168, 44);
            this.picCover.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(229, 95);
            this.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCover.TabIndex = 7;
            this.picCover.TabStop = false;
            // 
            // frmEventDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 408);
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.rtbEventDescription);
            this.Controls.Add(this.lblSeats);
            this.Controls.Add(this.lblEventLocation);
            this.Controls.Add(this.lblEventTime);
            this.Controls.Add(this.lblEventTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmEventDetail";
            this.Text = "frmEventDetail";
            this.Load += new System.EventHandler(this.frmEventDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEventTitle;
        private System.Windows.Forms.Label lblEventTime;
        private System.Windows.Forms.Label lblEventLocation;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.RichTextBox rtbEventDescription;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.PictureBox picCover;
    }
}