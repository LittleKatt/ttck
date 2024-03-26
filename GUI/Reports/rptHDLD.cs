using BUS.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptHDLD : DevExpress.XtraReports.UI.XtraReport
    {
        public rptHDLD()
        {
            InitializeComponent();
        }
        public rptHDLD(List<HDLD_DTO> lstHD)
        {
            InitializeComponent();
            this._lstHD = lstHD;
            this.DataSource = _lstHD;
            LoadData();
        }

        List<HDLD_DTO> _lstHD;
        void LoadData()
        {
            lblsoHD.DataBindings.Add("Text", _lstHD, "SOHD"); 
            lblLanKy.DataBindings.Add("Text", _lstHD, "LANKY");
        }
    }
}
