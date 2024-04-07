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
using GUI.Reports;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class frmChucVu : DevExpress.XtraEditors.XtraForm
    {
        public frmChucVu()
        {
            InitializeComponent();
        }

        ChucVu _chucvu;
        bool _them;
        int _id;
        List<CHUCVU> _lstChucVu; 
        private void frmChucVu_Load(object sender, EventArgs e)
        {
            _them = false;
            _chucvu = new ChucVu();
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
            gcDanhSach.DataSource = _chucvu.getList();
            gvDanhSach.OptionsBehavior.Editable = false;

            _lstChucVu = _chucvu.getList();
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
                _chucvu.Delete(_id);
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
            rptChucVu rpt = new rptChucVu(_lstChucVu);
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
                CHUCVU cv = new CHUCVU();
                cv.TENCV = txtTen.Text;
                _chucvu.Add(cv);
            }
            else
            {
                var cv = _chucvu.getItem(_id);
                cv.TENCV = txtTen.Text;
                _chucvu.Update(cv);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDCV").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENCV").ToString();
            }
        }
    }
}