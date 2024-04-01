using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.DTO;
using DAO;
namespace BUS
{
    public class ThoiViec
    {
        QLNSEntities db = new QLNSEntities();

        public THOIVIEC getItem(string soqd)
        {
            return db.THOIVIECs.FirstOrDefault(x => x.SOQD == soqd);
        }
        public List<THOIVIEC> getList()
        {
            return db.THOIVIECs.ToList();
        }
        public List<ThoiViec_DTO> getListFull()
        {
            var lstDC = db.THOIVIECs.ToList();
            List<ThoiViec_DTO> lstDTO = new List<ThoiViec_DTO>();
            ThoiViec_DTO nvDTO;
            foreach (var item in lstDC)
            {
                nvDTO = new ThoiViec_DTO();
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
        public THOIVIEC Add(THOIVIEC tv)
        {
            try
            {
                db.THOIVIECs.Add(tv);
                db.SaveChanges(); 
                return tv;
            }

            catch(Exception ex) 
            { 
                throw new Exception("Lỗi: "+ex.Message);
            }   
        }
        public THOIVIEC Update(THOIVIEC tv)
        {
            try
            {
                var _tv = db.THOIVIECs.FirstOrDefault(x => x.SOQD == tv.SOQD);
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
                var _tv = db.THOIVIECs.FirstOrDefault(x => x.SOQD == soqd);
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
            var _dc = db.THOIVIECs.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if (_dc != null)
            {
                return _dc.SOQD;
            }
            else
            { return "0000"; }
        }
    }
}
