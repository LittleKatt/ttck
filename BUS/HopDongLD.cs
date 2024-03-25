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
                hd.NGAYBATDAU = item.NGAYBATDAU;
                hd.NGAYKETTHUC = item.NGAYKETTHUC;
                hd.NGAYKY = item.NGAYKY;
                hd.LANKY = item.LANKY;
                hd.HESOLUONG = item.HESOLUONG;
                hd.NOIDUNG = item.NOIDUNG;
                hd.IDNV = item.IDNV;
                hd.THOIHAN = item.THOIHAN;
                var nv =db.NHANVIENs.FirstOrDefault(n=>n.IDNV == item.IDNV);
                hd.HOTEN = nv.HOTEN;
                hd.CREATED_BY = item.CREATED_BY;
                hd.CREATED_DATE = item.CREATED_DATE;
                hd.UPDATED_BY = item.UPDATED_BY;
                hd.UPDATED_DATE = item.UPDATED_DATE;
                hd.DELETE_BY = item.DELETE_BY;
                hd.DELETE_DATE = item.DELETE_DATE;
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

                throw new Exception(ex.Message);
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
                _hd.HESOLUONG = hd.HESOLUONG;
                _hd.IDNV = hd.IDNV;
                _hd.NOIDUNG = hd.NOIDUNG;
                _hd.THOIHAN = hd.THOIHAN;
                _hd.SOHD = hd.SOHD;
                _hd.UPDATED_BY = hd.UPDATED_BY;

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
            _hd.DELETE_BY = idnv;
            _hd.DELETE_DATE = DateTime.Now;
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
    }
}
