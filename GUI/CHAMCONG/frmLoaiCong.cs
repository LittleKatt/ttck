using BUS;
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

namespace GUI.CHAMCONG
{
    public partial class frmLoaiCong : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaiCong()
        {
            InitializeComponent();
        }
        LoaiCong _loaicong;
        bool _them;
        int _id;
        List<LOAICONG> _lstLoaiCong;
        private void frmLoaiCong_Load(object sender, EventArgs e)
        {
            _them = false;
            _loaicong = new LoaiCong();
            ShowHide(true);
            LoadData();
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
            txtLoaiCong.Enabled = !kt;
            spHeSo.Enabled = !kt;
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _loaicong.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstLoaiCong = _loaicong.getList();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            _them = true;
            txtLoaiCong.Text = string.Empty;
            spHeSo.EditValue = 1;
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
                _loaicong.Delete(_id, 1);
                LoadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoaiCong.Text) || string.IsNullOrEmpty(spHeSo.Text))
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
            rptLoaiCong rpt = new rptLoaiCong(_lstLoaiCong);
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
                LOAICONG lc = new LOAICONG();
                lc.TENLC = txtLoaiCong.Text;
                lc.HESO = double.Parse(spHeSo.EditValue.ToString());
                lc.CREATED_BY = 1;
                lc.CREATED_DATE = DateTime.Now;
                _loaicong.Add(lc);
            }
            else
            {
                var lc = _loaicong.getItem(_id);
                lc.TENLC = txtLoaiCong.Text;
                lc.HESO = double.Parse(spHeSo.EditValue.ToString());
                lc.UPDATED_BY = 1;
                lc.UPDATED_DATE = DateTime.Now;
                _loaicong.Update(lc);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDLC").ToString());
                txtLoaiCong.Text = gvDanhSach.GetFocusedRowCellValue("TENLC").ToString();
                spHeSo.Text = gvDanhSach.GetFocusedRowCellValue("HESO").ToString();

            }
        }

        private void spHeSo_EditValueChanged(object sender, EventArgs e)
        {
            if (spHeSo.Value < 1)
            {
                MessageBox.Show("Hệ số lương phải lớn hơn 0", "Thông Báo");
                spHeSo.Value = 1; // Đặt lại giá trị thành 1
            }
            else if (spHeSo.Value > 12)
            {
                MessageBox.Show("Hệ số lương không vượt quá 12", "Thông Báo");
                spHeSo.Value = 1;
            }
        }

        private void txtLoaiCong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là điều khiển và là ký tự số
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn việc nhập
                MessageBox.Show("Loại công phải là ký tự chữ", "Thông Báo "); // Hiển thị thông báo
            }
            else if (txtLoaiCong.Text.Length > 50)
            {
                MessageBox.Show("Loại công không được vượt quá 50 ký tự", "Thông Báo ");
                txtLoaiCong.Text = txtLoaiCong.Text.Substring(0, 50);
                // Đặt con trỏ văn bản (caret) tại cuối chuỗi
                txtLoaiCong.SelectionStart = txtLoaiCong.Text.Length;
                // Ngăn chặn xử lý ký tự tiếp theo
                e.Handled = true;
            }
        }
    }
}