using BUS.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptThoiViec : DevExpress.XtraReports.UI.XtraReport
    {
        public rptThoiViec()
        {
            InitializeComponent();
        }
        List<ThoiViec_DTO> _lstThoiViec;
        public rptThoiViec(List<ThoiViec_DTO> lstthoiviec)
        {
            InitializeComponent();
            this._lstThoiViec = lstthoiviec;
            this.DataSource = lstthoiviec;
            LoadData();
        }

        void LoadData()
        {
            lblSOQD.DataBindings.Add("Text", _lstThoiViec, "SOQD");
            lblNGAYNOPDON.DataBindings.Add("Text", _lstThoiViec, "NGAYNOPDON");
            lblNGAYNGHI.DataBindings.Add("Text", _lstThoiViec, "NGAYNGHI");
            lblNHANVIEN.DataBindings.Add("Text", _lstThoiViec, "HOTEN");
            lblGHICHU.DataBindings.Add("Text", _lstThoiViec, "GHICHU");
            
            lblLYDO.DataBindings.Add("Text", _lstThoiViec, "LYDO");

        }

    }
}
