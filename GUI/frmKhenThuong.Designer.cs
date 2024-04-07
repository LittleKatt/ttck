namespace GUI
{
    partial class frmKhenThuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhenThuong));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.btnIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnDong = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtNoiDung = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtLyDo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.slkNhanVien = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.COLIDNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.COLHOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.dtNgayKy = new System.Windows.Forms.DateTimePicker();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtSoQD = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SOQD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAYKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LYDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOIDUNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl5 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl6 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl7 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl8 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl9 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl10 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl11 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl12 = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLyDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoQD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnSua,
            this.btnXoa,
            this.btnLuu,
            this.btnHuy,
            this.btnDong,
            this.btnIn});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.bar2.BarAppearance.Normal.Options.UseFont = true;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(500, 193);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHuy, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnIn, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDong, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 1;
            this.btnSua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSua.ImageOptions.SvgImage")));
            this.btnSua.Name = "btnSua";
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLuu.ImageOptions.SvgImage")));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Hủy";
            this.btnHuy.Id = 4;
            this.btnHuy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHuy.ImageOptions.SvgImage")));
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHuy_ItemClick);
            // 
            // btnIn
            // 
            this.btnIn.Caption = "In";
            this.btnIn.Id = 6;
            this.btnIn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnIn.ImageOptions.SvgImage")));
            this.btnIn.Name = "btnIn";
            this.btnIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnIn_ItemClick);
            // 
            // btnDong
            // 
            this.btnDong.Caption = "Đóng";
            this.btnDong.Id = 5;
            this.btnDong.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDong.ImageOptions.SvgImage")));
            this.btnDong.Name = "btnDong";
            this.btnDong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDong_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(998, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 520);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(998, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 496);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(998, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 496);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtNoiDung);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainer1.Panel1.Controls.Add(this.txtLyDo);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel1.Controls.Add(this.slkNhanVien);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl12);
            this.splitContainer1.Panel1.Controls.Add(this.dtNgayKy);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl8);
            this.splitContainer1.Panel1.Controls.Add(this.txtSoQD);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gcDanhSach);
            this.splitContainer1.Size = new System.Drawing.Size(998, 496);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 31;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(162, 109);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNoiDung.MenuManager = this.barManager1;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNoiDung.Properties.Appearance.Options.UseFont = true;
            this.txtNoiDung.Size = new System.Drawing.Size(753, 22);
            this.txtNoiDung.TabIndex = 38;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(82, 111);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 17);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "Nội dung";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(162, 67);
            this.txtLyDo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLyDo.MenuManager = this.barManager1;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtLyDo.Properties.Appearance.Options.UseFont = true;
            this.txtLyDo.Size = new System.Drawing.Size(753, 22);
            this.txtLyDo.TabIndex = 36;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(82, 70);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 16);
            this.labelControl2.TabIndex = 35;
            this.labelControl2.Text = "Lý Do:";
            // 
            // slkNhanVien
            // 
            this.slkNhanVien.Location = new System.Drawing.Point(459, 27);
            this.slkNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.slkNhanVien.MenuManager = this.barManager1;
            this.slkNhanVien.Name = "slkNhanVien";
            this.slkNhanVien.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.slkNhanVien.Properties.Appearance.Options.UseFont = true;
            this.slkNhanVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkNhanVien.Properties.PopupView = this.searchLookUpEdit1View;
            this.slkNhanVien.Size = new System.Drawing.Size(167, 22);
            this.slkNhanVien.TabIndex = 34;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.COLIDNV,
            this.COLHOTEN});
            this.searchLookUpEdit1View.DetailHeight = 284;
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // COLIDNV
            // 
            this.COLIDNV.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.COLIDNV.AppearanceHeader.Options.UseFont = true;
            this.COLIDNV.Caption = "IDNV";
            this.COLIDNV.FieldName = "IDNV";
            this.COLIDNV.MaxWidth = 69;
            this.COLIDNV.MinWidth = 69;
            this.COLIDNV.Name = "COLIDNV";
            this.COLIDNV.Visible = true;
            this.COLIDNV.VisibleIndex = 0;
            this.COLIDNV.Width = 69;
            // 
            // COLHOTEN
            // 
            this.COLHOTEN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.COLHOTEN.AppearanceHeader.Options.UseFont = true;
            this.COLHOTEN.Caption = "HỌ TÊN";
            this.COLHOTEN.FieldName = "HOTEN";
            this.COLHOTEN.MaxWidth = 171;
            this.COLHOTEN.MinWidth = 171;
            this.COLHOTEN.Name = "COLHOTEN";
            this.COLHOTEN.Visible = true;
            this.COLHOTEN.VisibleIndex = 1;
            this.COLHOTEN.Width = 171;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(675, 30);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(45, 16);
            this.labelControl12.TabIndex = 29;
            this.labelControl12.Text = "Ngày Ký";
            // 
            // dtNgayKy
            // 
            this.dtNgayKy.CustomFormat = "dd/MM/yyyy";
            this.dtNgayKy.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtNgayKy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayKy.Location = new System.Drawing.Point(747, 27);
            this.dtNgayKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtNgayKy.Name = "dtNgayKy";
            this.dtNgayKy.Size = new System.Drawing.Size(169, 24);
            this.dtNgayKy.TabIndex = 28;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(369, 30);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(58, 16);
            this.labelControl8.TabIndex = 13;
            this.labelControl8.Text = "Nhân Viên";
            // 
            // txtSoQD
            // 
            this.txtSoQD.Location = new System.Drawing.Point(162, 27);
            this.txtSoQD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoQD.MenuManager = this.barManager1;
            this.txtSoQD.Name = "txtSoQD";
            this.txtSoQD.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSoQD.Properties.Appearance.Options.UseFont = true;
            this.txtSoQD.Properties.ReadOnly = true;
            this.txtSoQD.Size = new System.Drawing.Size(168, 22);
            this.txtSoQD.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(82, 29);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Số QĐ";
            // 
            // gcDanhSach
            // 
            this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSach.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcDanhSach.Location = new System.Drawing.Point(0, 0);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcDanhSach.MenuManager = this.barManager1;
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(998, 334);
            this.gcDanhSach.TabIndex = 0;
            this.gcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SOQD,
            this.NGAYKY,
            this.IDNV,
            this.HOTEN,
            this.LYDO,
            this.NOIDUNG});
            this.gvDanhSach.DetailHeight = 284;
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsView.ShowGroupPanel = false;
            this.gvDanhSach.Click += new System.EventHandler(this.gvDanhSach_Click);
            // 
            // SOQD
            // 
            this.SOQD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.SOQD.AppearanceHeader.Options.UseFont = true;
            this.SOQD.Caption = "SỐ QĐ";
            this.SOQD.FieldName = "SOQD";
            this.SOQD.MaxWidth = 103;
            this.SOQD.MinWidth = 103;
            this.SOQD.Name = "SOQD";
            this.SOQD.Visible = true;
            this.SOQD.VisibleIndex = 0;
            this.SOQD.Width = 103;
            // 
            // NGAYKY
            // 
            this.NGAYKY.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.NGAYKY.AppearanceHeader.Options.UseFont = true;
            this.NGAYKY.Caption = "NGÀY KÝ";
            this.NGAYKY.FieldName = "NGAYKY";
            this.NGAYKY.MaxWidth = 103;
            this.NGAYKY.MinWidth = 103;
            this.NGAYKY.Name = "NGAYKY";
            this.NGAYKY.Visible = true;
            this.NGAYKY.VisibleIndex = 1;
            this.NGAYKY.Width = 103;
            // 
            // IDNV
            // 
            this.IDNV.Caption = "IDNV";
            this.IDNV.FieldName = "IDNV";
            this.IDNV.MinWidth = 21;
            this.IDNV.Name = "IDNV";
            this.IDNV.Width = 81;
            // 
            // HOTEN
            // 
            this.HOTEN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.HOTEN.AppearanceHeader.Options.UseFont = true;
            this.HOTEN.Caption = "NHÂN VIÊN";
            this.HOTEN.FieldName = "HOTEN";
            this.HOTEN.MaxWidth = 171;
            this.HOTEN.MinWidth = 171;
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Visible = true;
            this.HOTEN.VisibleIndex = 2;
            this.HOTEN.Width = 171;
            // 
            // LYDO
            // 
            this.LYDO.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.LYDO.AppearanceHeader.Options.UseFont = true;
            this.LYDO.Caption = "LÝ DO";
            this.LYDO.FieldName = "LYDO";
            this.LYDO.MaxWidth = 214;
            this.LYDO.MinWidth = 214;
            this.LYDO.Name = "LYDO";
            this.LYDO.Visible = true;
            this.LYDO.VisibleIndex = 3;
            this.LYDO.Width = 214;
            // 
            // NOIDUNG
            // 
            this.NOIDUNG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.NOIDUNG.AppearanceHeader.Options.UseFont = true;
            this.NOIDUNG.Caption = "NỘI DUNG";
            this.NOIDUNG.FieldName = "NOIDUNG";
            this.NOIDUNG.MaxWidth = 214;
            this.NOIDUNG.MinWidth = 214;
            this.NOIDUNG.Name = "NOIDUNG";
            this.NOIDUNG.Visible = true;
            this.NOIDUNG.VisibleIndex = 4;
            this.NOIDUNG.Width = 214;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl1.Location = new System.Drawing.Point(0, 24);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl1.Size = new System.Drawing.Size(0, 496);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl2.Location = new System.Drawing.Point(998, 24);
            this.barDockControl2.Manager = this.barManager1;
            this.barDockControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl2.Size = new System.Drawing.Size(0, 496);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl3.Location = new System.Drawing.Point(0, 520);
            this.barDockControl3.Manager = this.barManager1;
            this.barDockControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl3.Size = new System.Drawing.Size(998, 0);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl4.Location = new System.Drawing.Point(0, 24);
            this.barDockControl4.Manager = this.barManager1;
            this.barDockControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl4.Size = new System.Drawing.Size(998, 0);
            // 
            // barDockControl5
            // 
            this.barDockControl5.CausesValidation = false;
            this.barDockControl5.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl5.Location = new System.Drawing.Point(0, 24);
            this.barDockControl5.Manager = this.barManager1;
            this.barDockControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl5.Size = new System.Drawing.Size(0, 496);
            // 
            // barDockControl6
            // 
            this.barDockControl6.CausesValidation = false;
            this.barDockControl6.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl6.Location = new System.Drawing.Point(998, 24);
            this.barDockControl6.Manager = this.barManager1;
            this.barDockControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl6.Size = new System.Drawing.Size(0, 496);
            // 
            // barDockControl7
            // 
            this.barDockControl7.CausesValidation = false;
            this.barDockControl7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl7.Location = new System.Drawing.Point(0, 520);
            this.barDockControl7.Manager = this.barManager1;
            this.barDockControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl7.Size = new System.Drawing.Size(998, 0);
            // 
            // barDockControl8
            // 
            this.barDockControl8.CausesValidation = false;
            this.barDockControl8.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl8.Location = new System.Drawing.Point(0, 24);
            this.barDockControl8.Manager = this.barManager1;
            this.barDockControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl8.Size = new System.Drawing.Size(998, 0);
            // 
            // barDockControl9
            // 
            this.barDockControl9.CausesValidation = false;
            this.barDockControl9.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl9.Location = new System.Drawing.Point(0, 24);
            this.barDockControl9.Manager = this.barManager1;
            this.barDockControl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl9.Size = new System.Drawing.Size(0, 496);
            // 
            // barDockControl10
            // 
            this.barDockControl10.CausesValidation = false;
            this.barDockControl10.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl10.Location = new System.Drawing.Point(998, 24);
            this.barDockControl10.Manager = this.barManager1;
            this.barDockControl10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl10.Size = new System.Drawing.Size(0, 496);
            // 
            // barDockControl11
            // 
            this.barDockControl11.CausesValidation = false;
            this.barDockControl11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl11.Location = new System.Drawing.Point(0, 520);
            this.barDockControl11.Manager = this.barManager1;
            this.barDockControl11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl11.Size = new System.Drawing.Size(998, 0);
            // 
            // barDockControl12
            // 
            this.barDockControl12.CausesValidation = false;
            this.barDockControl12.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl12.Location = new System.Drawing.Point(0, 24);
            this.barDockControl12.Manager = this.barManager1;
            this.barDockControl12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControl12.Size = new System.Drawing.Size(998, 0);
            // 
            // frmKhenThuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 540);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl5);
            this.Controls.Add(this.barDockControl6);
            this.Controls.Add(this.barDockControl7);
            this.Controls.Add(this.barDockControl8);
            this.Controls.Add(this.barDockControl9);
            this.Controls.Add(this.barDockControl10);
            this.Controls.Add(this.barDockControl11);
            this.Controls.Add(this.barDockControl12);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmKhenThuong";
            this.Text = "Khen Thưởng";
            this.Load += new System.EventHandler(this.frmKhenThuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLyDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoQD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnHuy;
        private DevExpress.XtraBars.BarButtonItem btnIn;
        private DevExpress.XtraBars.BarButtonItem btnDong;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.SearchLookUpEdit slkNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn COLIDNV;
        private DevExpress.XtraGrid.Columns.GridColumn COLHOTEN;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private System.Windows.Forms.DateTimePicker dtNgayKy;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtSoQD;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn SOQD;
        private DevExpress.XtraGrid.Columns.GridColumn NGAYKY;
        private DevExpress.XtraGrid.Columns.GridColumn IDNV;
        private DevExpress.XtraGrid.Columns.GridColumn HOTEN;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl5;
        private DevExpress.XtraBars.BarDockControl barDockControl6;
        private DevExpress.XtraBars.BarDockControl barDockControl7;
        private DevExpress.XtraBars.BarDockControl barDockControl8;
        private DevExpress.XtraBars.BarDockControl barDockControl9;
        private DevExpress.XtraBars.BarDockControl barDockControl10;
        private DevExpress.XtraBars.BarDockControl barDockControl11;
        private DevExpress.XtraBars.BarDockControl barDockControl12;
        private DevExpress.XtraEditors.TextEdit txtLyDo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtNoiDung;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn LYDO;
        private DevExpress.XtraGrid.Columns.GridColumn NOIDUNG;
    }
}