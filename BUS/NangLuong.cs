using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.DTO;
using DAO;
namespace BUS
{
    public class NangLuong
    {
        QLNSEntities db = new QLNSEntities();

        public NANGLUONG getItem(string soqd)
        {
            return db.NANGLUONGs.FirstOrDefault(x => x.SOQD == soqd);
        }
        public List<NANGLUONG> getList()
        {
            return db.NANGLUONGs.ToList();
        }
        public List<NangLuong_DTO> getListFull()
        {
            var lstDC = db.NANGLUONGs.ToList();
            List<NangLuong_DTO> lstDTO = new List<NangLuong_DTO>();
            NangLuong_DTO nlDTO;
            foreach (var item in lstDC)
            {
                nlDTO = new NangLuong_DTO();
                nlDTO.SOQD = item.SOQD;
                nlDTO.HESOLUONGHIENTAI = item.HESOLUONGHIENTAI;
                nlDTO.HESOLUONGMOI = item.HESOLUONGMOI;
                
                nlDTO.IDNV = item.IDNV;
                var nv = db.NHANVIENs.FirstOrDefault(x => x.IDNV == item.IDNV);
                nlDTO.HOTEN = nv.HOTEN;
                nlDTO.GHICHU = item.GHICHU;
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
        public NANGLUONG Add(NANGLUONG nl)
        {
            try
            {
                db.NANGLUONGs.Add(nl);
                db.SaveChanges();
                return nl;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public NANGLUONG Update(NANGLUONG nl)
        {
            try
            {
                var _nl = db.NANGLUONGs.FirstOrDefault(x => x.SOQD == nl.SOQD);
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
                var _tv = db.NANGLUONGs.FirstOrDefault(x => x.SOQD == soqd);
                db.NANGLUONGs.Remove(_tv);
                //_tv.DELETED_BY = iduser;
                //_tv.DELETED_DATE = DateTime.Now;
                db.SaveChanges();

            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public string MaxSoQuyetDinh()
        {
            var _dc = db.NANGLUONGs.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
           if (_dc != null)
           {
                return _dc.SOQD;
           }
            else
           { return "0000"; }
        }
    }
}
