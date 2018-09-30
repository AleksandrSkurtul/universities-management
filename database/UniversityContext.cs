namespace Universities.database
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class UniversityContext : DbContext
	{
		public UniversityContext()
			: base("name=UniversityContext1")
		{
		}

		public virtual DbSet<Cources> Cources { get; set; }
		public virtual DbSet<StudentCources> StudentCources { get; set; }
		public virtual DbSet<Students> Students { get; set; }
		public virtual DbSet<Universities> Universities { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Cources>()
				.HasMany(e => e.StudentCources)
				.WithOptional(e => e.Cources)
				.HasForeignKey(e => e.CourseId);

			modelBuilder.Entity<Students>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<Students>()
				.HasMany(e => e.StudentCources)
				.WithOptional(e => e.Students)
				.HasForeignKey(e => e.StudentId);

			modelBuilder.Entity<Universities>()
				.HasMany(e => e.Cources)
				.WithOptional(e => e.Universities)
				.HasForeignKey(e => e.UniversityId)
				.WillCascadeOnDelete();
		}
	}
}
