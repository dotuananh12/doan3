namespace project3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("yeucauShare")]
    public partial class yeucauShare
    {
        [Key]
        public int idYeucauShare { get; set; }

        [Column(TypeName = "text")]
        public string otp { get; set; }

        public int? idUser { get; set; }

        public int? solangui { get; set; }

        public bool? isStatus { get; set; }

        [StringLength(50)]
        public string createDate { get; set; }

        public virtual nguoidung nguoidung { get; set; }
    }
}
