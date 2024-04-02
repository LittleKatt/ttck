using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.DTO;
using DAO;
namespace BUS
{
    public class UngLuong
    {
        QLNSEntities db = new QLNSEntities();

        public UNGLUONG getItem(int id)
        {
            return db.UNGLUONGs.FirstOrDefault(x => x.IDUL == id);
        }
       
        public List<UngLuong_DTO> getListFull()
        {
            var lstUngLuong = db.UNGLUONGs.ToList();
            List<UngLuong_DTO> lstDTO = new List<UngLuong_DTO>();
            UngLuong_DTO dto;

            foreach (var item in lstUngLuong)
            {
                dto = new UngLuong_DTO();
                dto.IDUL = item.IDUL;
                dto.NAM = item.NAM;
                dto.THANG = item.THANG;
                dto.NGAY = item.NGAY;
               
                dto.IDNV = item.IDNV;

                var nv = db.NHANVIENs.FirstOrDefault(x => x.IDNV == item.IDNV);
                dto.HOTEN = nv.HOTEN;
                dto.SOTIEN = item.SOTIEN; 
                dto.GHICHU = item.GHICHU;
               
                dto.CREATED_BY = item.CREATED_BY;
                dto.CREATED_DATE = item.CREATED_DATE;
                dto.UPDATED_BY = item.UPDATED_BY;
                dto.UPDATED_DATE = item.UPDATED_DATE;
                dto.DELETED_BY = item.DELETED_BY;
                dto.DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(dto);
            }
            return lstDTO;
        }
        public UNGLUONG Add(UNGLUONG ul)
        {
            try
            {
                db.UNGLUONGs.Add(ul);
                db.SaveChanges();
                return ul;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public UNGLUONG Update(UNGLUONG ul)
        {
            try
            {
                var _ul = db.UNGLUONGs.FirstOrDefault(n=>n.IDNV == ul.IDNV);              
                
                _ul.NAM = ul.NAM;
                _ul.THANG = ul.THANG;
                _ul.NGAY = ul.NGAY;

                _ul.IDNV = ul.IDNV;
                _ul.SOTIEN = ul.SOTIEN;
                _ul.GHICHU = ul.GHICHU;

                
                _ul.UPDATED_BY = ul.UPDATED_BY;
                _ul.UPDATED_DATE = ul.UPDATED_DATE;
                
                
                db.SaveChanges();
                return ul;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete (int id, int UserID)
        {
            try
            {
                var _ul = db.UNGLUONGs.FirstOrDefault(n => n.IDUL == id);
                _ul.DELETED_BY = UserID;
                _ul.DELETED_DATE = DateTime.Now;
                db.SaveChanges();

            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
