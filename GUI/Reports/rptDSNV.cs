using BUS.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptDSNV : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDSNV()
        {
            InitializeComponent();
        }

        List<NhanVien_DTO> _lstNV;
        public rptDSNV(List<NhanVien_DTO> lstNV)
        {
            InitializeComponent();
            this._lstNV = lstNV;
            this.DataSource = lstNV;   
            LoadData();
        }

        void LoadData()
        {
            lblIDNV.DataBindings.Add("Text", _lstNV, "IDNV");
            lblHoTen.DataBindings.Add("Text", _lstNV, "HOTEN");
            lblGioiTinh.DataBindings.Add("Text", _lstNV, "GIOITINH");
            lblNgaySinh.DataBindings.Add("Text", _lstNV, "NGAYSINH");
            lblCCCD.DataBindings.Add("Text", _lstNV, "CCCD");
            lblDienThoai.DataBindings.Add("Text", _lstNV, "DIENTHOAI");
            lblPhongBan.DataBindings.Add("Text", _lstNV, "TENPB");
            lblBoPhan.DataBindings.Add("Text", _lstNV, "TENBP");
            lblChucVu.DataBindings.Add("Text", _lstNV, "TENCV");
            lblTrinhDo.DataBindings.Add("Text", _lstNV, "TENTD");
            lblDanToc.DataBindings.Add("Text", _lstNV, "TENDT");
            lblTonGiao.DataBindings.Add("Text", _lstNV, "TENTG");

        }
    }
}
