namespace project3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FileHoSo")]
    public partial class FileHoSo
    {
        [Key]
        public int idFileHoSo { get; set; }

        public int? idChiTietHoSo { get; set; }

        [StringLength(100)]
        public string filename { get; set; }

        [Column(TypeName = "text")]
        public string filelink { get; set; }

        [StringLength(100)]
        public string createBy { get; set; }

        [StringLength(50)]
        public string createDate { get; set; }
    }
}
