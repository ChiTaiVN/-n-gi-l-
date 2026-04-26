namespace Project_Angile
{
    partial class frmSelfCheckIn
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
            this.components = new System.ComponentModel.Container();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvLiveCheckIn = new System.Windows.Forms.DataGridView();
            this.timerSync = new System.Windows.Forms.Timer(this.components);
            this.clbEvents = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiveCheckIn)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventName.Location = new System.Drawing.Point(81, 21);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(124, 20);
            this.lblEventName.TabIndex = 0;
            this.lblEventName.Text = "lblEventName";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(82, 62);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(58, 16);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "lblStatus";
            // 
            // dgvLiveCheckIn
            // 
            this.dgvLiveCheckIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLiveCheckIn.Location = new System.Drawing.Point(85, 236);
            this.dgvLiveCheckIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLiveCheckIn.Name = "dgvLiveCheckIn";
            this.dgvLiveCheckIn.RowHeadersWidth = 62;
            this.dgvLiveCheckIn.RowTemplate.Height = 28;
            this.dgvLiveCheckIn.Size = new System.Drawing.Size(879, 184);
            this.dgvLiveCheckIn.TabIndex = 4;
            // 
            // timerSync
            // 
            this.timerSync.Enabled = true;
            this.timerSync.Interval = 5000;
            this.timerSync.Tick += new System.EventHandler(this.timerSync_Tick);
            // 
            // clbEvents
            // 
            this.clbEvents.FormattingEnabled = true;
            this.clbEvents.Location = new System.Drawing.Point(85, 95);
            this.clbEvents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbEvents.Name = "clbEvents";
            this.clbEvents.Size = new System.Drawing.Size(153, 106);
            this.clbEvents.TabIndex = 5;
            // 
            // frmSelfCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 431);
            this.Controls.Add(this.clbEvents);
            this.Controls.Add(this.dgvLiveCheckIn);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblEventName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmSelfCheckIn";
            this.Text = "frmSelfCheckIn";
            this.Load += new System.EventHandler(this.frmSelfCheckIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiveCheckIn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvLiveCheckIn;
        private System.Windows.Forms.Timer timerSync;
        private System.Windows.Forms.CheckedListBox clbEvents;
    }
}