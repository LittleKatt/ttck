using BUS.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptKyLuat : DevExpress.XtraReports.UI.XtraReport
    {
        public rptKyLuat()
        {
            InitializeComponent();
        }
        List<KTKL_DTO> _lstKTKL;
        public rptKyLuat(List<KTKL_DTO> lstktkl)
        {
            InitializeComponent();
            this._lstKTKL = lstktkl;
            this.DataSource = lstktkl;
            LoadData();
        }

        void LoadData()
        {
            lblSOQD.DataBindings.Add("Text", _lstKTKL, "SOQD");
            lblNGAYKY.DataBindings.Add("Text", _lstKTKL, "NGAYKY");
            lblNHANVIEN.DataBindings.Add("Text", _lstKTKL, "HOTEN");
            lblLYDO.DataBindings.Add("Text", _lstKTKL, "LYDO");
            lblNOIDUNG.DataBindings.Add("Text", _lstKTKL, "NOIDUNG");
            lblNGAYBATDAU.DataBindings.Add("Text", _lstKTKL, "TUNGAY");
            lblNGAYKETTHUC.DataBindings.Add("Text", _lstKTKL, "DENNGAY");
        }

    }
}
