using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class DieuChuyen
    {
        QLNSEntities db = new QLNSEntities();
        public DIEUCHUYEN getItem(string soqd)
        {
            return db.DIEUCHUYENs.FirstOrDefault(x => x.SOQD == soqd);
        }

        public List<DIEUCHUYEN> getList()
        {
            return db.DIEUCHUYENs.ToList();
        }

        public DIEUCHUYEN Add(DIEUCHUYEN dc)
        {
            try
            {
                db.DIEUCHUYENs.Add(dc);
                db.SaveChanges();
                return dc;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public DIEUCHUYEN Update(DIEUCHUYEN dc)
        {
            try
            {
                var _dc = db.DIEUCHUYENs.FirstOrDefault(x => x.SOQD == dc.SOQD);
                _dc.IDBP2 = dc.IDBP2;
                _dc.IDPB2 = dc.IDPB2;
                _dc.IDCV2 = dc.IDCV2;
                _dc.NGAYKY = dc.NGAYKY;
                _dc.LYDO = dc.LYDO;
                _dc.GHICHU = dc.GHICHU;
                _dc.UPDATED_BY = dc.UPDATED_BY;
                _dc.UPDATED_DATE = dc.UPDATED_DATE;
                db.SaveChanges();
                return dc;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public void Delete (string soqd, int iduser)
        {
            try
            {
                var _dc = db.DIEUCHUYENs.FirstOrDefault(x => x.SOQD == soqd);
                _dc.DELETED_BY = iduser;
                _dc.DELETE_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi " + ex.Message);
            }
        }
    }
}
