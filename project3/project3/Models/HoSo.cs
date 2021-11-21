namespace project3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoSo")]
    public partial class HoSo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoSo()
        {
            nguoidungs = new HashSet<nguoidung>();
            shareFiles = new HashSet<shareFile>();
        }

        [Key]
        public int idHoso { get; set; }

        [StringLength(50)]
        public string ngayNhapCanh { get; set; }

        [StringLength(100)]
        public string fullname { get; set; }

        [StringLength(50)]
        public string visa { get; set; }

        [StringLength(50)]
        public string chuyenbay { get; set; }

        [StringLength(100)]
        public string nhanxet { get; set; }

        public bool? isdelete { get; set; }

        [StringLength(50)]
        public string createdate { get; set; }

        [StringLength(50)]
        public string code { get; set; }

        public int? idadmincp { get; set; }

        public virtual AdminCP AdminCP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoidung> nguoidungs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<shareFile> shareFiles { get; set; }
    }
}
