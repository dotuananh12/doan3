namespace project3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminCP")]
    public partial class AdminCP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdminCP()
        {
            HoSoes = new HashSet<HoSo>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string code { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(100)]
        public string fullname { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        [StringLength(50)]
        public string role { get; set; }

        [StringLength(50)]
        public string sdt { get; set; }

        [StringLength(50)]
        public string ngaysinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoSo> HoSoes { get; set; }
    }
}
