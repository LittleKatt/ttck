using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.DTO;
using DAO;

namespace BUS
{
    public class KhenThuong_KyLuat
    {
        QLNSEntities db = new QLNSEntities();
        public KHENTHUONG_KYLUAT getItem(string soQD)
        {
            return db.KHENTHUONG_KYLUAT.FirstOrDefault(x=>x.SOQD==soQD);
        }

        public List<KHENTHUONG_KYLUAT> getList(int loai)
        {
            return db.KHENTHUONG_KYLUAT.Where(x => x.LOAI == loai).ToList();
        }
        public List<KTKL_DTO> getListFull(int loai)
        {
            List<KHENTHUONG_KYLUAT> lstKT = db.KHENTHUONG_KYLUAT.Where(x => x.LOAI == loai).ToList();
            List<KTKL_DTO> lstDTO = new List<KTKL_DTO>();
            KTKL_DTO kt;
            foreach (var item in lstKT)
            {
                kt = new KTKL_DTO();
                kt.SOQD = item.SOQD;
                kt.TUNGAY = item.TUNGAY;
                kt.DENNGAY = item.DENNGAY;
                kt.NGAYKY = item.NGAYKY.Value;
                kt.LOAI = item.LOAI;
                kt.LYDO = item.LYDO;
                kt.NOIDUNG = item.NOIDUNG;
                kt.IDNV = item.IDNV;
                var nv = db.NHANVIENs.FirstOrDefault(n => n.IDNV == item.IDNV);
                kt.HOTEN = nv.HOTEN;
                kt.CREATED_BY = item.CREATED_BY;
                kt.CREATED_DATE = item.CREATED_DATE;
                kt.UPDATED_BY = item.UPDATED_BY;
                kt.UPDATED_DATE = item.UPDATED_DATE;
                kt.DELETED_BY = item.DELETED_BY;
                kt.DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(kt);
            }
            return lstDTO;
        }

        public KHENTHUONG_KYLUAT Add (KHENTHUONG_KYLUAT kt)
        {
            try
            {
                db.KHENTHUONG_KYLUAT.Add(kt);
                db.SaveChanges();
                return kt;
            }
            catch (Exception ex)
            {

                throw new Exception ("Lỗi " + ex.Message);
            }
        }

        public KHENTHUONG_KYLUAT Update(KHENTHUONG_KYLUAT kt)
        {
            try
            {
                KHENTHUONG_KYLUAT _kt = db.KHENTHUONG_KYLUAT.FirstOrDefault(x=>x.SOQD == kt.SOQD);
                _kt.NGAYKY = kt.NGAYKY;
                _kt.TUNGAY = kt.TUNGAY;
                _kt.DENNGAY = kt.DENNGAY;
                _kt.LYDO = kt.LYDO;
                _kt.NOIDUNG = kt.NOIDUNG;
                _kt.LOAI = kt.LOAI;
                _kt.IDNV = kt.IDNV;
                _kt.UPDATED_BY = kt.UPDATED_BY;
                _kt.UPDATED_DATE = kt.UPDATED_DATE;
                db.SaveChanges();
                return kt;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public void Delete (string soqd, int idnv)
        {
            try
            {
                KHENTHUONG_KYLUAT _kt = db.KHENTHUONG_KYLUAT.FirstOrDefault(x => x.SOQD == soqd);
                db.KHENTHUONG_KYLUAT.Remove(_kt);
                //_kt.DELETED_BY = idnv;
                //_kt.DELETED_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public string MaxSoQuyetDinh(int loai)
        {
            var _kt = db.KHENTHUONG_KYLUAT.Where(x=>x.LOAI == loai).OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if (_kt != null)
            {
                return _kt.SOQD;
            }
            else
            { return "0000"; }
        }
    }
}
