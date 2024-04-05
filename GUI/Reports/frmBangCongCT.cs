using DAO;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraReports.UI;

namespace GUI.Reports
{
    public partial class frmBangCongCT : DevExpress.XtraEditors.XtraForm
    {
        public frmBangCongCT()
        {
            InitializeComponent();
        }

        NhanVien _nhanvien;
        BangCongChiTiet _bcct;

        private void frmBangCongCT_Load(object sender, EventArgs e)
        {
            _nhanvien = new NhanVien();
            _bcct = new BangCongChiTiet();  
            LoadNhanVien();
            cbbKyCong.SelectedIndex = DateTime.Now.Month - 1;
        }

        void LoadNhanVien()
        {
            cbbNhanVien.DataSource = _nhanvien.getList();
            cbbNhanVien.DisplayMember = "HOTEN";
            cbbNhanVien.ValueMember = "IDNV";

        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            var lst = _bcct.getBangCongCT(DateTime.Now.Year * 100 + int.Parse(cbbKyCong.Text), int.Parse(cbbNhanVien.SelectedValue.ToString()));
            rptBangCongChiTiet rpt = new rptBangCongChiTiet(lst);
            rpt.ShowPreviewDialog();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}