using BUS.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptNangLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public rptNangLuong()
        {
            InitializeComponent();
        }
        List<NangLuong_DTO> _lstNangLuong;
        public rptNangLuong(List<NangLuong_DTO> lstNangLuong)
        {
            InitializeComponent();
            this._lstNangLuong = lstNangLuong;
            this.DataSource = lstNangLuong;
            LoadData();
        }

        void LoadData()
        {
            lblSOQD.DataBindings.Add("Text", _lstNangLuong, "SOQD");
            lblNGAYKY.DataBindings.Add("Text", _lstNangLuong, "NGAYKY");
            lblNHANVIEN.DataBindings.Add("Text", _lstNangLuong, "HOTEN");
            lblLENLUONG.DataBindings.Add("Text", _lstNangLuong, "NGAYLENLUONG");
            lblGHICHU.DataBindings.Add("Text", _lstNangLuong, "GHICHU");
            lblHSLCU.DataBindings.Add("Text", _lstNangLuong, "HESOLUONGHIENTAI");
            lblHSLMOI.DataBindings.Add("Text", _lstNangLuong, "HESOLUONGMOI");

        }
    }
}
