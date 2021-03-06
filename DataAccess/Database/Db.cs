﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using K9.Base.DataAccessLayer.Models;

namespace K9.Base.DataAccessLayer.Database
{
	public class Db : DbContext
	{

		public Db()
			: base("name=DefaultConnection")
		{
			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;
			Configuration.AutoDetectChangesEnabled = false;
		}
        
	    public DbSet<ArchiveItem> ArchiveItems { get; set; }
	    public DbSet<ArchiveCategory> ArchiveCategories { get; set; }
        public DbSet<User> Users { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<RolePermission> RolePermissions { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<NewsItem> NewsItems { get; set; }
        
	    protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
		}
	}
}
