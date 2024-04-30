using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.DTO;
using DAO;
namespace BUS
{
    public class LoaiCa
    {
        QLNSEntities db = new QLNSEntities();

        public LOAICA getItem(int idloaica)
        {
            return db.LOAICAs.FirstOrDefault(x => x.IDLCA == idloaica);
        }
        public List<LOAICA> getList()
        {
            return db.LOAICAs.ToList();
        }
        public LOAICA Add(LOAICA lc)
        {
            try
            {
                db.LOAICAs.Add(lc);
                db.SaveChanges();
                return lc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public LOAICA Update(LOAICA lc)
        {
            try
            {
                var _lc = db.LOAICAs.FirstOrDefault(x => x.IDLCA == lc.IDLCA);
                _lc.TENLOAICA = lc.TENLOAICA;
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
        public void Delete(int idloaica, int iduser)
        {
            try
            {
                var _lc = db.LOAICAs.FirstOrDefault(x => x.IDLCA == idloaica);
                db.LOAICAs.Remove(_lc);
                //_lc.DELETED_BY = iduser;
                //_lc.DELETED_DATE = DateTime.Now;
                db.SaveChanges();

            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
