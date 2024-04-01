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

namespace GUI.CHAMCONG
{
    public partial class frmBangCong : DevExpress.XtraEditors.XtraForm
    {
        public frmBangCong()
        {
            InitializeComponent();
        }
        KyCong _kycong;
        bool _them;
        int _idkc;
        private void frmBangCong_Load(object sender, EventArgs e)
        {
            _them = false;
            _kycong = new KyCong();
            ShowHide(true);
            LoadData();
            cbbNam.Text = DateTime.Now.Year.ToString();
            cbbThang.Text = DateTime.Now.Month.ToString();
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
            
           
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _kycong.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            _them = true;
            cbbNam.Text = DateTime.Now.Year.ToString();
            cbbThang.Text = DateTime.Now.Month.ToString();
            chkKhoa.Checked = false;
            chkTrangThai.Checked = false;
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
                _kycong.Delete(_idkc, 1);
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
                KYCONG kc = new KYCONG();
                kc.IDKCCT = int.Parse(cbbNam.Text) * 100 + int.Parse(cbbThang.Text); //Mã kỳ công =202404
                kc.NAM   = int.Parse(cbbNam.Text);
                kc.THANG = int.Parse(cbbThang.Text);
                kc.KHOA = chkKhoa.Checked;
                kc.TRANGTHAI = chkTrangThai.Checked;
                kc.NGAYCONGTRONGTHANG = HamXuLy.demSoNgayLamViecTrongThang(int.Parse(cbbThang.Text), int.Parse(cbbNam.Text));
                kc.NGAYTINHCONG = DateTime.Now;
                kc.CREATED_BY = 1;
                kc.CREATED_DATE = DateTime.Now;
                _kycong.Add(kc);
            }
            else
            {
                var kc = _kycong.getItem(_idkc);
                kc.IDKCCT = int.Parse(cbbNam.Text) * 100 + int.Parse(cbbThang.Text); //Mã kỳ công =202404
                kc.NAM = int.Parse(cbbNam.Text);
                kc.THANG = int.Parse(cbbThang.Text);
                kc.KHOA = chkKhoa.Checked;
                kc.TRANGTHAI = chkTrangThai.Checked;
                kc.NGAYCONGTRONGTHANG = HamXuLy.demSoNgayLamViecTrongThang(int.Parse(cbbThang.Text), int.Parse(cbbNam.Text));
                kc.NGAYTINHCONG = DateTime.Now;
                kc.UPDATED_BY = 1;
                kc.UPDATED_DATE = DateTime.Now;
                _kycong.Update(kc);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _idkc = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDKCCT").ToString());
                cbbNam.Text = gvDanhSach.GetFocusedRowCellValue("NAM").ToString();
                cbbThang.Text = gvDanhSach.GetFocusedRowCellValue("THANG").ToString();
                chkKhoa.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("KHOA").ToString());
                chkTrangThai.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("TRANGTHAI").ToString());


            }
        }

        private void btnXemBangCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangCongChiTiet frm = new frmBangCongChiTiet();
            frm._idkcct = _idkc;
            frm._thang = int.Parse(cbbThang.Text);
            frm._nam = int.Parse(cbbNam.Text);
            frm.ShowDialog();
        }
    }
}