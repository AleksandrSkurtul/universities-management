namespace Universities.database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentCource
    {
        public int? CourseId { get; set; }

        public int? StudentId { get; set; }

        public int Id { get; set; }

        public virtual Cource Cource { get; set; }

        public virtual Student Student { get; set; }
    }
}
