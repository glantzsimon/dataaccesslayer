using K9.DataAccessLayer.Config;
using K9.DataAccessLayer.Database.Seeds;
using K9.SharedLibrary.Helpers;
using System;
using System.Data.Entity.Migrations;
using System.IO;
using WebMatrix.WebData;

namespace K9.DataAccessLayer.Database
{
    public class DatabaseInitialiser<T> : DbMigrationsConfiguration<T>
        where T : Db
	{

		public DatabaseInitialiser()
		{
			DatabaseConfiguration dbConfig;
			var appSettingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config/appsettings.json");
			if (File.Exists(appSettingsFile))
			{
				var json = File.ReadAllText(appSettingsFile);
				dbConfig = ConfigHelper.GetConfiguration<DatabaseConfiguration>(json).Value;
			}
			else
			{
				dbConfig = new DatabaseConfiguration
				{
					AutomaticMigrationsEnabled = true,
					AutomaticMigrationDataLossAllowed = true
				};
			}

			AutomaticMigrationsEnabled = dbConfig.AutomaticMigrationsEnabled;
			AutomaticMigrationDataLossAllowed = dbConfig.AutomaticMigrationDataLossAllowed;
		}

		public static void InitialiseWebsecurity()
		{
			if (!WebSecurity.Initialized)
			{
				WebSecurity.InitializeDatabaseConnection("DefaultConnection", "User", "Id", "UserName", true);
			}
		}

		protected override void Seed(T context)
		{
			CountriesSeeder.SeedCountries(context);
		}

	}

	public class UsersAndRolesInitialiser
	{

		public static void Seed()
		{
			var db = new Db();
			UsersAndRolesSeeder.SeedUsersAndRoles(db);
			db.Dispose();
		}

	}
}
