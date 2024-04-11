using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Users
    {
        QLNSEntities db; 
        public Users()
        {
            db = new QLNSEntities();
        }
        public int Login(string username, string password)
        {
            var us = db.USERs.FirstOrDefault(x => x.TAIKHOAN == username && x.MATKHAU == password);
            if (us != null)
                return 1;
            else
                return 0;
        }
 
    }
}
