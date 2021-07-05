namespace PROJET_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("gallerie")]
    public partial class gallerie
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        [Required]
        [StringLength(255)]
        public string path { get; set; }

        [Required]
        [StringLength(255)]
        public string type { get; set; }

        public int id_activite { get; set; }

        public virtual Activite activite { get; set; }
    }
}
