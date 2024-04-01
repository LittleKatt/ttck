using BUS;
using DAO;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace GUI
{
    public partial class frmThoiViec : DevExpress.XtraEditors.XtraForm
    {
        public frmThoiViec()
        {
            InitializeComponent();
        }
        bool _them;
        string _soqd;
        ThoiViec _nvtv;
        NhanVien _nhanvien;


        private void frmThoiViec_Load(object sender, EventArgs e)
        {
            _nvtv = new ThoiViec();
            _nhanvien = new NhanVien();
            _them = false;
            LoadNhanVien();
            LoadData();

            ShowHide(true);
            splitContainer1.Panel1Collapsed = true;

        }
      
        private void ShowHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
            txtSoQD.Enabled = !kt;
            txtLyDo.Enabled = !kt;
            txtGhiChu.Enabled = !kt;
            dtNgayNopDon.Enabled = !kt;
            dtNgayNghi.Enabled = !kt;
            slkNhanVien.Enabled = !kt;
            gcDanhSach.Enabled = kt;
        }

        private void _reset()
        {
            txtSoQD.Text = string.Empty;
            txtLyDo.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            dtNgayNopDon.Value = DateTime.Now;
            dtNgayNghi.Value = dtNgayNopDon.Value.AddDays(30);
            slkNhanVien.Text = string.Empty;
          
        }

        void LoadNhanVien()
        {
            slkNhanVien.Properties.DataSource = _nhanvien.getListFull();
            slkNhanVien.Properties.ValueMember = "IDNV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
        }
        private void LoadData()
        {
            gcDanhSach.DataSource = _nvtv.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            _them = true;
            _reset();
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            ShowHide(false);
            splitContainer1.Panel1Collapsed = false;
            gcDanhSach.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nvtv.Delete(_soqd, 1);
                LoadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            LoadData();
            _them = false;
            ShowHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            ShowHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void SaveData()
        {
            THOIVIEC tv;
            if (_them)
            {

                var maxsoqd = _nvtv.MaxSoQuyetDinh();
                int so = int.Parse(maxsoqd.Substring(0, 4)) + 1;
                tv = new THOIVIEC(); 
                tv.SOQD = so.ToString("0000") + @"/" + DateTime.Now.Year.ToString() + "/QĐTV";
                tv.LYDO = txtLyDo.Text;
                tv.GHICHU = txtGhiChu.Text;
                tv.NGAYNOPDON = dtNgayNopDon.Value;
                tv.NGAYNGHI = dtNgayNghi.Value;
                tv.IDNV = int.Parse(slkNhanVien.EditValue.ToString()); 
                tv.CREATED_BY = 1;
                tv.CREATED_DATE = DateTime.Now;
                _nvtv.Add(tv);
            }
            else
            {
                tv = _nvtv.getItem(_soqd);
                tv.LYDO = txtLyDo.Text;
                tv.GHICHU = txtGhiChu.Text;
                tv.NGAYNOPDON = dtNgayNopDon.Value;
                tv.NGAYNGHI = dtNgayNghi.Value;
                tv.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                tv.UPDATED_BY = 1;
                tv.UPDATED_DATE = DateTime.Now;
                _nvtv.Update(tv);
            }
            var nv = _nhanvien.getItem(tv.IDNV.Value);
            nv.DATHOIVIEC = true; 
            _nhanvien.Update(nv);
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soqd = gvDanhSach.GetFocusedRowCellValue("SOQD").ToString();
                var tv = _nvtv.getItem(_soqd);
                txtSoQD.Text = _soqd;
                txtLyDo.Text = tv.LYDO;
                txtGhiChu.Text = tv.GHICHU;
                dtNgayNopDon.Value = tv.NGAYNOPDON.Value;
                dtNgayNghi.Value = tv.NGAYNGHI.Value;
                slkNhanVien.EditValue = tv.IDNV;
              
            }
        }

        private void dtNgayNopDon_ValueChanged(object sender, EventArgs e)
        {
            dtNgayNghi.Value = dtNgayNopDon.Value.AddDays(30);
        }

        

        //private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        //{
        //    if (e.Column.Name == "DELETED_BY" && e.CellValue != null)
        //    {
        //        Image img = Properties.Resources.del_Icon_x16; 
        //        e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
        //        e.Handled = true;   
        //    }
        //}
    }
}