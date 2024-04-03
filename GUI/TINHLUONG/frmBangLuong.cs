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
namespace GUI.TINHLUONG
{
    public partial class frmBangLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmBangLuong()
        {
            InitializeComponent();
        }
        BangLuong _bangluong;
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
        }
        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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