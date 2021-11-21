namespace project3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nguoidung")]
    public partial class nguoidung
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public nguoidung()
        //{
        //    yeucauShares = new HashSet<yeucauShare>();
        //}

        [Key]
        public int idUser { get; set; }

        [StringLength(255)]
        public string code { get; set; }

        public int? idRole { get; set; }

        [StringLength(100)]
        public string fullname { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        [StringLength(50)]
        public string phonenumber { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        public int? gioitinh { get; set; }

        [StringLength(100)]
        public string quoctich { get; set; }

        [StringLength(50)]
        public string visa { get; set; }

        [StringLength(50)]
        public string ngaycap { get; set; }

        [StringLength(50)]
        public string hansudung { get; set; }

        public int? idHoso { get; set; }

        public virtual HoSo HoSo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yeucauShare> yeucauShares { get; set; }
    }
}
