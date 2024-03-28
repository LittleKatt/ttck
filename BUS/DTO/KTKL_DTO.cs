﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.DTO
{
    public class KTKL_DTO
    {
        public string SOQD { get; set; }
        public string LYDO { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<int> IDNV { get; set; }
        public string HOTEN { get; set; }
        public Nullable<int> LOAI { get; set; }
        public Nullable<System.DateTime> TUNGAY { get; set; }
        public Nullable<System.DateTime> DENNGAY { get; set; }
        public Nullable<System.DateTime> NGAYKY { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_DATE { get; set; }
    }
}