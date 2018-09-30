namespace Universities.database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentCources
    {
        public int? CourseId { get; set; }

        public int? StudentId { get; set; }

        public int Id { get; set; }

        public virtual Cources Cources { get; set; }

        public virtual Students Students { get; set; }
    }
}
