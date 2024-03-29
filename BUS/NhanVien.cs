using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.DTO;
using DAO;

namespace BUS
{
    public class NhanVien
    {
        QLNSEntities db = new QLNSEntities();

        public NHANVIEN getItem(int id)
        {
            return db.NHANVIENs.FirstOrDefault(x => x.IDNV == id);
        }
        public List<NHANVIEN> getList()
        {
            return db.NHANVIENs.ToList();
        }

        public List<NhanVien_DTO> getListFull()
        {
            var lstNV = db.NHANVIENs.ToList();
            List<NhanVien_DTO> lstNVDTO = new List<NhanVien_DTO>();
            NhanVien_DTO nvDTO;
            foreach (var item in lstNV)
            {
                nvDTO = new NhanVien_DTO();
                nvDTO.IDNV = item.IDNV;
                nvDTO.HOTEN = item.HOTEN;
                nvDTO.GIOITINH = item.GIOITINH;
                nvDTO.NGAYSINH = item.NGAYSINH;
                nvDTO.DIENTHOAI = item.DIENTHOAI;
                nvDTO.CCCD = item.CCCD;
                nvDTO.DIACHI = item.DIACHI;
                nvDTO.HINHANH = item.HINHANH;
                nvDTO.THOIVIEC = item.DATHOIVIEC;

                nvDTO.IDPB = item.IDPB;
                var pb = db.PHONGBANs.FirstOrDefault(p=>p.IDPB == item.IDPB);
                nvDTO.TENPB = pb.TENPB;

                nvDTO.IDBP = item.IDBP;
                var bp = db.BOPHANs.FirstOrDefault(b => b.IDBP == item.IDBP);
                nvDTO.TENBP = bp.TENBP;

                nvDTO.IDCV = item.IDCV;
                var cv = db.CHUCVUs.FirstOrDefault(c => c.IDCV == item.IDCV);
                nvDTO.TENCV = cv.TENCV;

                nvDTO.IDTD = item.IDTD;
                var td = db.TRINHDOes.FirstOrDefault(t => t.IDTD == item.IDTD);
                nvDTO.TENTD = td.TENTD;

                nvDTO.IDDT = item.IDDT;
                var dt = db.DANTOCs.FirstOrDefault(d => d.ID == item.IDDT);
                nvDTO.TENDT = dt.TENDT;

                nvDTO.IDTG = item.IDTG;
                var tg = db.TONGIAOs.FirstOrDefault(g => g.ID == item.IDTG);
                nvDTO.TENTG = tg.TENTG;

                lstNVDTO.Add(nvDTO);
            }    
            return lstNVDTO;
        }

        public NHANVIEN Add(NHANVIEN nv)
        {
            try
            {
                db.NHANVIENs.Add(nv);
                db.SaveChanges();
                return nv;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public NHANVIEN Update(NHANVIEN nv)
        {
            try
            {
                var _nv = db.NHANVIENs.FirstOrDefault(x => x.IDNV == nv.IDNV);
                _nv.HOTEN = nv.HOTEN;
                _nv.NGAYSINH = nv.NGAYSINH;
                _nv.GIOITINH = nv.GIOITINH;
                _nv.DIENTHOAI = nv.DIENTHOAI;
                _nv.CCCD = nv.CCCD;
                _nv.DIACHI = nv.DIACHI;
                _nv.HINHANH = nv.HINHANH;
                _nv.DATHOIVIEC = nv.DATHOIVIEC;
                _nv.IDPB = nv.IDPB;
                _nv.IDBP = nv.IDBP;
                _nv.IDCV = nv.IDCV;
                _nv.IDTD = nv.IDTD;
                _nv.IDDT = nv.IDDT;
                _nv.IDTG = nv.IDTG;

                db.SaveChanges();
                return nv;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var _nv = db.NHANVIENs.FirstOrDefault(x => x.IDNV == id);
                db.NHANVIENs.Remove(_nv);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}
