using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.DTO;
using DAO;

namespace BUS
{
    public class DieuChuyen
    {
        QLNSEntities db = new QLNSEntities();
        public DIEUCHUYEN getItem(string soqd)
        {
            return db.DIEUCHUYENs.FirstOrDefault(x => x.SOQD == soqd);
        }

        public List<DIEUCHUYEN> getList()
        {
            return db.DIEUCHUYENs.ToList();
        }

        public List<DieuChuyen_DTO> getListFull()
        {
            var lstDC = db.DIEUCHUYENs.ToList();
            List<DieuChuyen_DTO> lstDTO = new List<DieuChuyen_DTO>();
            DieuChuyen_DTO dcDTO;
            foreach (var item in lstDC)
            {
                dcDTO = new DieuChuyen_DTO();
                dcDTO.SOQD = item.SOQD;
                dcDTO.NGAYKY = item.NGAYKY;
                dcDTO.LYDO = item.LYDO;
                dcDTO.GHICHU = item.GHICHU;
                dcDTO.IDNV = item.IDNV;
                var nv = db.NHANVIENs.FirstOrDefault(n => n.IDNV == item.IDNV);
                dcDTO.HOTEN = nv.HOTEN;
                dcDTO.IDPB = item.IDPB;
                var pb = db.PHONGBANs.FirstOrDefault(p => p.IDPB == item.IDPB);
                dcDTO.TENPB = pb.TENPB;
                dcDTO.IDPB2 = item.IDPB2;
                var pb2 = db.PHONGBANs.FirstOrDefault(p2 => p2.IDPB == item.IDPB2);
                dcDTO.TENPB2 = pb2.TENPB;
                dcDTO.IDBP = item.IDBP;
                var bp = db.BOPHANs.FirstOrDefault(p => p.IDBP == item.IDBP);
                dcDTO.TENBP = bp.TENBP;
                dcDTO.IDBP2 = item.IDBP2;
                var bp2 = db.BOPHANs.FirstOrDefault(p2 => p2.IDBP == item.IDBP2);
                dcDTO.TENBP2 = bp2.TENBP;
                dcDTO.IDCV = item.IDCV;
                var cv = db.CHUCVUs.FirstOrDefault(p => p.IDCV == item.IDCV);
                dcDTO.TENCV = cv.TENCV;
                dcDTO.IDCV = item.IDCV;
                var cv2 = db.CHUCVUs.FirstOrDefault(p2 => p2.IDCV == item.IDCV2);
                dcDTO.TENCV2 = cv2.TENCV;
                dcDTO.CREATED_BY = item.CREATED_BY;
                dcDTO.CREATED_DATE = item.CREATED_DATE;
                dcDTO.UPDATED_BY = item.UPDATED_BY;
                dcDTO.UPDATED_DATE = item.UPDATED_DATE;
                dcDTO.DELETED_BY = item.DELETED_BY;
                dcDTO.DELETE_DATE = item.DELETE_DATE;
                lstDTO.Add(dcDTO);
            }
            return lstDTO;
        }

        public DIEUCHUYEN Add(DIEUCHUYEN dc)
        {
            try
            {
                db.DIEUCHUYENs.Add(dc);
                db.SaveChanges();
                return dc;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public DIEUCHUYEN Update(DIEUCHUYEN dc)
        {
            try
            {
                var _dc = db.DIEUCHUYENs.FirstOrDefault(x => x.SOQD == dc.SOQD);
                _dc.IDBP2 = dc.IDBP2;
                _dc.IDPB2 = dc.IDPB2;
                _dc.IDCV2 = dc.IDCV2;
                _dc.IDNV = dc.IDNV;
                _dc.NGAYKY = dc.NGAYKY;
                _dc.LYDO = dc.LYDO;
                _dc.GHICHU = dc.GHICHU;
                _dc.UPDATED_BY = dc.UPDATED_BY;
                _dc.UPDATED_DATE = dc.UPDATED_DATE;
                db.SaveChanges();
                return dc;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public void Delete (string soqd, int iduser)
        {
            try
            {
                var _dc = db.DIEUCHUYENs.FirstOrDefault(x => x.SOQD == soqd);
                _dc.DELETED_BY = iduser;
                _dc.DELETE_DATE = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi " + ex.Message);
            }
        }

        public string MaxSoQuyetDinh()
        {
            var _dc = db.DIEUCHUYENs.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
            if (_dc != null)
            {
                return _dc.SOQD;
            }
            else
            { return "0000"; }
        }
    }
}
