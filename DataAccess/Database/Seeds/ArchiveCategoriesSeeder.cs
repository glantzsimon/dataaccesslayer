using K9.Base.DataAccessLayer.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace K9.Base.DataAccessLayer.Database.Seeds
{
    public static class ArchiveCategoriesSeeder
    {
		public static void SeedArchiveCategories(DbContext context)
		{
			if (!context.Set<ArchiveCategory>().Any())
			{
			    context.Set<ArchiveCategory>().AddOrUpdate(new ArchiveCategory { Name = "Audio", IsSystemStandard = true });
                context.Set<ArchiveCategory>().AddOrUpdate(new ArchiveCategory { Name = "Videos", IsSystemStandard = true});
			    context.Set<ArchiveCategory>().AddOrUpdate(new ArchiveCategory { Name = "Photos", IsSystemStandard = true });
			    context.Set<ArchiveCategory>().AddOrUpdate(new ArchiveCategory { Name = "Documents", IsSystemStandard = true });
            }
		}

	}
}
