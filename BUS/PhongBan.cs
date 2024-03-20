using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class PhongBan
    {
        QLNSEntities db = new QLNSEntities();

        public PHONGBAN getItem(int id)
        {
            return db.PHONGBANs.FirstOrDefault(x => x.IDPB == id);
        }
        public List<PHONGBAN> getList()
        {
            return db.PHONGBANs.ToList();
        }

        public PHONGBAN Add(PHONGBAN pb)
        {
            try
            {
                db.PHONGBANs.Add(pb);
                db.SaveChanges();
                return pb;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public PHONGBAN Update(PHONGBAN pb)
        {
            try
            {
                var _pb = db.PHONGBANs.FirstOrDefault(x => x.IDPB == pb.IDPB);
                _pb.TENPB = pb.TENPB;
                db.SaveChanges();
                return pb;
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
                var _pb = db.PHONGBANs.FirstOrDefault(x => x.IDPB == id);
                db.PHONGBANs.Remove(_pb);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
