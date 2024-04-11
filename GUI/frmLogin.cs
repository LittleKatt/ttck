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
using DevExpress.XtraSplashScreen;
using BUS;
namespace GUI
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        Users _user; 
      

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _user = new Users();
                          
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            int lg = _user.Login(txtTenDangNhap.Text, txtMatKhau.Text);
            if (lg == 1)
            {
                if (HamXuLy.handle != null)
                    SplashScreenManager.CloseOverlayForm(HamXuLy.handle);
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên Đăng nhập hoặc Mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}