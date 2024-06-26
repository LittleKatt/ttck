﻿using DevExpress.XtraEditors;
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
using BUS.DTO;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Excel;

namespace GUI
{
    public partial class frmDanToc : DevExpress.XtraEditors.XtraForm
    {
        public frmDanToc()
        {
            InitializeComponent();
        }

        DanToc _dantoc;
        bool _them;
        int _id;
        List<DANTOC> _lstDanToc;

        private void frmDanToc_Load(object sender, EventArgs e)
        {
            _them = false;
            _dantoc = new DanToc();
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
            gcDanhSach.DataSource = _dantoc.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstDanToc = _dantoc.getList();
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
                _dantoc.Delete(_id);
                LoadData();
            }

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          if(string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
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
            rptDanToc rpt = new rptDanToc(_lstDanToc);
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
                DANTOC dt = new DANTOC();
                dt.TENDT = txtTen.Text;
                _dantoc.Add(dt);

            }
            else
            {
                var dt = _dantoc.getItem(_id);
                dt.TENDT = txtTen.Text;
                _dantoc.Update(dt);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("ID").ToString());
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENDT").ToString();
            }

        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là điều khiển và là ký tự số
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn việc nhập
                MessageBox.Show("Tên dân tộc phải là ký tự chữ ", "Thông Báo "); // Hiển thị thông báo
            }
            else if (txtTen.Text.Length >= 50)
            {
                MessageBox.Show("Tên dân tộc không được vượt quá 50 ký tự", "Thông Báo");
                txtTen.Text = txtTen.Text.Substring(0, 50);
                // Đặt con trỏ văn bản (caret) tại cuối chuỗi
                txtTen.SelectionStart = txtTen.Text.Length;
                // Ngăn chặn xử lý ký tự tiếp theo
                e.Handled = true;
            }

        }
    }
}