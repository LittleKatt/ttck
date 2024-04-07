using DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptTrinhDo : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTrinhDo()
        {
            InitializeComponent();
        }
        List<TRINHDO> _lstTrinhDo;
        public rptTrinhDo(List<TRINHDO> lstTrinhDo)
        {
            InitializeComponent();
            this._lstTrinhDo = lstTrinhDo;
            this.DataSource = lstTrinhDo;
            LoadData();
        }

        void LoadData()
        {
            lblID.DataBindings.Add("Text", _lstTrinhDo, "IDTD");
            lblTENTD.DataBindings.Add("Text", _lstTrinhDo, "TENTD");
        }


    }
}
