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
    
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.BANGCHAMCONGs = new HashSet<BANGCHAMCONG>();
            this.BAOHIEMs = new HashSet<BAOHIEM>();
            this.HOPDONGs = new HashSet<HOPDONG>();
            this.KHENTHUONG_KYLUAT = new HashSet<KHENTHUONG_KYLUAT>();
            this.NHANVIEN_PHUCAP = new HashSet<NHANVIEN_PHUCAP>();
            this.TANGCAs = new HashSet<TANGCA>();
            this.UNGLUONGs = new HashSet<UNGLUONG>();
        }
    
        public int IDNV { get; set; }
        public string HOTEN { get; set; }
        public Nullable<bool> GIOITINH { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public string DIENTHOAI { get; set; }
        public string CCCD { get; set; }
        public string DIACHI { get; set; }
        public byte[] HINHANH { get; set; }
        public Nullable<int> IDPB { get; set; }
        public Nullable<int> IDBP { get; set; }
        public Nullable<int> IDCV { get; set; }
        public Nullable<int> IDTD { get; set; }
        public Nullable<int> IDDT { get; set; }
        public Nullable<int> IDTG { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANGCHAMCONG> BANGCHAMCONGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOHIEM> BAOHIEMs { get; set; }
        public virtual BOPHAN BOPHAN { get; set; }
        public virtual CHUCVU CHUCVU { get; set; }
        public virtual DANTOC DANTOC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHENTHUONG_KYLUAT> KHENTHUONG_KYLUAT { get; set; }
        public virtual PHONGBAN PHONGBAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN_PHUCAP> NHANVIEN_PHUCAP { get; set; }
        public virtual TonGiao TONGIAO { get; set; }
        public virtual TRINHDO TRINHDO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TANGCA> TANGCAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UNGLUONG> UNGLUONGs { get; set; }
    }
}
