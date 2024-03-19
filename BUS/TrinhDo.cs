using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;


namespace BUS
{
    public class TrinhDo
    {
        QLNSEntities db = new QLNSEntities();
        public List<TRINHDO> getList()
        {
            return db.TRINHDOes.ToList();
            
        }
    }
}
