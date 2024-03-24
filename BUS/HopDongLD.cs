using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
