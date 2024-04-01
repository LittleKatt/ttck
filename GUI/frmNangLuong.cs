using BUS;
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

namespace GUI
{
    public partial class frmNangLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmNangLuong()
        {
            InitializeComponent();
        }
        bool _them;
        string _soqd;
        NangLuong _nvnl;
        HopDongLD  _hopdong;
        NhanVien _nv; 
        private void frmNangLuong_Load(object sender, EventArgs e)
        {
            _nvnl = new NangLuong();
            _hopdong = new HopDongLD();
            _nv = new NhanVien();
            _them = false;
            LoadHopDong();
            LoadData();

            ShowHide(true);
            splitContainer1.Panel1Collapsed = true;
        }
        private void ShowHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
            txtSoQD.Enabled = !kt;
            txtGhiChu.Enabled = !kt;
            dtNgayKy.Enabled = !kt;
            dtNgayLenLuong.Enabled = !kt;
            slkHopDong.Enabled = !kt;
            gcDanhSach.Enabled = kt;
        }
        private void _reset()
        {
            txtSoQD.Text = string.Empty;          
            txtGhiChu.Text = string.Empty;
            dtNgayKy.Value = DateTime.Now;
            dtNgayLenLuong.Value = dtNgayKy.Value.AddDays(30);
            slkHopDong.Text = string.Empty;

        }
        void LoadHopDong()
        {
            slkHopDong.Properties.DataSource = _hopdong.getListFull();
            slkHopDong.Properties.ValueMember = "SOHD";
            slkHopDong.Properties.DisplayMember = "SOHD";
        }
        private void LoadData()
        {
            gcDanhSach.DataSource = _nvnl.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowHide(false);
            _them = true;
            _reset();
            splitContainer1.Panel1Collapsed = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            ShowHide(false);
            splitContainer1.Panel1Collapsed = false;
            gcDanhSach.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nvnl.Delete(_soqd, 1);
                var hd = _hopdong.getItem(slkHopDong.EditValue.ToString());
                hd.HESOLUONG = double.Parse(spHSLCu.EditValue.ToString());
                _hopdong.Update(hd);
                LoadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            LoadData();
            _them = false;
            ShowHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            ShowHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void SaveData()
        {
            NANGLUONG nl;
            if (_them)
            {

                var maxsoqd = _nvnl.MaxSoQuyetDinh();
                int so = int.Parse(maxsoqd.Substring(0, 4)) + 1;
                nl = new NANGLUONG();
                nl.SOQD = so.ToString("0000") + @"/" + DateTime.Now.Year.ToString() + "/QĐNL";
                nl.SOHD = slkHopDong.EditValue.ToString();
                nl.GHICHU = txtGhiChu.Text;
                nl.NGAYKY = dtNgayKy.Value;
                nl.NGAYLENLUONG = dtNgayLenLuong.Value;
                nl.HESOLUONGHIENTAI = _hopdong.getItem(slkHopDong.EditValue.ToString()).HESOLUONG;
                nl.HESOLUONGMOI = double.Parse(spHSLMoi.EditValue.ToString());
                nl.IDNV = _hopdong.getItem(slkHopDong.EditValue.ToString()).IDNV;
                nl.CREATED_BY = 1;
                nl.CREATED_DATE = DateTime.Now;
                _nvnl.Add(nl);
            }
            else
            {
                nl = _nvnl.getItem(_soqd);
                nl.SOHD = slkHopDong.EditValue.ToString();
                nl.GHICHU = txtGhiChu.Text;
                nl.NGAYKY = dtNgayKy.Value;
                nl.NGAYLENLUONG = dtNgayLenLuong.Value;
                nl.IDNV = _hopdong.getItem(slkHopDong.EditValue.ToString()).IDNV;
                nl.HESOLUONGHIENTAI = _hopdong.getItem(slkHopDong.EditValue.ToString()).HESOLUONG;
                nl.HESOLUONGMOI = double.Parse(spHSLMoi.EditValue.ToString());
                nl.UPDATED_BY = 1;
                nl.UPDATED_DATE = DateTime.Now;
                _nvnl.Update(nl);
            }
            var hd = _hopdong.getItem(slkHopDong.EditValue.ToString());
            hd.HESOLUONG = double.Parse(spHSLMoi.EditValue.ToString());
            _hopdong.Update(hd);
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soqd = gvDanhSach.GetFocusedRowCellValue("SOQD").ToString();
                var nl = _nvnl.getItem(_soqd);
                txtSoQD.Text = _soqd;                
                txtGhiChu.Text = nl.GHICHU;
                dtNgayKy.Value = nl.NGAYKY.Value;
                dtNgayLenLuong.Value = nl.NGAYLENLUONG.Value;
                slkHopDong.EditValue = nl.SOHD;
                spHSLCu.EditValue = nl.HESOLUONGHIENTAI;
                spHSLMoi.EditValue = nl.HESOLUONGMOI;
                txtNhanVien.Text = gvDanhSach.GetFocusedRowCellValue("HOTEN").ToString() ;
            }
        }

        private void slkHopDong_EditValueChanged(object sender, EventArgs e)
        {
            var hd = _hopdong.getItemFull(slkHopDong.EditValue.ToString());
            if (hd.Count != 0)
            {
                txtNhanVien.Text = hd[0].IDNV +" " + hd[0].HOTEN;
                spHSLCu.EditValue = hd[0].HESOLUONG;
            }
        }
    }
}