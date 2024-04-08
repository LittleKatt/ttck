using BUS.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptDieuChuyen : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDieuChuyen()
        {
            InitializeComponent();
        }
        List<DieuChuyen_DTO> _lstDieuChuyen;
        public rptDieuChuyen(List<DieuChuyen_DTO> lstDieuChuyen)
        {
            InitializeComponent();
            this._lstDieuChuyen = lstDieuChuyen;
            this.DataSource = lstDieuChuyen;
            LoadData();
        }

        void LoadData()
        {
            lblSOQD.DataBindings.Add("Text", _lstDieuChuyen,"SOQD");
            lblNGAYKY.DataBindings.Add("Text",_lstDieuChuyen, "NGAYKY");
            lblNHANVIEN.DataBindings.Add("Text", _lstDieuChuyen, "HOTEN");
            lblPHONGBAN.DataBindings.Add("Text",_lstDieuChuyen ,"TENPB");
            lblPHONGBANMOI.DataBindings.Add("Text",_lstDieuChuyen, "TENPB2");
            lblBOPHAN.DataBindings.Add("Text", _lstDieuChuyen ,"TENBP");
            lblBOPHANMOI.DataBindings.Add("Text",_lstDieuChuyen, "TENBP2");
            lblCHUCVU.DataBindings.Add("Text", _lstDieuChuyen, "TENCV");
            lblCHUCVUMOI.DataBindings.Add("Text", _lstDieuChuyen, "TENCV2");
            lblLYDO.DataBindings.Add("Text", _lstDieuChuyen, "LYDO");
            lblGHICHU.DataBindings.Add("Text", _lstDieuChuyen, "GHICHU");
            lblDELETED_BY.DataBindings.Add("Text", _lstDieuChuyen, "DELETED_BY");
        }

    }
}
