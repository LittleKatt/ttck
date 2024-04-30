namespace GUI.CHAMCONG
{
    partial class frmCapNhatNgayCong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapNhatNgayCong));
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.cldNgayCong = new System.Windows.Forms.MonthCalendar();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.rdgChamCong = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.rdgTGNghi = new DevExpress.XtraEditors.RadioGroup();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIDNV = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgChamCong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdgTGNghi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCapNhat.ImageOptions.SvgImage")));
            this.btnCapNhat.Location = new System.Drawing.Point(232, 227);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(106, 34);
            this.btnCapNhat.TabIndex = 0;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // cldNgayCong
            // 
            this.cldNgayCong.Location = new System.Drawing.Point(3, 18);
            this.cldNgayCong.Name = "cldNgayCong";
            this.cldNgayCong.TabIndex = 1;
            this.cldNgayCong.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.cldNgayCong_DateSelected);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Red;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.rdgChamCong);
            this.groupControl1.Location = new System.Drawing.Point(221, 18);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(233, 90);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Chấm công";
            // 
            // rdgChamCong
            // 
            this.rdgChamCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdgChamCong.EditValue = "P";
            this.rdgChamCong.Location = new System.Drawing.Point(2, 23);
            this.rdgChamCong.Name = "rdgChamCong";
            this.rdgChamCong.Properties.Columns = 2;
            this.rdgChamCong.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("P", "Nghỉ phép"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("V", "Vắng"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("VR", "Việc riêng"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("CT", "Công tác"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("CCN", "Công chủ nhật")});
            this.rdgChamCong.Size = new System.Drawing.Size(229, 65);
            this.rdgChamCong.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.Red;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.rdgTGNghi);
            this.groupControl2.Location = new System.Drawing.Point(223, 114);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(229, 100);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Thời gian nghỉ";
            // 
            // rdgTGNghi
            // 
            this.rdgTGNghi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdgTGNghi.EditValue = "SA";
            this.rdgTGNghi.Location = new System.Drawing.Point(2, 23);
            this.rdgTGNghi.Name = "rdgTGNghi";
            this.rdgTGNghi.Properties.Columns = 2;
            this.rdgTGNghi.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("SA", "Sáng"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("CH", "Chiều"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("NN", "Nguyên ngày")});
            this.rdgTGNghi.Size = new System.Drawing.Size(225, 75);
            this.rdgTGNghi.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Location = new System.Drawing.Point(344, 227);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(106, 34);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.lblHoTen);
            this.groupControl3.Controls.Add(this.label2);
            this.groupControl3.Controls.Add(this.lblIDNV);
            this.groupControl3.Controls.Add(this.label1);
            this.groupControl3.Location = new System.Drawing.Point(3, 192);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(205, 102);
            this.groupControl3.TabIndex = 4;
            this.groupControl3.Text = "Thông Tin";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblHoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblHoTen.Location = new System.Drawing.Point(60, 71);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(65, 14);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ tên NV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(5, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ tên:";
            // 
            // lblIDNV
            // 
            this.lblIDNV.AutoSize = true;
            this.lblIDNV.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblIDNV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblIDNV.Location = new System.Drawing.Point(60, 35);
            this.lblIDNV.Name = "lblIDNV";
            this.lblIDNV.Size = new System.Drawing.Size(35, 14);
            this.lblIDNV.TabIndex = 0;
            this.lblIDNV.Text = "IDNV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(5, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // frmCapNhatNgayCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 307);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.cldNgayCong);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnCapNhat);
            this.MinimizeBox = false;
            this.Name = "frmCapNhatNgayCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật ngày công";
            this.Load += new System.EventHandler(this.frmCapNhatNgayCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdgChamCong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdgTGNghi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private System.Windows.Forms.MonthCalendar cldNgayCong;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.RadioGroup rdgChamCong;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.RadioGroup rdgTGNghi;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIDNV;
        private System.Windows.Forms.Label label1;
    }
}