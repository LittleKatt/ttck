using DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptChucVu : DevExpress.XtraReports.UI.XtraReport
    {
        public rptChucVu()
        {
            InitializeComponent();
        }
        List<CHUCVU> _lstChucVu;
        public rptChucVu(List<CHUCVU> lstChucVu)
        {
            InitializeComponent();
            this._lstChucVu = lstChucVu;
            this.DataSource = lstChucVu;
            LoadData();
        }

        void LoadData()
        {
            lblIDCV.DataBindings.Add("Text", _lstChucVu, "IDCV");
            lblTENCV.DataBindings.Add("Text", _lstChucVu, "TENCV");
        }

    }
}
