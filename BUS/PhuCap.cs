using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.DTO;
using DAO;

namespace BUS
{
    public class PhuCap
    {
        QLNSEntities db = new QLNSEntities();

        public PHUCAP getItem(int id)
        {

            return db.PHUCAPs.FirstOrDefault(x => x.ID == id);
            
        }
        public List<PhuCap_DTO> getListFull()
        {
            var lstNVPC =db.PHUCAPs.ToList();
            List<PhuCap_DTO> lstDTO = new List<PhuCap_DTO>();
            PhuCap_DTO nvpc;
            NhanVien _nhanvien = new NhanVien();
            foreach (var item in lstNVPC)
            {
                nvpc = new PhuCap_DTO();
                nvpc.ID = item.ID;
                nvpc.IDNV = item.IDNV;
                var nv = _nhanvien.getItemFull(int.Parse(item.IDNV.ToString()));
                nvpc.HOTEN = nv.HOTEN;
                nvpc.TENCV = nv.TENCV;
                nvpc.IDPC = item.IDPC;
                var pc = db.LOAIPHUCAPs.FirstOrDefault(x => x.IDPC == item.IDPC);
                nvpc.TENPC = pc.TENPC;
                nvpc.NOIDUNG = item.NOIDUNG;
                nvpc.NGAY = item.NGAY;
                nvpc.SOTIEN = item.SOTIEN;
                nvpc.CREATED_BY = item.CREATED_BY;
                nvpc.CREATED_DATE = item.CREATED_DATE;
                nvpc.UPDATED_BY = item.UPDATED_BY;
                nvpc.UPDATED_DATE = item.UPDATED_DATE;
                nvpc.DELETED_BY = item.DELETED_BY;
                nvpc.DELETED_DATE = item.DELETED_DATE;
                lstDTO.Add(nvpc);
            }  
            return lstDTO;
        }

        public LOAIPHUCAP getItemPC(int id)
        {
            return db.LOAIPHUCAPs.FirstOrDefault(x => x.IDPC == id);
        }
        public List<LOAIPHUCAP> getListPC()
        {
            return db.LOAIPHUCAPs.ToList();
        }
        public PHUCAP Add(PHUCAP pc)
        {
            try
            {
                db.PHUCAPs.Add(pc);
                db.SaveChanges();
                return pc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public PHUCAP Update(PHUCAP pc)
        {
            try
            {
                var _pc = db.PHUCAPs.FirstOrDefault(x => x.ID == pc.ID);
                _pc.IDPC = pc.IDPC;
                _pc.IDNV = pc.IDNV;
                _pc.NGAY = pc.NGAY;
                _pc.NOIDUNG = pc.NOIDUNG;
                _pc.SOTIEN = pc.SOTIEN;
                _pc.UPDATED_BY = pc.UPDATED_BY;
                _pc.UPDATED_DATE = pc.UPDATED_DATE;

                db.SaveChanges();
                return pc;
            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(int id, int iduser)
        {
            try
            {
                var _pc = db.PHUCAPs.FirstOrDefault(x => x.ID == id);
                _pc.DELETED_BY = iduser;
                _pc.DELETED_DATE = DateTime.Now;
                db.SaveChanges();

            }

            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
