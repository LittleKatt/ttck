using BUS.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GUI.Reports
{
    public partial class rptKhenThuong : DevExpress.XtraReports.UI.XtraReport
    {
        public rptKhenThuong()
        {
            InitializeComponent();
        }
        List<KTKL_DTO> _lstKTKL;
        public rptKhenThuong(List<KTKL_DTO> lstktkl)
        {
            InitializeComponent();
            this._lstKTKL = lstktkl;
            this.DataSource = lstktkl;
            LoadData();
        }

        void LoadData()
        {
            lblSOQD.DataBindings.Add("Text", _lstKTKL, "SOQD");
            lblNgayKy.DataBindings.Add("Text", _lstKTKL, "NGAYKY");
            lblNhanVien.DataBindings.Add("Text", _lstKTKL, "HOTEN");
            lblLyDo.DataBindings.Add("Text", _lstKTKL, "LYDO");
            lblNoiDung.DataBindings.Add("Text", _lstKTKL, "NOIDUNG");

        }

    }
}
