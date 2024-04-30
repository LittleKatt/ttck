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

        public KYCONG getItem(int idkcct)
        {
            return db.KYCONGs.FirstOrDefault(x => x.IDKCCT == idkcct);
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
                var _kc = db.KYCONGs.FirstOrDefault(x => x.IDKCCT == kc.IDKCCT);
                _kc.IDKCCT = kc.IDKCCT;
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
        public void Delete(int idkcct, int iduser)
        {
            try
            {
                var _kc = db.KYCONGs.FirstOrDefault(x => x.IDKCCT == idkcct);

                _kc.DELETED_BY = iduser;
                _kc.DELETED_DATE = DateTime.Now;
                //db.KYCONGs.Remove(_kc);
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public bool KTPhatSinhKC (int idkc)
        {
            var kc = db.KYCONGs.FirstOrDefault(x=>x.IDKCCT == idkc);
            if (kc == null)
            {
                return false;
            } 
            else
            {
                if (kc.TRANGTHAI == true)
                    return true;
                else
                    return false;
            }
                
        }
    }
}
