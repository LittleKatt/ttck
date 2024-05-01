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
    public partial class frmPhuCap : DevExpress.XtraEditors.XtraForm
    {
        public frmPhuCap()
        {
            InitializeComponent();
        }
        PhuCap _phucap;
        NhanVien _nhanvien;
        bool _them;
        int _id;
        List<PhuCap_DTO> _lstPhuCap;
        private void frmPhuCap_Load(object sender, EventArgs e)
        {
            _them = false;
            _phucap = new PhuCap();
            _nhanvien = new NhanVien();
            ShowHide(true);
            LoadData();
            LoadNhanVien();
            LoadPhuCap();
            cbbPhuCap.SelectedIndexChanged += CbbPhuCap_SelectedIndexChanged;
        }

        private void CbbPhuCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pc = _phucap.getItemPC(int.Parse(cbbPhuCap.SelectedValue.ToString()));
            if (pc != null)
            {
                spSoTien.EditValue = pc.SOTIEN;
            }
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
            cbbPhuCap.Enabled = !kt;
            slkNhanVien.Enabled = !kt;
            

        }

        void LoadNhanVien()
        {
            slkNhanVien.Properties.DataSource = _nhanvien.getListFull();
            slkNhanVien.Properties.ValueMember = "IDNV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
        }

        void LoadPhuCap()
        {
            cbbPhuCap.DataSource = _phucap.getListPC();
            cbbPhuCap.ValueMember = "IDPC";
            cbbPhuCap.DisplayMember = "TENPC";
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _phucap.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstPhuCap = _phucap.getListFull();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            _them = true;
            txtNoiDung.Text = string.Empty;
            spSoTien.EditValue = 0;
            slkNhanVien.EditValue = 0;
            cbbPhuCap.SelectedIndex = 0;
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
                _phucap.Delete(_id, 1);
                LoadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoiDung.Text) || string.IsNullOrEmpty(spSoTien.Text) || slkNhanVien.EditValue == null || cbbPhuCap.Text == null)
            {

                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông Báo");
            }
            else
            {
                SaveData();
                LoadData();
                _them = false;
                ShowHide(true);
            }
               
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            ShowHide(true);
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptPhuCap rpt = new rptPhuCap(_lstPhuCap);
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
                PHUCAP pc = new PHUCAP();
                pc.IDPC = int.Parse(cbbPhuCap.SelectedValue.ToString());
                pc.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                pc.SOTIEN = double.Parse(spSoTien.EditValue.ToString());
               
                pc.NOIDUNG = txtNoiDung.Text;
                pc.NGAY = DateTime.Now;
                pc.CREATED_BY = 1;
                pc.CREATED_DATE = DateTime.Now;
                _phucap.Add(pc);
            }
            else
            {
                var pc = _phucap.getItem(_id);
                pc.IDPC = int.Parse(cbbPhuCap.SelectedValue.ToString());
                pc.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                pc.SOTIEN = double.Parse(spSoTien.EditValue.ToString());
               
                pc.NOIDUNG = txtNoiDung.Text;
                pc.NGAY = DateTime.Now;
                pc.UPDATED_BY = 1;
                pc.UPDATED_DATE = DateTime.Now;
                _phucap.Update(pc);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("ID").ToString());
               
                txtNoiDung.Text = gvDanhSach.GetFocusedRowCellValue("NOIDUNG").ToString();
                spSoTien.EditValue = gvDanhSach.GetFocusedRowCellValue("SOTIEN");
                slkNhanVien.EditValue = gvDanhSach.GetFocusedRowCellValue("IDNV");
                cbbPhuCap.SelectedValue = gvDanhSach.GetFocusedRowCellValue("IDPC");
                

            }
        }

        private void spSoTien_EditValueChanged(object sender, EventArgs e)
        {
            if (spSoTien.Value < 1)
            {
                MessageBox.Show("Tiền phụ cấp phải lớn hơn 0", "Thông Báo");
                spSoTien.Value = 1; // Đặt lại giá trị thành 1
            }
        }
    }
}