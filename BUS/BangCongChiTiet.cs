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
    }
}
