namespace project3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("shareFile")]
    public partial class shareFile
    {
        [Key]
        public int idSharefile { get; set; }

        [StringLength(255)]
        public string codeShare { get; set; }

        [StringLength(255)]
        public string codeTake { get; set; }

        public int? hosoID { get; set; }

        [Column(TypeName = "text")]
        public string noidung { get; set; }

        public int? idUser { get; set; }

        [StringLength(255)]
        public string creatBy { get; set; }

        [StringLength(50)]
        public string CreateDate { get; set; }

        [StringLength(255)]
        public string updateBy { get; set; }

        [StringLength(50)]
        public string updateDate { get; set; }

        public virtual HoSo HoSo { get; set; }
    }
}
