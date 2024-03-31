using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.DTO;
using DAO;
namespace BUS
{
    public class LoaiCa
    {
        QLNSEntities db = new QLNSEntities();

        public LOAICA getItem(int idloaica)
        {
            return db.LOAICAs.FirstOrDefault(x => x.IDLCA == idloaica);
        }
        public List<LOAICA> getList()
        {
            return db.LOAICAs.ToList();
        }
        //public List<NhanVien_NangLuong_DTO> getListFull()
        //{
        //    var lstDC = db.NHANVIEN_NANGLUONG.ToList();
        //    List<NhanVien_NangLuong_DTO> lstDTO = new List<NhanVien_NangLuong_DTO>();
        //    NhanVien_NangLuong_DTO nlDTO;
        //    foreach (var item in lstDC)
        //    {
        //        nlDTO = new NhanVien_NangLuong_DTO();
        //        nlDTO.SOQD = item.SOQD;
        //        nlDTO.HESOLUONGHIENTAI = item.HESOLUONGHIENTAI;
        //        nlDTO.HESOLUONGMOI = item.HESOLUONGMOI;

        //        nlDTO.IDNV = item.IDNV;
        //        var nv = db.NHANVIENs.FirstOrDefault(x => x.IDNV == item.IDNV);
        //        nlDTO.HOTEN = nv.HOTEN;
        //        nlDTO.GHICHU = item.GHICHU;
        //        nlDTO.NGAYKY = item.NGAYKY;
        //        nlDTO.NGAYLENLUONG = item.NGAYLENLUONG;
        //        nlDTO.CREATED_BY = item.CREATED_BY;
        //        nlDTO.CREATED_DATE = item.CREATED_DATE;
        //        nlDTO.UPDATED_BY = item.UPDATED_BY;
        //        nlDTO.UPDATED_DATE = item.UPDATED_DATE;
        //        nlDTO.DELETED_BY = item.DELETED_BY;
        //        nlDTO.DELETED_DATE = item.DELETED_DATE;
        //        lstDTO.Add(nlDTO);
        //    }
        //    return lstDTO;
        //}
        public LOAICA Add(LOAICA lc)
        {
            try
            {
                db.LOAICAs.Add(lc);
                db.SaveChanges();
                return lc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public LOAICA Update(LOAICA lc)
        {
            try
            {
                var _lc = db.LOAICAs.FirstOrDefault(x => x.IDLCA == lc.IDLCA);
                _lc.TENLOAICA = lc.TENLOAICA;
                _lc.HESO = lc.HESO;
                _lc.UPDATED_BY = lc.UPDATED_BY;
                _lc.UPDATED_DATE = lc.UPDATED_DATE;
                
                db.SaveChanges();
                return lc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(int idloaica, int iduser)
        {
            try
            {
                var _lc = db.LOAICAs.FirstOrDefault(x => x.IDLCA == idloaica);
                _lc.DELETED_BY = iduser;
                _lc.DELETED_DATE = DateTime.Now;
                db.SaveChanges();

            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
