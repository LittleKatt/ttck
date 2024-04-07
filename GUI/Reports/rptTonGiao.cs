using DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptTonGiao : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTonGiao()
        {
            InitializeComponent();
        }
        List<TONGIAO> _lstTonGiao;
        public rptTonGiao(List<TONGIAO> lstTonGiao)
        {
            InitializeComponent();
            this._lstTonGiao = lstTonGiao;
            this.DataSource = lstTonGiao;
            LoadData();
        }

        void LoadData()
        {
            lblID.DataBindings.Add("Text", _lstTonGiao, "ID");
            lblTENTG.DataBindings.Add("Text", _lstTonGiao, "TENTG");
        }


    }
}
