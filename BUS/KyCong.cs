using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO; 
namespace BUS
{
    public class KyCong
    {
        QLNSEntities db = new QLNSEntities();

        public KYCONG getItem(int id)
        {
            return db.KYCONGs.FirstOrDefault(x => x.IDCK == id);
        }
        public List<KYCONG> getList()
        {
            return db.KYCONGs.ToList();
        }
        public KYCONG Add(KYCONG kc)
        {
            try
            {
                db.KYCONGs.Add(kc);
                db.SaveChanges();
                return kc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public KYCONG Update(KYCONG kc)
        {
            try
            {
                var _kc = db.KYCONGs.FirstOrDefault(x => x.IDCK == kc.IDCK);
                _kc.IDCKCT = kc.IDCKCT;
                _kc.NAM = kc.NAM;
                _kc.THANG = kc.THANG; 
                _kc.KHOA = kc.KHOA;
                _kc.NGAYTINHCONG = kc.NGAYTINHCONG;
                _kc.NGAYCONGTRONGTHANG = kc.NGAYCONGTRONGTHANG;
                _kc.TRANGTHAI = kc.TRANGTHAI; 
                _kc.UPDATED_BY = kc.UPDATED_BY;
                _kc.UPDATED_DATE = kc.UPDATED_DATE;

                db.SaveChanges();
                return kc;
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
                var _kc = db.KYCONGs.FirstOrDefault(x => x.IDCK == id);
                
                _kc.DELETED_BY = iduser;
                _kc.DELETED_DATE = DateTime.Now;
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
