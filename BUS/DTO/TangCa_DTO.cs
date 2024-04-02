using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.DTO
{
    public class TangCa_DTO
    {
        public int IDTC { get; set; }
        public Nullable<int> NAM { get; set; }
        public Nullable<int> THANG { get; set; }
        public Nullable<int> NGAY { get; set; }
        public Nullable<double> SOGIO { get; set; }
        public Nullable<int> IDNV { get; set; }

        public string HOTEN { get; set; }
        public Nullable<int> IDLCA { get; set; }

        public string TENLOAICA { get; set; }

        public double? SOTIEN { get; set; }
        public double? HESO {  get; set; }
        public string GHICHU { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_DATE { get; set; }

        public virtual LOAICA LOAICA { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
