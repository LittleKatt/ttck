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
using System.IO;
using DevExpress.XtraReports.UI;
using DevExpress.CodeParser;

namespace GUI
{
    public partial class frmHopDongLaoDong : DevExpress.XtraEditors.XtraForm
    {
        public frmHopDongLaoDong()
        {
            InitializeComponent();
        }

        HopDongLD _hdld;
        NhanVien _nhanvien;
        bool _them;
        string _sohd;
        List<HDLD_DTO> _lstHD;
        private void frmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            _hdld = new HopDongLD();
            _nhanvien = new NhanVien();
            _them = false;
            LoadData();
            LoadNhanVien();
            ShowHide(true);
            splitContainer1.Panel1Collapsed = true;
        }
        private void ShowHide(bool kt)
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

        private void _reset()
        {
            txtSoHD.Text = string.Empty;
            spLanKy.Text = "1";
            spHeSL.Text = "1";
            dtNgayBD.Value = DateTime.Now;
            dtNgayKT.Value = DateTime.Now;
            dtNgayKy.Value = DateTime.Now;
            slkNhanVien.Text = string.Empty;
            
        }

        void LoadNhanVien()
        {
            slkNhanVien.Properties.DataSource = _nhanvien.getList();
            slkNhanVien.Properties.ValueMember = "IDNV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
        }
        private void LoadData()
        {
            gcDanhSach.DataSource = _hdld.getListFull();
            //gcDanhSach.DataSource = _hdld.getList();
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
            if (string.IsNullOrEmpty(spLanKy.Text) ||
               string.IsNullOrEmpty(spHeSL.Text) || 
               string.IsNullOrEmpty(spLuongCoBan.Text) ||
               dtNgayBD.Value == null ||
               dtNgayKT.Value == null ||
               dtNgayKy.Value == null ||
               slkNhanVien.EditValue == null)  
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông Báo "); // Hiển thị thông báo
            }
            else
            {
                SaveData();
                LoadData();
                _them = false;
                ShowHide(true);
                splitContainer1.Panel1Collapsed = true;
            }    
            
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            ShowHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _lstHD = _hdld.getItemFull(_sohd);
            rptHDLD rpt = new rptHDLD(_lstHD);
            rpt.ShowPreviewDialog();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void SaveData()
        {
            if (_them)
            {
                //số hđ có dạng 0001/2024/HĐLĐ
                var maxsohd = _hdld.MaxSoHopDong();
                int so = int.Parse(maxsohd.Substring(0, 4)) + 1;

                HOPDONG hd = new HOPDONG();
                hd.SOHD = so.ToString("0000") + @"/" + DateTime.Now.Year.ToString() + @"/HĐLĐ";
                hd.NGAYBATDAU = dtNgayBD.Value;
                hd.NGAYKETTHUC = dtNgayKT.Value;
                hd.NGAYKY = dtNgayKy.Value;
                hd.THOIHAN = cbbThoiHan.Text;
                hd.LUONGCOBAN = int.Parse(spLuongCoBan.EditValue.ToString());
                hd.HESOLUONG = double.Parse(spHeSL.EditValue.ToString());
                hd.LANKY = int.Parse(spLanKy.EditValue.ToString());
                hd.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                //hd.NOIDUNG = txtNoiDung.RtfText;
                hd.CREATED_BY = 1;
                hd.CREATED_DATE = DateTime.Now;
                _hdld.Add(hd);
            }
            else
            {
                var hd = _hdld.getItem(_sohd);
                hd.NGAYBATDAU = dtNgayBD.Value;
                hd.NGAYKETTHUC = dtNgayKT.Value;
                hd.NGAYKY = dtNgayKy.Value;
                hd.THOIHAN = cbbThoiHan.Text;
                hd.LUONGCOBAN = int.Parse(spLuongCoBan.EditValue.ToString());
                hd.HESOLUONG = double.Parse(spHeSL.EditValue.ToString());
                hd.LANKY = int.Parse(spLanKy.EditValue.ToString());
                hd.IDNV = int.Parse(slkNhanVien.EditValue.ToString());
                //hd.NOIDUNG = txtNoiDung.RtfText;
                hd.UPDATED_BY = 1;
                hd.UPDATED_DATE = DateTime.Now;
                _hdld.Update(hd);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _sohd = gvDanhSach.GetFocusedRowCellValue("SOHD").ToString();
                var hd = _hdld.getItem(_sohd);
                txtSoHD.Text = _sohd;
                dtNgayBD.Value = hd.NGAYBATDAU.Value;
                dtNgayKT.Value = hd.NGAYKETTHUC.Value;
                dtNgayKy.Value = hd.NGAYKY.Value;
                cbbThoiHan.Text = hd.THOIHAN;
                spLuongCoBan.EditValue = hd.LUONGCOBAN;
                spHeSL.EditValue = hd.HESOLUONG;
                spLanKy.Text = hd.LANKY.ToString();
                slkNhanVien.EditValue = hd.IDNV;
                //txtNoiDung.RtfText = hd.NOIDUNG;
                _lstHD = _hdld.getItemFull(_sohd);
            }
        }

        private void cbbThoiHan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbThoiHan.Text == "03 tháng")
            {
                dtNgayKT.Value = dtNgayBD.Value.AddMonths(3);
            }
            else if (cbbThoiHan.Text == "06 tháng")
            {
                dtNgayKT.Value = dtNgayBD.Value.AddMonths(6);
            }
            else if (cbbThoiHan.Text == "12 tháng")
            {
                dtNgayKT.Value = dtNgayBD.Value.AddMonths(12);
            }    
            else
            {
                dtNgayKT.Value = dtNgayBD.Value.AddMonths(24);
            }
        }

        private void spLuongCoBan_EditValueChanged(object sender, EventArgs e)
        {
            if (spLuongCoBan.Value < 1)
            {
                MessageBox.Show("Lương cơ bản phải lớn hơn 1", "Thông Báo");
                spLuongCoBan.Value = 1; // Đặt lại giá trị thành 1
            }
        }

        private void spHeSL_EditValueChanged(object sender, EventArgs e)
        {
            if (spHeSL.Value < 1)
            {
                MessageBox.Show("Hệ số lương phải lớn hơn 0", "Thông Báo");
                spHeSL.Value = 1; // Đặt lại giá trị thành 1
            }
            else if (spHeSL.Value > 12)
            {
                MessageBox.Show("Hệ số lương không vượt quá 12", "Thông Báo");
                spHeSL.Value = 1;
            }    
        }

        private void spLanKy_EditValueChanged(object sender, EventArgs e)
        {
            if (spLanKy.Value < 1)
            {
                MessageBox.Show("Lần ký phải lớn hơn 0", "Thông Báo");
                spLanKy.Value = 1;
            }
        }
    }
}