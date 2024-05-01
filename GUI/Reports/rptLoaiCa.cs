using DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptLoaiCa : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLoaiCa()
        {
            InitializeComponent();
        }
        List<LOAICA> _lstLoaiCa;
        public rptLoaiCa(List<LOAICA> lstLoaiCA)
        {
            InitializeComponent();
            this._lstLoaiCa = lstLoaiCA;
            this.DataSource = lstLoaiCA;
            LoadData();
        }

        void LoadData()
        {
           
            lblIDLC.DataBindings.Add("Text", _lstLoaiCa, "IDLCA");
            lblTENLC.DataBindings.Add("Text", _lstLoaiCa, "TENLOAICA");
            lblHESO.DataBindings.Add("Text", _lstLoaiCa, "HESO");

        }

    }
}
