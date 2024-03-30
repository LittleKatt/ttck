using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.DTO;
using DAO;
namespace BUS
{
    public class NhanVien_NangLuong
    {
        QLNSEntities db = new QLNSEntities();

        public NHANVIEN_NANGLUONG getItem(string soqd)
        {
            return db.NHANVIEN_NANGLUONG.FirstOrDefault(x => x.SOQD == soqd);
        }
        public List<NHANVIEN_NANGLUONG> getList()
        {
            return db.NHANVIEN_NANGLUONG.ToList();
        }
        public List<NhanVien_NangLuong_DTO> getListFull()
        {
            var lstDC = db.NHANVIEN_NANGLUONG.ToList();
            List<NhanVien_NangLuong_DTO> lstDTO = new List<NhanVien_NangLuong_DTO>();
            NhanVien_NangLuong_DTO nlDTO;
            foreach (var item in lstDC)
            {
                nlDTO = new NhanVien_NangLuong_DTO();
                nlDTO.SOQD = item.SOQD;
                nlDTO.HESOLUONGHIENTAI = item.HESOLUONGHIENTAI;
                nlDTO.HESOLUONGMOI = item.HESOLUONGMOI;
                
                nlDTO.IDNV = item.IDNV;
                var nv = db.NHANVIENs.FirstOrDefault(x => x.IDNV == item.IDNV);
                nlDTO.HOTEN = nv.HOTEN;

                nlDTO.NGAYKY = item.NGAYKY;
                nlDTO.NGAYLENLUONG = item.NGAYLENLUONG;                      
                nlDTO.CREATED_BY = item.CREATED_BY;
                nlDTO.CREATED_DATE = item.CREATED_DATE;
                nlDTO.UPDATED_BY = item.UPDATED_BY;
                nlDTO.UPDATED_DATE = item.UPDATED_DATE;
                nlDTO.DELETED_BY = item.DELETED_BY;
                nlDTO.DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(nlDTO);
            }
            return lstDTO;
        }
        public NHANVIEN_NANGLUONG Add(NHANVIEN_NANGLUONG nl)
        {
            try
            {
                db.NHANVIEN_NANGLUONG.Add(nl);
                db.SaveChanges();
                return nl;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public NHANVIEN_NANGLUONG Update(NHANVIEN_NANGLUONG nl)
        {
            try
            {
                var _nl = db.NHANVIEN_NANGLUONG.FirstOrDefault(x => x.SOQD == nl.SOQD);
                _nl.SOQD = nl.SOQD;
                _nl.HESOLUONGHIENTAI = nl.HESOLUONGHIENTAI; 
                _nl.HESOLUONGMOI = nl.HESOLUONGMOI;
                _nl.NGAYKY = nl.NGAYKY;
                _nl.NGAYLENLUONG = nl.NGAYLENLUONG;
                _nl.IDNV = nl.IDNV;
                _nl.GHICHU = nl.GHICHU;
                _nl.UPDATED_BY = nl.UPDATED_BY;
                _nl.UPDATED_DATE = nl.UPDATED_DATE;
                db.SaveChanges();
                return nl;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(string soqd, int iduser)
        {
            try
            {
                var _tv = db.NHANVIEN_NANGLUONG.FirstOrDefault(x => x.SOQD == soqd);
                _tv.DELETED_BY = iduser;
                _tv.DELETED_DATE = DateTime.Now;
                db.SaveChanges();

            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public string MaxSoQuyetDinh()
        {
            var _dc = db.NHANVIEN_NANGLUONG.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
           if (_dc != null)
           {
                return _dc.SOQD;
           }
            else
           { return "0000"; }
        }
    }
}
