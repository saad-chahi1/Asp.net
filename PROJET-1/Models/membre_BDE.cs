namespace PROJET_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class membre_BDE
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string nom { get; set; }

        [Required]
        [StringLength(255)]
        public string prenom { get; set; }

        [Required]
        [StringLength(255)]
        public string role { get; set; }

        [Required]
        [StringLength(255)]
        public string picture { get; set; }

        public int? bde_id { get; set; }

        public virtual BDE BDE { get; set; }
    }
}
