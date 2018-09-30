namespace Universities.database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cources
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cources()
        {
            StudentCources = new HashSet<StudentCources>();
        }

        public int Id { get; set; }

        public int? UniversityId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public virtual Universities Universities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentCources> StudentCources { get; set; }
    }
}
