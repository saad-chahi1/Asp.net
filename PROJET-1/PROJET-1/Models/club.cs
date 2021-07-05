namespace PROJET_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("club")]
    public partial class club
    {
        public int id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string titre { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_creation { get; set; }

        [Required]
        [StringLength(255)]
        public string logo { get; set; }

        public int id_respo { get; set; }

        public virtual Responsable Responsable { get; set; }
    }
}
