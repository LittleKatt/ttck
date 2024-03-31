using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.DTO
{
    public class HDLD_DTO
    {
        public string SOHD { get; set; }
        public string NGAYBATDAU { get; set; }
        public string NGAYKETTHUC { get; set; }
        public string NGAYKY { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<int> LANKY { get; set; }
        public string THOIHAN { get; set; }
        public int? LUONGCOBAN {  get; set; }
        public Nullable<double> HESOLUONG { get; set; }
        public Nullable<int> IDNV { get; set; }
        public string HOTEN { get; set; }
        public string NGAYSINH { get; set; }
        public string DIENTHOAI {get; set; }
        public string CCCD { get; set; }
        public string DIACHI { get; set; }
        public Nullable<int> IDPB { get; set; }
        public string TENPB { get; set; }
        public Nullable<int> IDBP { get; set; }
        public string TENBP { get; set; }
        public Nullable<int> IDCV { get; set; }
        public string TENCV { get; set; }
        public Nullable<int> IDTD { get; set; }
        public string TENTD { get; set; }



        public Nullable<int> DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
    }
}
