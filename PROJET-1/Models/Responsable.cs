namespace PROJET_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Responsable")]
    public partial class Responsable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Responsable()
        {
            activites = new HashSet<Activite>();
            clubs = new HashSet<club>();
        }

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

        public int password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activite> activites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<club> clubs { get; set; }
    }
}
