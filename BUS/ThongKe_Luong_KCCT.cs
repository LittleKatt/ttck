using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ThongKe_Luong_KCCT
    {
        QLNSEntities db = new QLNSEntities();
        public List<THONGKE_LUONG_Result> ThongKeLuongTheoKCCT (int idkcct)
        {
            return db.THONGKE_LUONG(idkcct).ToList();
        }

    }
}
