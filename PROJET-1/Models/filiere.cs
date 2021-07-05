namespace PROJET_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("filiere")]
    public partial class filiere
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public filiere()
        {
            laureats = new HashSet<laureat>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string nom { get; set; }

        [Required]
        [StringLength(255)]
        public string departement { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<laureat> laureats { get; set; }
    }
}
