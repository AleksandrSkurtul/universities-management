namespace Universities.database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cource()
        {
            StudentCources = new HashSet<StudentCource>();
        }

        public int Id { get; set; }

        public int? UniversityId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public virtual University University { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentCource> StudentCources { get; set; }
    }
}
