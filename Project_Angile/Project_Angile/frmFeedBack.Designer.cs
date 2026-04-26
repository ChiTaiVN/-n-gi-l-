namespace Project_Angile
{
    partial class frmFeedBack
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtmasukiencheckin = new System.Windows.Forms.TextBox();
            this.lbmaskcheckin = new System.Windows.Forms.Label();
            this.btncheckin = new System.Windows.Forms.Button();
            this.txtmave = new System.Windows.Forms.TextBox();
            this.txtmssv = new System.Windows.Forms.TextBox();
            this.lbmave = new System.Windows.Forms.Label();
            this.lbmssv = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lbgopy = new System.Windows.Forms.Label();
            this.btndanhgia = new System.Windows.Forms.Button();
            this.txtdanhgia = new System.Windows.Forms.TextBox();
            this.lbdanhgia = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtmasukiencheckin);
            this.panel1.Controls.Add(this.lbmaskcheckin);
            this.panel1.Controls.Add(this.btncheckin);
            this.panel1.Controls.Add(this.txtmave);
            this.panel1.Controls.Add(this.txtmssv);
            this.panel1.Controls.Add(this.lbmave);
            this.panel1.Controls.Add(this.lbmssv);
            this.panel1.Location = new System.Drawing.Point(13, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 476);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtmasukiencheckin
            // 
            this.txtmasukiencheckin.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmasukiencheckin.Location = new System.Drawing.Point(141, 136);
            this.txtmasukiencheckin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtmasukiencheckin.Name = "txtmasukiencheckin";
            this.txtmasukiencheckin.Size = new System.Drawing.Size(276, 34);
            this.txtmasukiencheckin.TabIndex = 8;
            this.txtmasukiencheckin.TextChanged += new System.EventHandler(this.txtmasukiencheckin_TextChanged_1);
            // 
            // lbmaskcheckin
            // 
            this.lbmaskcheckin.AutoSize = true;
            this.lbmaskcheckin.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmaskcheckin.Location = new System.Drawing.Point(14, 136);
            this.lbmaskcheckin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbmaskcheckin.Name = "lbmaskcheckin";
            this.lbmaskcheckin.Size = new System.Drawing.Size(125, 27);
            this.lbmaskcheckin.TabIndex = 5;
            this.lbmaskcheckin.Text = "Mã sự kiện:";
            this.lbmaskcheckin.Click += new System.EventHandler(this.lbmask_Click);
            // 
            // btncheckin
            // 
            this.btncheckin.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncheckin.Location = new System.Drawing.Point(104, 260);
            this.btncheckin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btncheckin.Name = "btncheckin";
            this.btncheckin.Size = new System.Drawing.Size(203, 47);
            this.btncheckin.TabIndex = 4;
            this.btncheckin.Text = "Check-in";
            this.btncheckin.UseVisualStyleBackColor = true;
            this.btncheckin.Click += new System.EventHandler(this.btncheckin_Click);
            // 
            // txtmave
            // 
            this.txtmave.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmave.Location = new System.Drawing.Point(141, 73);
            this.txtmave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtmave.Name = "txtmave";
            this.txtmave.Size = new System.Drawing.Size(276, 34);
            this.txtmave.TabIndex = 3;
            this.txtmave.TextChanged += new System.EventHandler(this.txtmave_TextChanged);
            // 
            // txtmssv
            // 
            this.txtmssv.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmssv.Location = new System.Drawing.Point(141, 13);
            this.txtmssv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtmssv.Name = "txtmssv";
            this.txtmssv.Size = new System.Drawing.Size(276, 34);
            this.txtmssv.TabIndex = 2;
            this.txtmssv.TextChanged += new System.EventHandler(this.txtmssv_TextChanged);
            // 
            // lbmave
            // 
            this.lbmave.AutoSize = true;
            this.lbmave.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmave.Location = new System.Drawing.Point(14, 75);
            this.lbmave.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbmave.Name = "lbmave";
            this.lbmave.Size = new System.Drawing.Size(79, 27);
            this.lbmave.TabIndex = 1;
            this.lbmave.Text = "Mã vé:";
            // 
            // lbmssv
            // 
            this.lbmssv.AutoSize = true;
            this.lbmssv.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmssv.Location = new System.Drawing.Point(11, 15);
            this.lbmssv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbmssv.Name = "lbmssv";
            this.lbmssv.Size = new System.Drawing.Size(77, 27);
            this.lbmssv.TabIndex = 0;
            this.lbmssv.Text = "MSSV:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtComment);
            this.panel2.Controls.Add(this.lbgopy);
            this.panel2.Controls.Add(this.btndanhgia);
            this.panel2.Controls.Add(this.txtdanhgia);
            this.panel2.Controls.Add(this.lbdanhgia);
            this.panel2.Location = new System.Drawing.Point(455, 9);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 476);
            this.panel2.TabIndex = 1;
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(164, 82);
            this.txtComment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(276, 34);
            this.txtComment.TabIndex = 9;
            this.txtComment.TextChanged += new System.EventHandler(this.txtComment_TextChanged);
            // 
            // lbgopy
            // 
            this.lbgopy.AutoSize = true;
            this.lbgopy.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbgopy.Location = new System.Drawing.Point(16, 75);
            this.lbgopy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbgopy.Name = "lbgopy";
            this.lbgopy.Size = new System.Drawing.Size(77, 27);
            this.lbgopy.TabIndex = 8;
            this.lbgopy.Text = "Góp ý:";
            this.lbgopy.Click += new System.EventHandler(this.lbgopy_Click);
            // 
            // btndanhgia
            // 
            this.btndanhgia.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndanhgia.Location = new System.Drawing.Point(131, 260);
            this.btndanhgia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btndanhgia.Name = "btndanhgia";
            this.btndanhgia.Size = new System.Drawing.Size(275, 47);
            this.btndanhgia.TabIndex = 5;
            this.btndanhgia.Text = "Đánh giá và nhận xét";
            this.btndanhgia.UseVisualStyleBackColor = true;
            this.btndanhgia.Click += new System.EventHandler(this.btndanhgia_Click);
            // 
            // txtdanhgia
            // 
            this.txtdanhgia.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdanhgia.Location = new System.Drawing.Point(164, 13);
            this.txtdanhgia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtdanhgia.Name = "txtdanhgia";
            this.txtdanhgia.Size = new System.Drawing.Size(276, 34);
            this.txtdanhgia.TabIndex = 3;
            this.txtdanhgia.TextChanged += new System.EventHandler(this.txtdanhgia_TextChanged);
            // 
            // lbdanhgia
            // 
            this.lbdanhgia.AutoSize = true;
            this.lbdanhgia.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdanhgia.Location = new System.Drawing.Point(16, 15);
            this.lbdanhgia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbdanhgia.Name = "lbdanhgia";
            this.lbdanhgia.Size = new System.Drawing.Size(104, 27);
            this.lbdanhgia.TabIndex = 1;
            this.lbdanhgia.Text = "Đánh giá:";
            // 
            // frmFeedBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 508);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmFeedBack";
            this.Text = "Checkin, feedback";
            this.Load += new System.EventHandler(this.frmFeedBack_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbmssv;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btncheckin;
        private System.Windows.Forms.TextBox txtmave;
        private System.Windows.Forms.TextBox txtmssv;
        private System.Windows.Forms.Label lbmave;
        private System.Windows.Forms.Label lbdanhgia;
        private System.Windows.Forms.Button btndanhgia;
        private System.Windows.Forms.TextBox txtdanhgia;
        private System.Windows.Forms.Label lbmaskcheckin;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lbgopy;
        private System.Windows.Forms.TextBox txtmasukiencheckin;
    }
}

