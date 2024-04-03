using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class BangLuong
    {
        QLNSEntities db = new QLNSEntities();

        public BANGLUONG getItem(int idnv, int idkcct)
        {

            return db.BANGLUONGs.FirstOrDefault(x => x.IDKCCT == idkcct && x.IDNV == idnv);
        }
        public BANGLUONG Add(BANGLUONG bl)
        {
            try
            {
                db.BANGLUONGs.Add(bl);
                db.SaveChanges();
                return bl;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public BANGLUONG Update(BANGLUONG bl)
        {
            try
            {
                BANGLUONG _bl = db.BANGLUONGs.FirstOrDefault(x => x.IDKCCT == bl.IDKCCT && x.IDNV == bl.IDNV);
                _bl.IDKCCT = _bl.IDKCCT;
                _bl.IDNV = bl.IDNV;
                _bl.HOTEN = bl.HOTEN;
                _bl.NGAYPHEP = bl.NGAYPHEP;
                _bl.KHONGPHEP = bl.KHONGPHEP;
                _bl.NGAYCONG = bl.NGAYCONG;
                _bl.NGAYCHUNHAT = bl.NGAYCHUNHAT;
                _bl.NGAYLE = bl.NGAYLE;
                _bl.NGAYTHUONG = bl.NGAYTHUONG;
                _bl.TANGCA = bl.TANGCA;
                _bl.PHUCAP = bl.PHUCAP;
                _bl.UNGLUONG = bl.UNGLUONG;
                _bl.THUCLANH = bl.THUCLANH;
                _bl.UPDATED_BY = bl.UPDATED_BY;
                _bl.UPDATED_DATE = bl.UPDATED_DATE;
                db.SaveChanges();
                return bl;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        
    }
}
