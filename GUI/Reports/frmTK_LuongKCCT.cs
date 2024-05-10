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
    public partial class frmTK_LuongKCCT : DevExpress.XtraEditors.XtraForm
    {
        public frmTK_LuongKCCT()
        {
            InitializeComponent();
        }
        ThongKe_Luong_KCCT _tkluong;
        KyCong _kycong;
        private void frmTK_LuongKCCT_Load(object sender, EventArgs e)
        {
            _kycong = new KyCong();
            cbbKyCong.DataSource = _kycong.getList();
            cbbKyCong.DisplayMember = "IDKCCT";
            cbbKyCong.ValueMember = "IDKCCT";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            _tkluong = new ThongKe_Luong_KCCT();
            gcDanhSach.DataSource = _tkluong.ThongKeLuongTheoKCCT(int.Parse(cbbKyCong.SelectedValue.ToString()));
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel 2021 or Higher (.xlsx)|*.xlsx";
            if(sf.ShowDialog()== DialogResult.OK)
            {
                gcDanhSach.ExportToXlsx(sf.FileName);
            }
        }
    }
}