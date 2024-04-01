using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiCong
    {
        QLNSEntities db = new QLNSEntities();

        public LOAICONG getItem(int id)
        {
            return db.LOAICONGs.FirstOrDefault(x => x.IDLC == id);
        }
        public List<LOAICONG> getList()
        {
            return db.LOAICONGs.ToList();
        }
        public LOAICONG Add(LOAICONG lc)
        {
            try
            {
                db.LOAICONGs.Add(lc);
                db.SaveChanges();
                return lc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public LOAICONG Update(LOAICONG lc)
        {
            try
            {
                var _lc = db.LOAICONGs.FirstOrDefault(x => x.IDLC == lc.IDLC);
                _lc.TENLC = lc.TENLC;
                _lc.HESO = lc.HESO;
                _lc.UPDATED_BY = lc.UPDATED_BY;
                _lc.UPDATED_DATE = lc.UPDATED_DATE;

                db.SaveChanges();
                return lc;
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
                var _lc = db.LOAICONGs.FirstOrDefault(x => x.IDLC == id);
                _lc.DELETED_BY = iduser;
                _lc.DELETED_DATE = DateTime.Now;
                db.SaveChanges();

            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
