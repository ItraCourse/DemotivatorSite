namespace WebApplication2.Models
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;

	public partial class DbEntities : DbContext
	{
		public DbEntities()
			: base("name=Entities")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			throw new UnintentionalCodeFirstException();
		}

		public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
		public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
		public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
		public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
		public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
		public virtual DbSet<Item> Item { get; set; }
		public virtual DbSet<Tags_Dem> Tags_Dem { get; set; }
		public virtual DbSet<Tags> Tags { get; set; }
	}
}
