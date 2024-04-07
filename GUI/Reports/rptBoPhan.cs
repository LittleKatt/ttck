using DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptBoPhan : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBoPhan()
        {
            InitializeComponent();
        }
        List<BOPHAN> _lstBoPhan;
        public rptBoPhan(List<BOPHAN> lstBoPhan)
        {
            InitializeComponent();
            this._lstBoPhan = lstBoPhan;
            this.DataSource = lstBoPhan;
            LoadData();
        }

        void LoadData()
        {
            lblIDBP.DataBindings.Add("Text", _lstBoPhan, "IDBP");
            lblTENBP.DataBindings.Add("Text", _lstBoPhan, "TENBP");
        }

    }
}
