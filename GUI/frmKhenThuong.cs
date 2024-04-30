using BUS;
using BUS.DTO;
using DAO;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using GUI.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmKhenThuong : DevExpress.XtraEditors.XtraForm
    {
        public frmKhenThuong()
        {
            InitializeComponent();
        }
        bool _them;
        string _soqd;
        KhenThuong_KyLuat _ktkl;
        NhanVien _nhanvien;
        List<KTKL_DTO> _lstKTKL;
        private void frmKhenThuong_Load(object sender, EventArgs e)
        {
            _ktkl = new KhenThuong_KyLuat();
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
            txtNoiDung.Enabled = !kt;
            //dtNgayBD.Enabled = !kt;
            //dtNgayKT.Enabled = !kt;
            dtNgayKy.Enabled = !kt;
            slkNhanVien.Enabled = !kt;
            gcDanhSach.Enabled = kt;
        }

        private void _reset()
        {
            txtSoQD.Text = string.Empty;
            txtLyDo.Text = string.Empty;
            txtNoiDung.Text = string.Empty;
            //dtNgayBD.Value = DateTime.Now;
            //dtNgayKT.Value = DateTime.Now;
            dtNgayKy.Value = DateTime.Now;
            slkNhanVien.Text = string.Empty;

        }

        void LoadNhanVien()
        {
            slkNhanVien.Properties.DataSource = _nhanvien.getList();
            slkNhanVien.Properties.ValueMember = "IDNV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
        }
        private void LoadData()
        {
            gcDanhSach.DataSource = _ktkl.getListFull(1);
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
                _ktkl.Delete(_soqd, 1);
                LoadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLyDo.Text) ||
                string.IsNullOrEmpty(txtNoiDung.Text) ||
                dtNgayKy.Value == null ||
                string.IsNullOrEmpty(slkNhanVien.Text))
            {
                // Hiển thị thông báo lỗi yêu cầu nhập đầy đủ thông tin
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo");
            }
            else
            {
                SaveData();
                LoadData();
                _them = false;
                ShowHide(true);
                splitContainer1.Panel1Collapsed = true;
            } 
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            ShowHide(true);
            splitContainer1.Panel1Collapsed = true;

        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _lstKTKL = _ktkl.getListFull(1);
            rptKhenThuong rpt = new rptKhenThuong(_lstKTKL);
            rpt.ShowPreviewDialog();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void SaveData()
        {
            if (_them)
            {
             
                var maxsoqd = _ktkl.MaxSoQuyetDinh(1);
                int so = int.Parse(maxsoqd.Substring(0, 4)) + 1;

                KHENTHUONG_KYLUAT kt = new KHENTHUONG_KYLUAT();
                kt.SOQD = so.ToString("0000") + @"/" + DateTime.Now.Year.ToString() + "/QĐKT";
                //kt.TUNGAY = dtNgayBD.Value;
                //kt.DENNGAY = dtNgayKT.Value;
                kt.LYDO = txtLyDo.Text;
                kt.NOIDUNG = txtNoiDung.Text;
                kt.NGAYKY = dtNgayKy.Value;
                kt.LOAI = 1;
                kt.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                kt.CREATED_BY = 1;
                kt.CREATED_DATE = DateTime.Now;
                _ktkl.Add(kt);
            }
            else
            {
                var kt = _ktkl.getItem(_soqd);
                //kt.TUNGAY = dtNgayBD.Value;
                //kt.DENNGAY = dtNgayKT.Value;
                kt.NGAYKY = dtNgayKy.Value;
                kt.LYDO = txtLyDo.Text;
                kt.NOIDUNG = txtNoiDung.Text;
                kt.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                kt.UPDATED_BY = 1;
                kt.UPDATED_DATE = DateTime.Now;
                _ktkl.Update(kt);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soqd = gvDanhSach.GetFocusedRowCellValue("SOQD").ToString();
                var kt = _ktkl.getItem(_soqd);
                txtSoQD.Text = _soqd;
                txtLyDo.Text = kt.LYDO;
                txtNoiDung.Text = kt.NOIDUNG;
                //dtNgayBD.Value = kt.TUNGAY.Value;
                //dtNgayKT.Value = kt.DENNGAY.Value;
                dtNgayKy.Value = kt.NGAYKY.Value;
                slkNhanVien.EditValue = kt.IDNV;
            }
        }
    }
}