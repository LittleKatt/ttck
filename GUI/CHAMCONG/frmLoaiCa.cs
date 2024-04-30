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
    public partial class frmLoaiCa : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaiCa()
        {
            InitializeComponent();
        }
        LoaiCa _loaica;
        bool _them;
        int _id;
        List<LOAICA> _lstLoaiCa;
        private void frmLoaiCa_Load(object sender, EventArgs e)
        {
            _them = false;
            _loaica = new LoaiCa();
            ShowHide(true);
            LoadData();
        }
        void ShowHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            txtLoaiCa.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
            spHeSo.Enabled = !kt;
        }


        void LoadData()
        {
            gcDanhSach.DataSource = _loaica.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstLoaiCa = _loaica.getList();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            _them = true;
            txtLoaiCa.Text = string.Empty;
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
                _loaica.Delete(_id, 1);
                LoadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtLoaiCa.Text) || string.IsNullOrEmpty(spHeSo.Text))
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
            rptLoaiCa rpt = new rptLoaiCa(_lstLoaiCa);
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
                LOAICA lc = new LOAICA();
                lc.TENLOAICA = txtLoaiCa.Text;
                lc.HESO = double.Parse(spHeSo.EditValue.ToString());
                lc.CREATED_BY = 1; 
                lc.CREATED_DATE = DateTime.Now;
                _loaica.Add(lc);
            }
            else
            {
                var lc = _loaica.getItem(_id);
                lc.TENLOAICA = txtLoaiCa.Text;
                lc.HESO = double.Parse(spHeSo.EditValue.ToString());
                lc.UPDATED_BY = 1;
                lc.UPDATED_DATE = DateTime.Now;
                _loaica.Update(lc);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDLCA").ToString());
                txtLoaiCa.Text = gvDanhSach.GetFocusedRowCellValue("TENLOAICA").ToString();
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

        private void txtLoaiCa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là điều khiển và là ký tự số
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn việc nhập
                MessageBox.Show("Loại ca phải là ký tự chữ", "Thông Báo "); // Hiển thị thông báo
            }
            else if (txtLoaiCa.Text.Length > 50)
            {
                MessageBox.Show("Loại ca không được vượt quá 50 ký tự", "Thông Báo ");
                txtLoaiCa.Text = txtLoaiCa.Text.Substring(0, 50);
                // Đặt con trỏ văn bản (caret) tại cuối chuỗi
                txtLoaiCa.SelectionStart = txtLoaiCa.Text.Length;
                // Ngăn chặn xử lý ký tự tiếp theo
                e.Handled = true;
            }
        }
    }
}