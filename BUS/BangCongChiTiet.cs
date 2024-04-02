using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace BUS
{
    public class BangCongChiTiet
    {
        QLNSEntities db = new QLNSEntities();

        public BANGCONGCHITIET getItem(int idnv, int idkcct, int ngay)
        {

            return db.BANGCONGCHITIETs.FirstOrDefault(x => x.IDKCCT == idkcct && x.IDNV == idnv && x.NGAY.Value.Day == ngay);
        }
        public BANGCONGCHITIET Add(BANGCONGCHITIET bcct)
        {
            try
            {
                db.BANGCONGCHITIETs.Add(bcct);
                db.SaveChanges();
                return bcct;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public BANGCONGCHITIET Update(BANGCONGCHITIET bcct)
        {
            try
            {
                BANGCONGCHITIET bcnv = db.BANGCONGCHITIETs.FirstOrDefault( x => x.IDKCCT == bcct.IDKCCT && x.IDNV == bcct.IDNV && x.NGAY == bcct.NGAY);
                bcnv.KYHIEU = bcnv.KYHIEU;
                bcnv.GIOVAO = bcct.GIOVAO;
                bcnv.GIORA = bcct.GIORA;
                bcnv.NGAYPHEP = bcct.NGAYPHEP;
                bcnv.NGAYCONG = bcct.NGAYCONG;
                bcnv.GHICHU = bcct.GHICHU;
                bcnv.CONGCHUNHAT = bcct.CONGCHUNHAT;
                bcnv.CONGNGAYLE = bcct.CONGNGAYLE;
                bcnv.UPDATED_BY = bcct.UPDATED_BY;
                bcnv.UPDATED_DATE = bcct.UPDATED_DATE;
                db.SaveChanges();
                return bcct;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public double tongNgayPhep(int idkcct, int idnv)
        {
            return db.BANGCONGCHITIETs.Where(x => x.IDKCCT == idkcct && x.IDNV == idnv && x.NGAYPHEP != null).Sum(p => p.NGAYPHEP.Value);
        }

        public double tongNgayCong(int idkcct, int idnv)
        {
            return db.BANGCONGCHITIETs.Where(x => x.IDKCCT == idkcct && x.IDNV == idnv && x.NGAYCONG != null).Sum(p => p.NGAYCONG.Value);
        }

    }
}
