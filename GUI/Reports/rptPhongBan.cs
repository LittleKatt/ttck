using DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptPhongBan : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPhongBan()
        {
            InitializeComponent();
        }
        List<PHONGBAN> _lstPhongBan;
        public rptPhongBan(List<PHONGBAN> lstPhongBan)
        {
            InitializeComponent();
            this._lstPhongBan = lstPhongBan;
            this.DataSource = lstPhongBan;
            LoadData();
        }

        void LoadData()
        {
            lblIDPB.DataBindings.Add("Text", _lstPhongBan, "IDPB");
            lblTENPB.DataBindings.Add("Text", _lstPhongBan, "TENPB");
        }

    }
}
