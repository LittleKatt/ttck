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

namespace GUI.CHAMCONG
{
    public partial class frmCapNhatNgayCong : DevExpress.XtraEditors.XtraForm
    {
        public frmCapNhatNgayCong()
        {
            InitializeComponent();
        }

        public int _idnv;
        public string _hoten;
        public int _idkcct;
        public string _ngay;

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_idnv.ToString() + " - " + _idkcct.ToString() + " - " + _ngay);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}