using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Sys_Config
    {

        QLNSEntities db = new QLNSEntities();
       public CONFIG getItem(string name)
        {
            return db.CONFIGs.FirstOrDefault(x=>x.Name == name);
        }
    }
}
