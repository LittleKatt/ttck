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

namespace GUI.TINHLUONG
{
    public partial class frmUngLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmUngLuong()
        {
            InitializeComponent();
        }
        bool _them;
        int _id;
        NhanVien _nhanvien;
        UngLuong _ungluong; 
        private void frmUngLuong_Load(object sender, EventArgs e)
        {
            _them = false;
            _nhanvien = new NhanVien();
            _ungluong = new UngLuong();
            ShowHide(true);
            LoadData();
            LoadNhanVien();
           
        }
        void ShowHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
            txtNoiDung.Enabled = !kt;
            spSoTien.Enabled = !kt;
          
            slkNhanVien.Enabled = !kt;

        }
        void LoadNhanVien()
        {
            slkNhanVien.Properties.DataSource = _nhanvien.getListFull();
            slkNhanVien.Properties.ValueMember = "IDNV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
        }
       
        void LoadData()
        {
            gcDanhSach.DataSource = _ungluong.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            _them = true;
            txtNoiDung.Text = string.Empty;
            spSoTien.EditValue = 0;
            slkNhanVien.EditValue = 0;
           
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            ShowHide(false);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _ungluong.Delete(_id, 1);
                LoadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            LoadData();
            _them = false;
            ShowHide(true);
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            ShowHide(true);
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void SaveData()
        {
            if (_them)
            {
                UNGLUONG ul = new UNGLUONG();
                ul.SOTIEN = double.Parse(spSoTien.EditValue.ToString());
                ul.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                ul.GHICHU = txtNoiDung.Text;
                ul.NAM = DateTime.Now.Year;
                ul.THANG = DateTime.Now.Month;
                ul.NGAY = DateTime.Now.Day;            
                ul.CREATED_BY = 1;
                ul.CREATED_DATE = DateTime.Now;
                _ungluong.Add(ul);
            }
            else
            {
                var ul = _ungluong.getItem(_id);
                ul.SOTIEN = double.Parse(spSoTien.EditValue.ToString());
                ul.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                ul.GHICHU = txtNoiDung.Text;
                ul.NAM = DateTime.Now.Year;
                ul.THANG = DateTime.Now.Month;
                ul.NGAY = DateTime.Now.Day;

                ul.UPDATED_BY = 1;
                ul.UPDATED_DATE = DateTime.Now;
                _ungluong.Update(ul);
            }
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDUL").ToString());
                txtNoiDung.Text = gvDanhSach.GetFocusedRowCellValue("GHICHU").ToString();
                spSoTien.EditValue = gvDanhSach.GetFocusedRowCellValue("SOTIEN");
                slkNhanVien.EditValue = gvDanhSach.GetFocusedRowCellValue("IDNV");
           

            }
        }
    }
}