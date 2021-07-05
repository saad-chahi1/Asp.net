namespace PROJET_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("laureat")]
    public partial class laureat
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
        public string email { get; set; }

       

        [Required]
        [StringLength(255)]
        public string societe_actuelle { get; set; }

        public float salaire { get; set; }

        public int filiere { get; set; }

        public int age { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string bio { get; set; }

       
        public virtual filiere filiere1 { get; set; }
    }
}
