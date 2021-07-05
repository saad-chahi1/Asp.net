namespace PROJET_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("actualite")]
    public partial class actualite
    {

        public int id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string titre { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string description { get; set; }

        [Required]
        [StringLength(255)]
        public string state { get; set; }

        [Required]
        [StringLength(255)]
        public string piece_joint { get; set; }
    }
}
