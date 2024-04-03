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
using GUI.Reports;
using DevExpress.XtraReports.UI;
using DAO;
namespace GUI.TINHLUONG
{
    public partial class frmBangLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmBangLuong()
        {
            InitializeComponent();
        }
        BangLuong _bangluong;
        List<BANGLUONG> _lstBangLuong;
        int _namky; 
        private void frmBangLuong_Load(object sender, EventArgs e)
        {
            _bangluong = new BangLuong();
            cbbNam.Text = DateTime.Now.Year.ToString();
            cbbThang.Text = DateTime.Now.Month.ToString();
        }

        private void btnTinhLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _bangluong.TinhLuongNhanVien(int.Parse(cbbNam.Text)*100+ int.Parse(cbbThang.Text));
            
            loadData();
        }
        void loadData()
        {
            gcDanhSach.DataSource = _bangluong.getList(int.Parse(cbbNam.Text)*100 + int.Parse(cbbThang.Text));
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstBangLuong = _bangluong.getList(int.Parse(cbbNam.Text) * 100 + int.Parse(cbbThang.Text));
            _namky = int.Parse(cbbNam.Text) * 100 + int.Parse(cbbThang.Text);
        }
        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptBangLuong rpt = new rptBangLuong(_lstBangLuong, _namky);
            rpt.ShowPreviewDialog();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}