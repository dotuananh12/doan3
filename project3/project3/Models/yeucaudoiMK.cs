namespace project3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("yeucaudoiMK")]
    public partial class yeucaudoiMK
    {
        public int id { get; set; }

        [Column(TypeName = "text")]
        public string OTP { get; set; }

        [StringLength(255)]
        public string useCode { get; set; }

        [StringLength(50)]
        public string createDate { get; set; }

        public bool? isStatus { get; set; }
    }
}
