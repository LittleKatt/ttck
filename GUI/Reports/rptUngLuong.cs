using BUS.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptUngLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public rptUngLuong()
        {
            InitializeComponent();
        }
        List<UngLuong_DTO> _lstUngLuong;
        public rptUngLuong(List<UngLuong_DTO> lstUngLuong)
        {
            InitializeComponent();
            this._lstUngLuong = lstUngLuong;
            this.DataSource = lstUngLuong;
            LoadData();
        }

        void LoadData()
        {
            lblDELETED.DataBindings.Add("Text", _lstUngLuong, "DELETED_BY");
            lblHOTEN.DataBindings.Add("Text", _lstUngLuong, "HOTEN");
            lblNGAY.DataBindings.Add("Text", _lstUngLuong, "NGAY");
            lblSOTIEN.DataBindings.Add("Text", _lstUngLuong, "SOTIEN");
            lblGHICHU.DataBindings.Add("Text", _lstUngLuong, "GHICHU");


        }
    }
}
