using BUS.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptTangCa : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTangCa()
        {
            InitializeComponent();
        }
        List<TangCa_DTO> _lstTangCa;
        public rptTangCa(List<TangCa_DTO> lstTangCa)
        {
            InitializeComponent();
            this._lstTangCa = lstTangCa;
            this.DataSource = lstTangCa;
            LoadData();
        }

        void LoadData()
        {
            lblDELETED_BY.DataBindings.Add("Text", _lstTangCa, "DELETED_BY");
            lblHOTEN.DataBindings.Add("Text", _lstTangCa, "HOTEN");
            lblTENLCA.DataBindings.Add("Text", _lstTangCa, "TENLOAICA");
            lblHESO.DataBindings.Add("Text", _lstTangCa, "HESO");
            lblSOGIO.DataBindings.Add("Text", _lstTangCa, "SOGIO");
            lblSOTIEN.DataBindings.Add("Text", _lstTangCa, "SOTIEN");
            lblGHICHU.DataBindings.Add("Text", _lstTangCa, "GHICHU");


        }

    }
}
