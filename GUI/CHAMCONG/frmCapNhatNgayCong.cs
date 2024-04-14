using BUS;
using DAO;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
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
        public string _phongban;
        public int _cNgay;
        KyCongChiTiet _kcct;
        BangCongChiTiet _bcct;

        frmBangCongChiTiet frmBCCT = (frmBangCongChiTiet)Application.OpenForms["frmBangCongChiTiet"];
        private void frmCapNhatNgayCong_Load(object sender, EventArgs e)
        {
            _bcct = new BangCongChiTiet();
            _kcct = new KyCongChiTiet();
            lblIDNV.Text = _idnv.ToString();
            lblHoTen.Text = _hoten.ToString();
            
            string nam = _idkcct.ToString().Substring(0,4);
            string thang = _idkcct.ToString().Substring(4);
            string ngay = _ngay.Substring(1);
            DateTime _d =DateTime.Parse(nam+" - "+thang+" - "+ngay);
            cldNgayCong.SetDate(_d);
            
        } 
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string _valueChamCong = rdgChamCong.Properties.Items[rdgChamCong.SelectedIndex].Value.ToString();
            string _valueTGNghi = rdgTGNghi.Properties.Items[rdgTGNghi.SelectedIndex].Value.ToString();
            string fieldName = "D" + _cNgay.ToString();
            
            var kcct = _kcct.getItem(_idkcct, _idnv);

            //double? tongngaycong = kcct.TONGNGAYCONG;
            //double? tongngayphep = kcct.NGAYPHEP; 
            //double? tongngaykhongphep = kcct.NGHIKHONGPHEP;
            //double? tongngayle = kcct.CONGNGAYLE;
            if (cldNgayCong.SelectionRange.Start.Year*100+cldNgayCong.SelectionRange.Start.Month != _idkcct)
            {
                MessageBox.Show("Thực hiện chấm công không đúng kỳ công. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information );
                return;
            }

            //CẬP NHẬT KYCONGCHITIET => CẬP NHẬT BANGCONGCHITIET
            HamXuLy.execQuery("UPDATE KYCONGCHITIET SET " + fieldName + "='" + _valueChamCong + "' WHERE IDKCCT=" + _idkcct + " AND IDNV=" + _idnv);


            BANGCONGCHITIET bcct = _bcct.getItem(_idnv, _idkcct, cldNgayCong.SelectionStart.Day);

            //if (cldNgayCong.SelectionStart.DayOfWeek == DayOfWeek.Sunday)
            //{
            //    if (_valueTGNghi == "NN")
            //    {
            //        bcct.CONGCHUNHAT = 1;
            //        bcct.NGAYCONG = 0;
            //    }
            //    else
            //    {
            //        bcct.CONGCHUNHAT = 0.5;
            //        bcct.NGAYCONG = 0;
            //    }
            //}
            //else
            //{

                bcct.KYHIEU = _valueChamCong;
                switch (_valueChamCong)
                {
                    case "P":
                        if (_valueTGNghi == "NN")
                        {
                            bcct.NGAYPHEP = 1;
                            bcct.NGAYCONG = 0;
                        }
                        else
                        {
                            bcct.NGAYPHEP = 0.5;
                            bcct.NGAYCONG = 0.5;
                        }
                        break;
                    case "CT":
                        if (_valueTGNghi == "NN")
                        {
                            bcct.NGAYCONG = 1;
                        }
                        else
                        {
                            bcct.NGAYPHEP = 0.5;
                            bcct.NGAYCONG = 0.5;
                        }
                        break;
                    case "VR":
                        if (_valueTGNghi == "NN")
                        {
                            bcct.NGAYPHEP = 1;
                            bcct.NGAYCONG = 0;
                        }
                        else
                        {
                            bcct.NGAYPHEP = 0.5;
                            bcct.NGAYCONG = 0.5;
                        }
                        break;
                    case "V":
                        if (_valueTGNghi == "NN")
                        {
                            bcct.NGAYCONG = 0;
                            bcct.NGHIKHONGPHEP = 1; 
                        }
                        else
                        {
                            bcct.NGAYCONG = 0.5;
                            bcct.NGHIKHONGPHEP = 0.5; 
                        }
                        break;
                    default:
                        break;
                }
            //}

            //update bảng bangcongchitiet
            _bcct.Update(bcct);
            //tính ngày công, ngày phép
            double tongngaycong = _bcct.tongNgayCong(_idkcct, _idnv);
            double tongngayphep = _bcct.tongNgayPhep(_idkcct, _idnv);
            double congchunhat = _bcct.tongNgayCongChuNhat(_idkcct, _idnv);
            double tongnghiphep = _bcct.tongKhongPhep(_idkcct, _idnv);
            kcct.NGAYPHEP = tongngayphep;
            kcct.TONGNGAYCONG = tongngaycong;
            kcct.CONGCHUNHAT = congchunhat;
            kcct.NGHIKHONGPHEP = tongnghiphep;
            _kcct.Update(kcct);


            frmBCCT.loadBangCong();
           // MessageBox.Show(_valueChamCong+ "--"+ _valueTGNghi);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cldNgayCong_DateSelected(object sender, DateRangeEventArgs e)
        {
            _cNgay = cldNgayCong.SelectionRange.Start.Day;
        }
    }
}