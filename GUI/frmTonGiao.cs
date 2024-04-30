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
using BUS;
using GUI.Reports;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class frmTonGiao : DevExpress.XtraEditors.XtraForm
    {
        public frmTonGiao()
        {
            InitializeComponent();
        }

        TonGiao _tongiao;
        List<TONGIAO> _lstTonGiao;
        bool _them;
        int _id;
        private void frmTonGiao_Load(object sender, EventArgs e)
        {
            _them = false;
            _tongiao = new TonGiao();
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
            gcDanhSach.DataSource = _tongiao.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstTonGiao = _tongiao.getList();
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
                _tongiao.Delete(_id);
                LoadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTen.Text.Length >= 50)
            {
                MessageBox.Show("Tên tôn giáo không được vượt quá 50 ký tự", "Thông Báo");
                txtTen.Clear();
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
            rptTonGiao rpt = new rptTonGiao(_lstTonGiao);
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
                TONGIAO tg = new TONGIAO();
                tg.TENTG = txtTen.Text;
                _tongiao.Add(tg);
            }
            else
            {
                var tg = _tongiao.getItem(_id);
                tg.TENTG = txtTen.Text;
                _tongiao.Update(tg);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("ID").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENTG").ToString();
            }
            
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Kiểm tra nếu ký tự không phải là điều khiển và là ký tự số
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn việc nhập
                MessageBox.Show("Tên tôn giáo phải là chữ ", "Thông Báo "); // Hiển thị thông báo
            }
        }
    }
}