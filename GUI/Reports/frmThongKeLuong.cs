using BUS;
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

namespace GUI.Reports
{
    public partial class frmThongKeLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKeLuong()
        {
            InitializeComponent();
        }
        //ThongKe_Luong _tkluong;
        KyCong _kycong;

        private void frmThongKeLuong_Load(object sender, EventArgs e)
        {
            _kycong = new KyCong();
            

            cbbNam.DataSource = _kycong.getList();
            cbbNam.DisplayMember = "NAM";
            cbbNam.ValueMember = "IDKCCT";
           
           
            cbbNam.SelectedValue = DateTime.Now.Year.ToString();        

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            
            //_tkluong = new ThongKe_Luong();
            //gcDanhSach.DataSource = _tkluong.ThongKeLuong(int.Parse(cbbNam.SelectedValue.ToString()));
            
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {

        }
    }
}