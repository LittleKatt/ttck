using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using BUS.DTO;
namespace BUS
{
    public class TangCa
    {
        QLNSEntities db = new QLNSEntities();

        public TANGCA getItem(int id)
        {
            return db.TANGCAs.FirstOrDefault(x => x.IDTC == id);
        }
        public List<TANGCA> getList()
        {
            return db.TANGCAs.ToList();
        }
        public List<TangCa_DTO> getListFull()
        {
            var lstTangCa = db.TANGCAs.ToList();
            List<TangCa_DTO> lstDTO = new List<TangCa_DTO>();
            TangCa_DTO tc;
           
            foreach (var item in lstTangCa)
            {
                tc = new TangCa_DTO();
                tc.IDTC = item.IDTC;
                tc.NAM = item.NAM;
                tc.THANG = item.THANG;
                tc.NGAY = item.NGAY; 
                tc.SOGIO = item.SOGIO;
                tc.IDNV = item.IDNV;
                
                var nv = db.NHANVIENs.FirstOrDefault(x => x.IDNV == item.IDNV);
                tc.HOTEN = nv.HOTEN;
                tc.IDLCA = item.IDLCA;
                var lc = db.LOAICAs.FirstOrDefault(x => x.IDLCA == item.IDLCA);
                tc.TENLOAICA = lc.TENLOAICA;
                tc.HESO = lc.HESO;
                tc.SOTIEN = item.SOTIEN;
                tc.GHICHU = item.GHICHU;                 
               
                tc .CREATED_BY = item.CREATED_BY;
                tc .CREATED_DATE = item.CREATED_DATE;
                tc .UPDATED_BY = item.UPDATED_BY;
                tc .UPDATED_DATE = item.UPDATED_DATE;
                tc .DELETED_BY = item.DELETED_BY;
                tc .DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(tc);
            }
            return lstDTO;
        }
        public TANGCA Add(TANGCA tc)
        {
            try
            {
                db.TANGCAs.Add(tc);
                db.SaveChanges();
                return tc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public TANGCA Update(TANGCA tc)
        {
            try
            {
                var _tc = db.TANGCAs.FirstOrDefault(x => x.IDTC == tc.IDTC);
                _tc.NAM = tc.NAM;
                _tc.THANG = tc.THANG;
                _tc.NGAY = tc.NGAY;
                _tc.IDNV = tc.IDNV; 
                _tc.SOGIO = tc.SOGIO;
                _tc.SOTIEN = tc.SOTIEN;
                _tc.IDLCA = tc.IDLCA;
                _tc.GHICHU = tc.GHICHU;
                _tc.UPDATED_BY = tc.UPDATED_BY;
                _tc.UPDATED_DATE = tc.UPDATED_DATE;

                db.SaveChanges();
                return tc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(int id, int iduser)
        {
            try
            {
                var _tc = db.TANGCAs.FirstOrDefault(x => x.IDTC == id);
                _tc.DELETED_BY = iduser;
                _tc.DELETED_DATE = DateTime.Now;
                db.SaveChanges();

            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
