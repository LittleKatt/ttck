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
using DAO;
using BUS;

namespace GUI
{
    public partial class frmHopDongLaoDong : DevExpress.XtraEditors.XtraForm
    {
        public frmHopDongLaoDong()
        {
            InitializeComponent();
        }

        HopDongLD _hdld;
        bool _them;
        string _sohd;
        private void frmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            _hdld = new HopDongLD();
            _them = false;
            LoadData();
            ShowHide(true);
            splitContainer1.Panel1Collapsed = true;
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
            txtSoHD.Enabled = !kt;
            spLanKy.Enabled = !kt;
            spHeSL.Enabled = !kt;
            dtNgayBD.Enabled = !kt;
            dtNgayKT.Enabled = !kt;
            dtNgayKy.Enabled = !kt;
            slkNhanVien.Enabled = !kt;
            gcDanhSach.Enabled = kt;
        }

        void _reset()
        {
            txtSoHD.Text = string.Empty;
            spLanKy.Text = "1";
            spHeSL.Text = "1";
            dtNgayBD.Value = DateTime.Now;
            dtNgayKT.Value = dtNgayBD.Value.AddMonths(6);
            dtNgayKy.Value = DateTime.Now;
            slkNhanVien.Text = string.Empty;
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _hdld.getList();
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
                _hdld.Delete(_sohd,1);
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
        void SaveData()
        {
            if (_them)
            {
               
            }
            else
            {
                
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _sohd = gvDanhSach.GetFocusedRowCellValue("SOHD").ToString();
            }
        }
    }
}