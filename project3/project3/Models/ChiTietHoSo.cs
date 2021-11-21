namespace project3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoSo")]
    public partial class ChiTietHoSo
    {
        [Key]
        public int idChiTietHoSo { get; set; }

        public int? idHoSo { get; set; }

        public string chandoanCovid { get; set; }

        public string ketluan { get; set; }

        public string Ghichu { get; set; }

        [StringLength(100)]
        public string TenNoiNhapCanh { get; set; }

        [StringLength(50)]
        public string createdate { get; set; }

        [StringLength(100)]
        public string updateby { get; set; }

        [StringLength(50)]
        public string updateDate { get; set; }

        [StringLength(50)]
        public string createBy { get; set; }
    }
}
