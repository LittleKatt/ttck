using DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptLoaiCong : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLoaiCong()
        {
            InitializeComponent();
        }
        List<LOAICONG> _lstLoaiCong;
        public rptLoaiCong(List<LOAICONG> lstLoaiCong)
        {
            InitializeComponent();
            this._lstLoaiCong = lstLoaiCong;
            this.DataSource = lstLoaiCong;
            LoadData();
        }

        void LoadData()
        {
            lblDELETED_BY.DataBindings.Add("Text", _lstLoaiCong, "DELETED_BY");
            lblIDLCONG.DataBindings.Add("Text", _lstLoaiCong, "IDLC");
            lblTENLCONG.DataBindings.Add("Text", _lstLoaiCong, "TENLC");
            lblHESO.DataBindings.Add("Text", _lstLoaiCong, "HESO");

        }

    }
}
