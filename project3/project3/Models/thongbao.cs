namespace project3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("thongbao")]
    public partial class thongbao
    {
        public int id { get; set; }

        [StringLength(255)]
        public string tieude { get; set; }

        [Column(TypeName = "text")]
        public string noidung { get; set; }

        public bool? isSeen { get; set; }

        [StringLength(50)]
        public string createDate { get; set; }

        [StringLength(255)]
        public string usecode { get; set; }
    }
}
