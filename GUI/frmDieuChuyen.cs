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
            LoadCombobox();
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
            dtNgayKy.Value = DateTime.Now;
            slkNhanVien.Text = string.Empty;
            cbbNewBP.Text = string.Empty;
            cbbNewCV.Text = string.Empty;
            cbbNewPB.Text = string.Empty;
        }

        void LoadNhanVien()
        {
            slkNhanVien.Properties.DataSource = _nhanvien.getList();
            slkNhanVien.Properties.ValueMember = "IDNV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
        }
        private void LoadData()
        {
            gcDanhSach.DataSource = _dc.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void LoadCombobox()
        {
            cbbNewPB.DataSource = _phongban.getList();
            cbbNewPB.DisplayMember = "TENPB";
            cbbNewPB.ValueMember = "IDPB";
            cbbNewBP.DataSource = _bophan.getList();
            cbbNewBP.DisplayMember = "TENBP";
            cbbNewBP.ValueMember = "IDBP";
            cbbNewCV.DataSource = _chucvu.getList();
            cbbNewCV.DisplayMember = "TENCV";
            cbbNewCV.ValueMember = "IDCV";

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
                _dc.Delete(_soqd, 1);
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
            DIEUCHUYEN dc;
            if (_them)
            {

                var maxsoqd = _dc.MaxSoQuyetDinh();
                int so = int.Parse(maxsoqd.Substring(0, 4)) + 1;
                dc = new DIEUCHUYEN();
                dc.SOQD = so.ToString("0000") + @"/"+DateTime.Now.Year.ToString()+"/QĐĐC";
                dc.LYDO = txtLyDo.Text;
                dc.GHICHU = txtGhiChu.Text;
                dc.NGAYKY = dtNgayKy.Value;
                dc.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                dc.IDPB = _nhanvien.getItem(int.Parse(slkNhanVien.EditValue.ToString())).IDPB;
                dc.IDPB2 = int.Parse(cbbNewPB.SelectedValue.ToString());
                dc.IDBP=_nhanvien.getItem(int.Parse(slkNhanVien.EditValue.ToString())).IDBP;
                dc.IDBP2 = int.Parse(cbbNewBP.SelectedValue.ToString());
                dc.IDCV = _nhanvien.getItem(int.Parse(slkNhanVien.EditValue.ToString())).IDCV;
                dc.IDCV2 = int.Parse(cbbNewCV.SelectedValue.ToString());
                dc.CREATED_BY = 1;
                dc.CREATED_DATE = DateTime.Now;
                _dc.Add(dc);
            }
            else
            {
                dc = _dc.getItem(_soqd);
                dc.LYDO = txtLyDo.Text;
                dc.GHICHU = txtGhiChu.Text;
                dc.NGAYKY = dtNgayKy.Value;
                dc.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                dc.IDPB2 = int.Parse(cbbNewPB.SelectedValue.ToString());
                dc.IDBP2 = int.Parse(cbbNewBP.SelectedValue.ToString());
                dc.IDCV2 = int.Parse(cbbNewCV.SelectedValue.ToString());
                dc.UPDATED_BY = 1;
                dc.UPDATED_DATE = DateTime.Now;
                _dc.Update(dc);
            }
            var nv = _nhanvien.getItem(dc.IDNV.Value);
            nv.IDPB = dc.IDPB2;
            nv.IDBP = dc.IDBP2;
            nv.IDCV = dc.IDCV2;
            _nhanvien.Update(nv);
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soqd = gvDanhSach.GetFocusedRowCellValue("SOQD").ToString();
                var dc = _dc.getItem(_soqd);
                txtSoQD.Text = _soqd;
                txtLyDo.Text = dc.LYDO;
                txtGhiChu.Text = dc.GHICHU;
                dtNgayKy.Value = dc.NGAYKY.Value;
                slkNhanVien.EditValue = dc.IDNV;
                cbbNewPB.SelectedValue = dc.IDPB2;
                cbbNewBP.SelectedValue = dc.IDBP2;
                cbbNewCV.SelectedValue = dc.IDCV2;
            }
        }
    }
}