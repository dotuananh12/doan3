namespace project3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [Key]
        [StringLength(50)]
        public string idRole { get; set; }

        public int? rolecode { get; set; }

        [StringLength(100)]
        public string NameChucvu { get; set; }
    }
}
