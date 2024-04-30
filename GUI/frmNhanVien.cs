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
using DAO;
using BUS;
using System.IO;
using GUI.Reports;
using BUS.DTO;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private NhanVien _nhanvien;
        private PhongBan _phongban;
        private BoPhan _bophan;
        private ChucVu _chucvu;
        private TrinhDo _trinhdo;
        private DanToc _dantoc;
        private TonGiao _tongiao;
        private bool _them;
        private int _id;
        private Image _hinh;
        List<NhanVien_DTO> _lstNVDTO;

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            _them = false;
            _nhanvien = new NhanVien();
            _phongban = new PhongBan();
            _bophan = new BoPhan();
            _chucvu = new ChucVu();
            _trinhdo = new TrinhDo();
            _dantoc = new DanToc();
            _tongiao = new TonGiao();
            ShowHide(true);
            LoadData();
            LoadCombobox();
            splitContainer1.Panel1Collapsed = true;
        }

        void LoadCombobox ()
        {
            cbbPhongBan.DataSource = _phongban.getList();
            cbbPhongBan.DisplayMember = "TENPB";
            cbbPhongBan.ValueMember = "IDPB";
            cbbBoPhan.DataSource = _bophan.getList();
            cbbBoPhan.DisplayMember = "TENBP";
            cbbBoPhan.ValueMember = "IDBP";
            cbbChucVu.DataSource = _chucvu.getList();
            cbbChucVu.DisplayMember = "TENCV";
            cbbChucVu.ValueMember = "IDCV";
            cbbTrinhDo.DataSource = _trinhdo.getList();
            cbbTrinhDo.DisplayMember = "TENTD";
            cbbTrinhDo.ValueMember = "IDTD";
            cbbDanToc.DataSource = _dantoc.getList();
            cbbDanToc.DisplayMember = "TENDT";
            cbbDanToc.ValueMember = "ID";
            cbbTonGiao.DataSource = _tongiao.getList();
            cbbTonGiao.DisplayMember = "TENTG";
            cbbTonGiao.ValueMember = "ID";

        }
        void ShowHide(bool kt)
        {
            btnLuu.Enabled = !kt;
            btnHuy.Enabled = !kt;
            txtHoTen.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
            txtDiaChi.Enabled = !kt;
            txtDienThoai.Enabled = !kt;
            txtCCCD.Enabled = !kt;
            dtNgaySinh.Enabled = !kt;
            cbGioiTinh.Enabled = !kt;
            cbbBoPhan.Enabled = !kt;
            cbbChucVu.Enabled = !kt;
            cbbDanToc.Enabled = !kt;
            cbbPhongBan.Enabled = !kt;
            cbbTonGiao.Enabled = !kt;
            cbbTrinhDo.Enabled = !kt;
            btnHinhAnh.Enabled = !kt;
            ptbHinhAnh.Image = Properties.Resources.noimg;
            gcDanhSach.Enabled = kt;
        }

        void _reset ()
        {
            txtHoTen.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            cbGioiTinh.Checked = false;
            cbbPhongBan.Text = string.Empty;
            cbbBoPhan.Text = string.Empty;
            cbbChucVu.Text = string.Empty;
            cbbTrinhDo.Text = string.Empty;
            cbbDanToc.Text = string.Empty;
            cbbTonGiao.Text = string.Empty;
            dtNgaySinh.Value = DateTime.Now;
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _nhanvien.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstNVDTO = _nhanvien.getListFull();
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

            ptbHinhAnh.Image = _hinh;
            _them = false;
            ShowHide(false);
            //_reset();
            splitContainer1.Panel1Collapsed = false;
            gcDanhSach.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nhanvien.Delete(_id);
                LoadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHoTen.Text) && dtNgaySinh.Value != null && !string.IsNullOrEmpty(txtDienThoai.Text) && 
                !string.IsNullOrEmpty(txtCCCD.Text) && !string.IsNullOrEmpty(txtDiaChi.Text) && ptbHinhAnh.Image 
                != null && cbbPhongBan.SelectedValue != null && cbbBoPhan.SelectedValue != null && cbbChucVu.SelectedValue 
                != null && cbbTrinhDo.SelectedValue != null && cbbDanToc.SelectedValue != null && cbbTonGiao.SelectedValue != null)
            {
                SaveData();
                LoadData();
                _them = false;
                ShowHide(true);
                splitContainer1.Panel1Collapsed = true;
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông Báo "); // Hiển thị thông báo

            }

        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            ShowHide(true);
            splitContainer1.Panel1Collapsed = true;
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptDSNV rpt = new rptDSNV(_lstNVDTO);
            rpt.ShowPreview();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void SaveData()
        {
            if (_them)
            {
                NHANVIEN nv = new NHANVIEN();
                nv.HOTEN = txtHoTen.Text;
                nv.NGAYSINH = dtNgaySinh.Value;
                nv.GIOITINH = cbGioiTinh.Checked;
                nv.DIENTHOAI = txtDienThoai.Text;
                nv.CCCD = txtCCCD.Text;
                nv.DIACHI = txtDiaChi.Text;
                nv.HINHANH = ImageToBase64(ptbHinhAnh.Image, ptbHinhAnh.Image.RawFormat);
                nv.IDPB = int.Parse(cbbPhongBan.SelectedValue.ToString());
                nv.IDBP = int.Parse(cbbBoPhan.SelectedValue.ToString());
                nv.IDCV = int.Parse(cbbChucVu.SelectedValue.ToString());
                nv.IDTD = int.Parse(cbbTrinhDo.SelectedValue.ToString());
                nv.IDDT = int.Parse(cbbDanToc.SelectedValue.ToString());
                nv.IDTG = int.Parse(cbbTonGiao.SelectedValue.ToString());
                _nhanvien.Add(nv);
            }
            else
            {
                var nv = _nhanvien.getItem(_id);
                nv.HOTEN = txtHoTen.Text;
                nv.NGAYSINH = dtNgaySinh.Value;
                nv.GIOITINH = cbGioiTinh.Checked;
                nv.DIENTHOAI = txtDienThoai.Text;
                nv.CCCD = txtCCCD.Text;
                nv.DIACHI = txtDiaChi.Text;
                nv.HINHANH = ImageToBase64(ptbHinhAnh.Image, ptbHinhAnh.Image.RawFormat);
                nv.IDPB = int.Parse(cbbPhongBan.SelectedValue.ToString());
                nv.IDBP = int.Parse(cbbBoPhan.SelectedValue.ToString());
                nv.IDCV = int.Parse(cbbChucVu.SelectedValue.ToString());
                nv.IDTD = int.Parse(cbbTrinhDo.SelectedValue.ToString());
                nv.IDDT = int.Parse(cbbDanToc.SelectedValue.ToString());
                nv.IDTG = int.Parse(cbbTonGiao.SelectedValue.ToString());
                _nhanvien.Update(nv);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDNV").ToString());
                var nv = _nhanvien.getItem(_id);
                txtHoTen.Text = nv.HOTEN;
                dtNgaySinh.Value = nv.NGAYSINH.Value;
                cbGioiTinh.Checked = nv.GIOITINH.Value;
                txtDienThoai.Text = nv.DIENTHOAI;
                txtCCCD.Text = nv.CCCD;
                txtDiaChi.Text = nv.DIACHI;
                ptbHinhAnh.Image = Base64ToImage(nv.HINHANH);
                cbbPhongBan.SelectedValue = nv.IDPB;
                cbbBoPhan.SelectedValue = nv.IDBP;
                cbbChucVu.SelectedValue = nv.IDCV;
                cbbTrinhDo.SelectedValue = nv.IDTD;
                cbbDanToc.SelectedValue = nv.IDDT;
                cbbTonGiao.SelectedValue = nv.IDTG;
            }
        }

        public byte[] ImageToBase64 (Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        public Image Base64ToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture file (.png, .jpg) | *.png; *.jpg";
            openFile.Title = "Chọn hình ảnh";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ptbHinhAnh.Image = Image.FromFile(openFile.FileName);
                ptbHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là điều khiển và là ký tự số
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn việc nhập
                MessageBox.Show("Họ và tên nhân viên phải là ký tự chữ", "Thông Báo "); // Hiển thị thông báo
            }
            else if (txtHoTen.Text.Length > 50)
            {
                MessageBox.Show("Họ và tên nhân viên không được vượt quá 50 ký tự", "Thông Báo ");
                txtHoTen.Text = txtHoTen.Text.Substring(0, 50);
                // Đặt con trỏ văn bản (caret) tại cuối chuỗi
                txtHoTen.SelectionStart = txtHoTen.Text.Length;
                // Ngăn chặn xử lý ký tự tiếp theo
                e.Handled = true;
               
            }

        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là điều khiển và không phải là ký tự
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn việc nhập
                MessageBox.Show("Số điện thoại không được chứa ký tự chữ", "Thông Báo"); // Hiển thị thông báo
            }
            if (txtDienThoai.Text.Length >= 10)
            {
                txtDienThoai.Text = txtDienThoai.Text.Substring(0, 10);
                // Đặt con trỏ văn bản (caret) tại cuối chuỗi
                txtDienThoai.SelectionStart = txtDienThoai.Text.Length;
                // Ngăn chặn xử lý ký tự tiếp theo
                e.Handled = true;
            }

        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự không phải là điều khiển và không phải là ký tự
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn chặn việc nhập
                MessageBox.Show("Căn cước công dân không được chứa ký tự chữ", "Thông Báo"); // Hiển thị thông báo
            }
            if (txtCCCD.Text.Length >= 12)
            {
                txtCCCD.Text = txtCCCD.Text.Substring(0, 12);
                // Đặt con trỏ văn bản (caret) tại cuối chuỗi
                txtCCCD.SelectionStart = txtCCCD.Text.Length;
                // Ngăn chặn xử lý ký tự tiếp theo
                e.Handled = true;
            }

        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDiaChi.Text.Length > 70)
            {
                MessageBox.Show("Địa chỉ không vượt quá 70 ký tự", "Thông Báo"); // Hiển thị thông báo
                txtDiaChi.Text = txtDiaChi.Text.Substring(0, 70);
                // Đặt con trỏ văn bản (caret) tại cuối chuỗi
                txtDiaChi.Focus();
                // Ngăn chặn xử lý ký tự tiếp theo
                e.Handled = true;
            }
        }
    }
}