using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.DTO;
using DAO;
namespace BUS
{
    public class NhanVien_ThoiViec
    {
        QLNSEntities db = new QLNSEntities();

        public NHANVIEN_THOIVIEC getItem(string soqd)
        {
            return db.NHANVIEN_THOIVIEC.FirstOrDefault(x => x.SOQD == soqd);
        }
        public List<NHANVIEN_THOIVIEC> getList()
        {
            return db.NHANVIEN_THOIVIEC.ToList();
        }
        public List<NhanVien_ThoiViec_DTO> getListFull()
        {
            var lstDC = db.NHANVIEN_THOIVIEC.ToList();
            List<NhanVien_ThoiViec_DTO> lstDTO = new List<NhanVien_ThoiViec_DTO>();
            NhanVien_ThoiViec_DTO nvDTO;
            foreach (var item in lstDC)
            {
                nvDTO = new NhanVien_ThoiViec_DTO();
                nvDTO.SOQD = item.SOQD;
                nvDTO.NGAYNOPDON = item.NGAYNOPDON;
                nvDTO.NGAYNGHI = item.NGAYNGHI;
                nvDTO.IDNV = item.IDNV;
                var nv = db.NHANVIENs.FirstOrDefault(x => x.IDNV == item.IDNV);
                nvDTO.HOTEN = nv.HOTEN; 

                nvDTO.LYDO = item.LYDO;
                nvDTO.GHICHU = item.GHICHU;
               
              
                nvDTO.CREATED_BY = item.CREATED_BY;
                nvDTO.CREATED_DATE = item.CREATED_DATE;
                nvDTO.UPDATED_BY = item.UPDATED_BY;
                nvDTO.UPDATED_DATE = item.UPDATED_DATE;
                nvDTO.DELETED_BY = item.DELETED_BY;
                nvDTO.DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(nvDTO);
            }
            return lstDTO;
        }
        public NHANVIEN_THOIVIEC Add(NHANVIEN_THOIVIEC tv)
        {
            try
            {
                db.NHANVIEN_THOIVIEC.Add(tv);
                db.SaveChanges(); 
                return tv;
            }

            catch(Exception ex) 
            { 
                throw new Exception("Lỗi: "+ex.Message);
            }   
        }
        public NHANVIEN_THOIVIEC Update(NHANVIEN_THOIVIEC tv)
        {
            try
            {
                var _tv = db.NHANVIEN_THOIVIEC.FirstOrDefault(x => x.SOQD == tv.SOQD);
                _tv.NGAYNOPDON =    tv.NGAYNOPDON;
                _tv.NGAYNGHI = tv.NGAYNGHI;
                _tv.IDNV = tv.IDNV;
                _tv.LYDO = tv.LYDO;
                _tv.GHICHU = tv.GHICHU;
                _tv.UPDATED_BY = tv.UPDATED_BY;
                _tv.UPDATED_DATE = tv.UPDATED_DATE;
                db.SaveChanges();
                return tv;
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
                var _tv = db.NHANVIEN_THOIVIEC.FirstOrDefault(x => x.SOQD == soqd);
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
            var _dc = db.NHANVIEN_THOIVIEC.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if (_dc != null)
            {
                return _dc.SOQD;
            }
            else
            { return "0000"; }
        }
    }
}
