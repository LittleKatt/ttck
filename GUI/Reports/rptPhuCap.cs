using BUS.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptPhuCap : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPhuCap()
        {
            InitializeComponent();
        }
        List<PhuCap_DTO> _lstPhuCap;
        public rptPhuCap(List<PhuCap_DTO> lstPhuCap)
        {
            InitializeComponent();
            this._lstPhuCap = lstPhuCap;
            this.DataSource = lstPhuCap;
            LoadData();
        }

        void LoadData()
        {
            lblDELETED.DataBindings.Add("Text", _lstPhuCap, "DELETED_BY");
            lblHOTEN.DataBindings.Add("Text", _lstPhuCap, "HOTEN");
            lblTENPHUCAP.DataBindings.Add("Text", _lstPhuCap, "TENPC");
            lblSOTIEN.DataBindings.Add("Text", _lstPhuCap, "SOTIEN");
            lblNGAY.DataBindings.Add("Text", _lstPhuCap, "NGAY");
            lblNOIDUNG.DataBindings.Add("Text", _lstPhuCap, "NOIDUNG");


        }

    }
}
