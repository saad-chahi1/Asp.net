namespace PROJET_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("activite")]
    public partial class Activite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activite()
        {
            galleries = new HashSet<gallerie>();
        }

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

        public int? responsable { get; set; }

        [Required]
        [StringLength(255)]
        public string piece_joint { get; set; }

        public int? BDE { get; set; }

        public virtual BDE BDE1 { get; set; }

        public virtual Responsable Responsable1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<gallerie> galleries { get; set; }
    }
}
