using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TonGiao
    {
        QLNSEntities db = new QLNSEntities();


        public TONGIAO getItem(int id)
        {
            return db.TONGIAOs.FirstOrDefault(x => x.ID == id);
        }
        public List<TONGIAO> getList()
        {
            return db.TONGIAOs.ToList();
        }

        public TONGIAO Add(TONGIAO tg)
        {
            try
            {
                db.TONGIAOs.Add(tg);
                db.SaveChanges();
                return tg;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public TONGIAO Update(TONGIAO tg)
        {
            try
            {
                var _tg = db.TONGIAOs.FirstOrDefault(x => x.ID == tg.ID);
                _tg.TENTG = tg.TENTG;
                db.SaveChanges();
                return tg;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var _tg = db.TONGIAOs.FirstOrDefault(x => x.ID == id);
                db.TONGIAOs.Remove(_tg);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
