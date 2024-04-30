using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.DTO;
using DAO;

namespace BUS
{
    public class HopDongLD
    {
        QLNSEntities db = new QLNSEntities();
        public HOPDONG getItem (string sohd)
        {
            return db.HOPDONGs.FirstOrDefault(x=>x.SOHD == sohd);
        }
       
        public List<HDLD_DTO> getItemFull(string sohd)
        {
            List<HOPDONG> lstHD = db.HOPDONGs.Where(x=>x.SOHD==sohd).ToList();
            List<HDLD_DTO> lstDTO = new List<HDLD_DTO>();
            HDLD_DTO hd;
            foreach (var item in lstHD)
            {
                hd = new HDLD_DTO();
                hd.SOHD = item.SOHD;
                //hd.NGAYBATDAU = "Từ ngày " +item.NGAYBATDAU.Value.ToString("dd/MM/yyyy").Substring(0,2) +"tháng" + item.NGAYBATDAU.Value.ToString("dd/MM/yyyy").Substring(3,2) + "năm" + item.NGAYBATDAU.Value.ToString("dd/MM/yyyy").Substring(6,2);
                hd.NGAYBATDAU = item.NGAYBATDAU.Value.ToString("dd/MM/yyyy");
                hd.NGAYKETTHUC = item.NGAYKETTHUC.Value.ToString("dd/MM/yyyy");
                hd.NGAYKY = item.NGAYKY.Value.ToString("dd/MM/yyyy");
                hd.THOIHAN = item.THOIHAN;
                hd.LUONGCOBAN = item.LUONGCOBAN;
                hd.HESOLUONG = item.HESOLUONG;
                hd.LANKY = item.LANKY;
                hd.NOIDUNG = " ngày " + item.NGAYKY.Value.ToString("dd/MM/yyyy").Substring(0, 2) + " tháng " + item.NGAYKY.Value.ToString("dd/MM/yyyy").Substring(3, 2) + " năm " + item.NGAYKY.Value.ToString("dd/MM/yyyy").Substring(6);
                hd.IDNV = item.IDNV;
                var nv = db.NHANVIENs.FirstOrDefault(n => n.IDNV == item.IDNV);
                hd.HOTEN = nv.HOTEN;
                hd.NGAYSINH = nv.NGAYSINH.Value.ToString("dd/MM/yyyy");
                hd.CCCD = nv.CCCD;
                hd.DIENTHOAI = nv.DIENTHOAI;
                hd.DIACHI = nv.DIACHI;
                hd.CREATED_BY = item.CREATED_BY;
                hd.CREATED_DATE = item.CREATED_DATE;
                hd.UPDATED_BY = item.UPDATED_BY;
                hd.UPDATED_DATE = item.UPDATED_DATE;
                hd.DELETED_BY = item.DELETED_BY;
                hd.DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(hd);
            }
            return lstDTO;
        }
        public List<HOPDONG>getList()
        {
            return db.HOPDONGs.ToList();
        }
        public List<HDLD_DTO> getListFull()
        {
            List<HOPDONG> lstHD = db.HOPDONGs.ToList();
            List<HDLD_DTO> lstDTO = new List<HDLD_DTO>();
            HDLD_DTO hd;
            foreach (var item in lstHD)
            {
                hd = new HDLD_DTO();
                hd.SOHD = item.SOHD;
                hd.NGAYBATDAU = item.NGAYBATDAU.Value.ToString("dd/MM/yyyy");
                hd.NGAYKETTHUC = item.NGAYKETTHUC.Value.ToString("dd/MM/yyyy");
                hd.NGAYKY = item.NGAYKY.Value.ToString("dd/MM/yyyy");
                hd.THOIHAN = item.THOIHAN;
                hd.LUONGCOBAN = item.LUONGCOBAN;
                hd.HESOLUONG = item.HESOLUONG;
                hd.LANKY = item.LANKY;
                hd.NOIDUNG = item.NOIDUNG;

                hd.IDNV = item.IDNV;
                var nv = db.NHANVIENs.FirstOrDefault(n => n.IDNV == item.IDNV);
                hd.HOTEN = nv.HOTEN;
                hd.NGAYSINH = nv.NGAYSINH.Value.ToString("dd/MM/yyyy");
                hd.CCCD = nv.CCCD;
                hd.DIENTHOAI = nv.DIENTHOAI;
                hd.DIACHI = nv.DIACHI;

                hd.CREATED_BY = item.CREATED_BY;
                hd.CREATED_DATE = item.CREATED_DATE;
                hd.UPDATED_BY = item.UPDATED_BY;
                hd.UPDATED_DATE = item.UPDATED_DATE;
                hd.DELETED_BY = item.DELETED_BY;
                hd.DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(hd);
            }
            return lstDTO;
        }
        public HOPDONG Add (HOPDONG hd)
        {
            try
            {
                db.HOPDONGs.Add(hd);
                db.SaveChanges();
                return hd;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }

        }
        public HOPDONG Update(HOPDONG hd)
        {
            try
            {
                var _hd = db.HOPDONGs.FirstOrDefault(x=>x.SOHD == hd.SOHD);
                _hd.NGAYBATDAU = hd.NGAYBATDAU;
                _hd.NGAYKETTHUC = hd.NGAYKETTHUC;
                _hd.NGAYKY = hd.NGAYKY;
                _hd.LANKY = hd.LANKY;
                _hd.LUONGCOBAN = hd.LUONGCOBAN;
                _hd.HESOLUONG = hd.HESOLUONG;
                _hd.IDNV = hd.IDNV;
                _hd.NOIDUNG = hd.NOIDUNG;
                _hd.THOIHAN = hd.THOIHAN;
                _hd.SOHD = hd.SOHD;
                _hd.UPDATED_BY = hd.UPDATED_BY;
                _hd.UPDATED_DATE = hd.UPDATED_DATE;
                db.SaveChanges();
                return hd;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void Delete (string sohd, int idnv)
        {
            var _hd = db.HOPDONGs.FirstOrDefault(x => x.SOHD == sohd);
            db.HOPDONGs.Remove(_hd);
            //_hd.DELETED_BY = idnv;
           // _hd.DELETED_DATE = DateTime.Now;
            db.SaveChanges();
        }
        public string MaxSoHopDong()
        {
            var _hd = db.HOPDONGs.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if (_hd != null)
            {
                return _hd.SOHD;
            }
            else
            { return "0000"; }
        }
        public List<HDLD_DTO>getNangLuong()
        {
            List<HOPDONG> lstHD = db.HOPDONGs.Where(x=>(x.NGAYBATDAU.Value.Month - DateTime.Now.Month) == 0 && (DateTime.Now.Year - x.NGAYBATDAU.Value.Year) == 2).ToList();
            List<HDLD_DTO> lstDTO = new List<HDLD_DTO>();
            HDLD_DTO hd;
            foreach (var item in lstHD)
            {
                hd = new HDLD_DTO();
                hd.SOHD = item.SOHD;
                hd.NGAYBATDAU = item.NGAYBATDAU.Value.ToString("dd/MM/yyyy");
                hd.NGAYKETTHUC = item.NGAYKETTHUC.Value.ToString("dd/MM/yyyy");
                hd.NGAYKY = item.NGAYKY.Value.ToString("dd/MM/yyyy");
                hd.THOIHAN = item.THOIHAN;
                hd.LUONGCOBAN = item.LUONGCOBAN;
                hd.HESOLUONG = item.HESOLUONG;
                hd.LANKY = item.LANKY;
                hd.NOIDUNG = item.NOIDUNG;

                hd.IDNV = item.IDNV;
                var nv = db.NHANVIENs.FirstOrDefault(n => n.IDNV == item.IDNV);
                hd.HOTEN = nv.HOTEN;
                hd.NGAYSINH = nv.NGAYSINH.Value.ToString("dd/MM/yyyy");
                hd.CCCD = nv.CCCD;
                hd.DIENTHOAI = nv.DIENTHOAI;
                hd.DIACHI = nv.DIACHI;

                hd.CREATED_BY = item.CREATED_BY;
                hd.CREATED_DATE = item.CREATED_DATE;
                hd.UPDATED_BY = item.UPDATED_BY;
                hd.UPDATED_DATE = item.UPDATED_DATE;
                hd.DELETED_BY = item.DELETED_BY;
                hd.DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(hd);
            }
            return lstDTO;
        }
    }
}
