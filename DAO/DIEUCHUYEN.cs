//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class DIEUCHUYEN
    {
        public string SOQD { get; set; }
        public Nullable<System.DateTime> NGAYKY { get; set; }
        public Nullable<int> IDNV { get; set; }
        public Nullable<int> IDPB { get; set; }
        public Nullable<int> IDPB2 { get; set; }
        public Nullable<int> IDBP { get; set; }
        public Nullable<int> IDBP2 { get; set; }
        public Nullable<int> IDCV { get; set; }
        public Nullable<int> IDCV2 { get; set; }
        public string LYDO { get; set; }
        public string GHICHU { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETE_DATE { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
