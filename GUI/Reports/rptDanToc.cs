using BUS;
using BUS.DTO;
using DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptDanToc : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanToc()
        {
            InitializeComponent();
        }
        //DanToc _dantoc;
        List<DANTOC> _lstDanToc;
        public rptDanToc(List<DANTOC> lstDanToc)
        {
            InitializeComponent();
            this._lstDanToc = lstDanToc;
            this.DataSource = lstDanToc;
            LoadData();
        }

        void LoadData()
        {
            lblID.DataBindings.Add("Text", _lstDanToc, "ID");
            lblTENDT.DataBindings.Add("Text", _lstDanToc, "TENDT");
        }

    }
}
