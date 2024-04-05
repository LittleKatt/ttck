using DAO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptBangCongChiTiet : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBangCongChiTiet()
        {
            InitializeComponent();
        }

        public List<BANGCONGCHITIET> _bcct;
        public rptBangCongChiTiet(List<BANGCONGCHITIET> bcct)
        {
            InitializeComponent();
            this._bcct = bcct;
            this.DataSource = _bcct;
            BindingData();
        }

        void BindingData()
        {
            lblIDNV.DataBindings.Add("Text", DataSource, "IDNV");
            lblHOTEN.DataBindings.Add("Text", DataSource, "HOTEN");
            lblNGAY.DataBindings.Add("Text", DataSource, "NGAY");
            lblTHU.DataBindings.Add("Text", DataSource, "THU");
            lblGIOVAO.DataBindings.Add("Text", DataSource, "GIOVAO");
            lblGIORA.DataBindings.Add("Text", DataSource, "GIORA");
            lblPHEP.DataBindings.Add("Text", DataSource, "NGAYPHEP");
            lblLE.DataBindings.Add("Text", DataSource, "CONGNGAYLE");
            lblCN.DataBindings.Add("Text", DataSource, "CONGCHUNHAT");
            lblCONG.DataBindings.Add("Text", DataSource, "NGAYCONG");
            lblKYHIEU.DataBindings.Add("Text", DataSource, "KYHIEU");
            lblGHICHU.DataBindings.Add("Text", DataSource, "GHICHU");
            lblKyCong.DataBindings.Add("Text", DataSource, "IDKCCT");
        }
    }
}
