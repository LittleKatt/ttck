using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class KhenThuong_KyLuat
    {
        QLNSEntities db = new QLNSEntities();
        public KHENTHUONG_KYLUAT getItem(string soQD)
        {
            return db.KHENTHUONG_KYLUAT.FirstOrDefault(x=>x.SOQD==soQD);
        }

        public List<KHENTHUONG_KYLUAT> getList(int loai)
        {
            return db.KHENTHUONG_KYLUAT.Where(x => x.LOAI == loai).ToList();
        }

        public KHENTHUONG_KYLUAT Add (KHENTHUONG_KYLUAT kt)
        {
            try
            {
                db.KHENTHUONG_KYLUAT.Add(kt);
                db.SaveChanges();
                return kt;
            }
            catch (Exception ex)
            {

                throw new Exception ("Lỗi " + ex.Message);
            }
        }

        public KHENTHUONG_KYLUAT Update(KHENTHUONG_KYLUAT kt)
        {
            try
            {
                KHENTHUONG_KYLUAT _kt = db.KHENTHUONG_KYLUAT.FirstOrDefault(x=>x.SOQD == kt.SOQD);
                _kt.NGAY = kt.NGAY;
                _kt.TUNGAY = kt.TUNGAY;
                _kt.DENNGAY = kt.DENNGAY;
                _kt.LYDO = kt.LYDO;
                _kt.NOIDUNG = kt.NOIDUNG;
                _kt.LOAI = kt.LOAI;
                _kt.IDNV = kt.IDNV;
                _kt.UPDATE_BY = kt.UPDATE_BY;
                _kt.UPDATE_DATE = kt.UPDATE_DATE;
                db.SaveChanges();
                return kt;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public void Delete (string soqd)
        {
            try
            {
                KHENTHUONG_KYLUAT _kt = db.KHENTHUONG_KYLUAT.FirstOrDefault(x => x.SOQD == soqd);
                _kt.DELETED_BY = _kt.DELETED_BY;
                _kt.DELETED_DATE = _kt.DELETED_DATE;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi " + ex.Message);
            }
        }
    }
}
