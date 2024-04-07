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
using BUS;
using DAO;
using GUI.Reports;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class frmPhongBan : DevExpress.XtraEditors.XtraForm
    {
        public frmPhongBan()
        {
            InitializeComponent();
        }

        PhongBan _phongban;
        bool _them;
        int _id;
        List<PHONGBAN> _lstPhongBan; 
        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            _them = false;
            _phongban = new PhongBan();
            ShowHide(true);
            LoadData();
        }

        void ShowHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            txtTen.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
        }


        void LoadData()
        {
            gcDanhSach.DataSource = _phongban.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstPhongBan = _phongban.getList();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            _them = true;
            txtTen.Text = string.Empty;
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
                _phongban.Delete(_id);
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
            rptPhongBan rpt = new rptPhongBan(_lstPhongBan);
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
                PHONGBAN pb = new PHONGBAN();
                pb.TENPB = txtTen.Text;
                _phongban.Add(pb);
            }
            else
            {
                var pb = _phongban.getItem(_id);
                pb.TENPB = txtTen.Text;
                _phongban.Update(pb);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if(gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDPB").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENPB").ToString();
            }
            
        }
    }
}