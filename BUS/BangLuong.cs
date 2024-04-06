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

        public BANGLUONG getItem(int idkcct ,int idnv )
        {

            return db.BANGLUONGs.FirstOrDefault(x => x.IDKCCT == idkcct && x.IDNV == idnv);
        }
        public List<BANGLUONG> getList(int idkcct)
        {
            return db.BANGLUONGs.Where(x=> x.IDKCCT==idkcct).ToList();
        }
        public void TinhLuongNhanVien (int idkcct)
        {
            double luongngaythuong, luongphep, luongtangca, luongchunhat, luongngayle, phucap, ungluong, thuclanh, hesoluong;
            var lstNV = db.NHANVIENs.Where(x=> x.DATHOIVIEC == null ).ToList();
            foreach (var item in lstNV)
            {
                var hd = db.HOPDONGs.FirstOrDefault(x => x.IDNV == item.IDNV && x.DELETED_BY == null);
                if (hd != null)
                {
                    var kcct = db.KYCONGCHITIETs.FirstOrDefault(x => x.IDKCCT == idkcct && x.IDNV == item.IDNV);
                    var nangluong = db.NANGLUONGs.OrderByDescending(x => x.NGAYKY).FirstOrDefault(x => x.SOHD == hd.SOHD && x.IDNV == item.IDNV && x.DELETED_BY == null);
                    if (nangluong != null)
                        hesoluong = Convert.ToDouble(nangluong.HESOLUONGMOI);
                    else
                        hesoluong = Convert.ToDouble(hd.HESOLUONG);

                    //Luong trên ngày
                    var luongmotngaycong = hd.LUONGCOBAN * hesoluong / kcct.NGAYCONG;

                    //Tính lương ngày thường 
                    luongngaythuong = Convert.ToDouble(kcct.TONGNGAYCONG * luongmotngaycong);
                    luongphep = Convert.ToDouble(kcct.NGAYPHEP * luongmotngaycong*0.3);
                    luongchunhat = Convert.ToDouble(kcct.CONGCHUNHAT * luongmotngaycong * 2);
                    luongngayle = Convert.ToDouble(kcct.CONGNGAYLE * luongmotngaycong * 3);
                    luongtangca = Convert.ToDouble(db.TANGCAs.Where(x => x.IDNV == item.IDNV && (x.NAM * 100 + x.THANG) == idkcct).Sum(x => x.SOTIEN));
                    phucap = Convert.ToDouble(db.PHUCAPs.Where(x => x.IDNV == item.IDNV).Sum(x => x.SOTIEN));
                    ungluong = Convert.ToDouble(db.UNGLUONGs.Where(x => x.IDNV == item.IDNV && (x.NAM*100 + x.THANG) == idkcct).Sum(x => x.SOTIEN));
                    
                    //Thực lãnh
                    thuclanh = luongngaythuong + luongphep + luongngayle + luongchunhat + luongtangca + phucap - ungluong;

                    BANGLUONG bl = new BANGLUONG();
                    bl.IDKCCT = idkcct;
                    bl.IDNV = item.IDNV;
                    bl.HOTEN = item.HOTEN;
                    bl.NGAYCONG = int.Parse(kcct.NGAYCONG.ToString());
                    bl.NGAYPHEP = luongphep;
                    bl.NGAYCHUNHAT = luongchunhat;
                    bl.NGAYLE = luongngayle;
                    bl.NGAYTHUONG = luongngaythuong;

                    bl.PHUCAP = phucap;
                    bl.TANGCA = luongtangca;                 
                    
                    bl.UNGLUONG = ungluong;
                    bl.THUCLANH = thuclanh;
                    bl.CREATED_BY = 1;
                    bl.CREATED_DATE = DateTime.Now;
                    Add(bl);
                }
                


            }
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
        public bool KTTinhLuong(int idkc)
        {
            var bl = db.BANGLUONGs.FirstOrDefault(x => x.IDKCCT == idkc);
            if (bl == null)
            {
                return false;
            }
            else
            {
                if (bl.IDKCCT == idkc)
                    return true;
                else
                    return false; 
            
            }

        }


    }
}
