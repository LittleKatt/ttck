using BUS;
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

namespace GUI
{
    public partial class frmDieuChuyen : DevExpress.XtraEditors.XtraForm
    {
        public frmDieuChuyen()
        {
            InitializeComponent();
        }
        bool _them;
        string _soqd;
        DieuChuyen _dc;
        NhanVien _nhanvien;
        PhongBan _phongban;
        BoPhan _bophan;
        ChucVu _chucvu;
        private void frmDieuChuyen_Load(object sender, EventArgs e)
        {
            _dc = new DieuChuyen();
            _nhanvien = new NhanVien();
            _phongban = new PhongBan();
            _bophan = new BoPhan();
            _chucvu = new ChucVu();
            _them = false;
            LoadNhanVien();
            LoadData();
            LoadPB();
            LoadBP();
            LoadCV();
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
            dtNgayKy.Enabled = !kt;
            slkNhanVien.Enabled = !kt;
            cbbNewPB.Enabled = !kt;
            cbbNewBP.Enabled = !kt;
            cbbNewCV.Enabled = !kt;
            gcDanhSach.Enabled = kt;
        }

        private void _reset()
        {
            txtSoQD.Text = string.Empty;
            txtLyDo.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            //dtNgayKy.Value = DateTime.Now;
            //slkNhanVien.Text = string.Empty;

        }

        void LoadNhanVien()
        {
            slkNhanVien.Properties.DataSource = _nhanvien.getList();
            slkNhanVien.Properties.ValueMember = "IDNV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
        }
        private void LoadData()
        {
            gcDanhSach.DataSource = _dc.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void LoadPB()
        {
            cbbNewPB.DataSource = _phongban.getList();
            cbbNewPB.DisplayMember = "TEBPB";
            cbbNewPB.ValueMember = "IDPB";
        }
        void LoadBP()
        {
            cbbNewPB.DataSource = _bophan.getList();
            cbbNewPB.DisplayMember = "TEBBP";
            cbbNewPB.ValueMember = "IDBP";
        }
        void LoadCV()
        {
            cbbNewPB.DataSource = _chucvu.getList();
            cbbNewPB.DisplayMember = "TEBCV";
            cbbNewPB.ValueMember = "IDCV";
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
            if (_them)
            {

                var maxsoqd = _ktkl.MaxSoQuyetDinh(1);
                int so = int.Parse(maxsoqd.Substring(0, 4)) + 1;

                KHENTHUONG_KYLUAT kt = new KHENTHUONG_KYLUAT();
                kt.SOQD = so.ToString("0000") + @"/2024/QĐKT";
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