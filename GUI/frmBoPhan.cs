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
    public partial class frmBoPhan : DevExpress.XtraEditors.XtraForm
    {
        public frmBoPhan()
        {
            InitializeComponent();
        }

        BoPhan _bophan;
        bool _them;
        int _id;
        List<BOPHAN> _lstBoPhan; 
        private void frmBoPhan_Load(object sender, EventArgs e)
        {
            _them = false;
            _bophan = new BoPhan();
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
            gcDanhSach.DataSource = _bophan.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstBoPhan = _bophan.getList();
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
                _bophan.Delete(_id);
                LoadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
            if(string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông Báo "); // Hiển thị thông báo
                txtTen.Focus();
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
            rptBoPhan rpt = new rptBoPhan(_lstBoPhan);
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
                BOPHAN bp = new BOPHAN();
                bp.TENBP = txtTen.Text;
                _bophan.Add(bp);
            }
            else
            {
                var bp = _bophan.getItem(_id);
                bp.TENBP = txtTen.Text;
                _bophan.Update(bp);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDBP").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENBP").ToString();
            }
            
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTen.Text.Length >= 50)
            {
                MessageBox.Show("Tên bộ phận không được vượt quá 50 ký tự", "Thông Báo");
                txtTen.Clear();
            }
            // Kiểm tra nếu ký tự không phải là điều khiển và là ký tự số
            else if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn việc nhập
                MessageBox.Show("Tên bộ phận phải là chữ ", "Thông Báo "); // Hiển thị thông báo
            }
        }
    }
}