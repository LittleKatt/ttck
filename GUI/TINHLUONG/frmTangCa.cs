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

namespace GUI.TINHLUONG
{
    public partial class frmTangCa : DevExpress.XtraEditors.XtraForm
    {
        public frmTangCa()
        {
            InitializeComponent();
        }

        TangCa _tangca;
        NhanVien _nhanvien;
        LoaiCa _loaica;
        Sys_Config _config; 
        bool _them;
        int _id; 
        List<TangCa_DTO> _lstTangCa;
        private void frmTangCa_Load(object sender, EventArgs e)
        {
            _them = false;
            _tangca = new TangCa();
            _nhanvien = new NhanVien();
            _loaica = new LoaiCa();
            _config = new Sys_Config();
            ShowHide(true);
            LoadData();
            LoadNhanVien();
            LoadLoaiCa();
           
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
            spSoGio.Enabled = !kt;
            cbbLoaiCa.Enabled = !kt;
            slkNhanVien.Enabled = !kt;

        }
        void LoadNhanVien()
        {
            slkNhanVien.Properties.DataSource = _nhanvien.getListFull();
            slkNhanVien.Properties.ValueMember = "IDNV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
        }
        void LoadLoaiCa()
        {
            cbbLoaiCa.DataSource = _loaica.getList();
            cbbLoaiCa.ValueMember = "IDLCA";
            cbbLoaiCa.DisplayMember = "TENLOAICA";
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _tangca.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstTangCa = _tangca.getListFull();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            _them = true;
            txtNoiDung.Text = string.Empty;
            spSoGio.EditValue = 0;
            slkNhanVien.EditValue = 0;
            cbbLoaiCa.SelectedIndex = 0;
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
                _tangca.Delete(_id, 1);
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
            rptTangCa rpt = new rptTangCa(_lstTangCa);
            rpt.ShowPreview();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void SaveData()
        {
            if (_them)
            {
                TANGCA tc = new TANGCA();

                tc.IDLCA = int.Parse(cbbLoaiCa.SelectedValue.ToString());
                tc.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                tc.SOGIO = double.Parse(spSoGio.EditValue.ToString());
                tc.GHICHU = txtNoiDung.Text;
                tc.NAM = DateTime.Now.Year;
                tc.THANG = DateTime.Now.Month;
                tc.NGAY = DateTime.Now.Day;
                var lc = _loaica.getItem(int.Parse(cbbLoaiCa.SelectedValue.ToString()));
                var cg = _config.getItem("TANGCA");
                tc.SOTIEN = tc.SOGIO * lc.HESO * int.Parse(cg.Value);

                tc.CREATED_BY = 1;
                tc.CREATED_DATE = DateTime.Now;
                _tangca.Add(tc);
            }
            else
            {
                var tc = _tangca.getItem(_id);
                tc.IDLCA = int.Parse(cbbLoaiCa.SelectedValue.ToString());
                tc.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                tc.SOGIO = double.Parse(spSoGio.EditValue.ToString());
                tc.GHICHU = txtNoiDung.Text;
                tc.NAM = DateTime.Now.Year;
                tc.THANG = DateTime.Now.Month;
                tc.NGAY = DateTime.Now.Day;
                var lc = _loaica.getItem(int.Parse(cbbLoaiCa.SelectedValue.ToString()));
                var cg = _config.getItem("TANGCA");
                tc.SOTIEN = tc.SOGIO * lc.HESO * int.Parse(cg.Value);

                tc.UPDATED_BY = 1;
                tc.UPDATED_DATE = DateTime.Now;
                _tangca.Update(tc);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDTC").ToString());
                txtNoiDung.Text = gvDanhSach.GetFocusedRowCellValue("GHICHU").ToString();
                spSoGio.EditValue = gvDanhSach.GetFocusedRowCellValue("SOGIO");
                slkNhanVien.EditValue = gvDanhSach.GetFocusedRowCellValue("IDNV");
                cbbLoaiCa.SelectedValue = gvDanhSach.GetFocusedRowCellValue("IDLCA");

            }
        }
    }
}