using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using K9.Base.DataAccessLayer.Attributes;
using K9.Base.DataAccessLayer.Config;
using K9.Base.DataAccessLayer.Helpers;
using K9.Base.DataAccessLayer.Models;
using K9.Base.DataAccessLayer.Respositories;
using K9.SharedLibrary.Authentication;
using K9.SharedLibrary.Extensions;
using K9.SharedLibrary.Helpers;
using K9.SharedLibrary.Models;
using WebMatrix.WebData;

namespace K9.Base.DataAccessLayer.Database.Seeds
{
	public static class UsersAndRolesSeeder
	{
		public static void SeedUsersAndRoles(DbContext context)
		{
			var roles = new Helpers.Roles(
				context,
				new BaseRepository<Role>(context),
				new BaseRepository<Permission>(context),
				new BaseRepository<UserRole>(context),
				new BaseRepository<RolePermission>(context),
				new Users(context, new BaseRepository<User>(context)));

			var json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config/appsettings.json"));
			var dbConfig = ConfigHelper.GetConfiguration<DatabaseConfiguration>(json).Value;

			SeedSystemUser(dbConfig);
			SeedRoles(roles);
			SeedPermissions(roles);
		}

		private static void SeedSystemUser(DatabaseConfiguration dbConfig)
		{
			if (WebSecurity.Initialized)
			{
				if (!WebSecurity.UserExists(SystemUser.System))
				{
					WebSecurity.CreateUserAndAccount(SystemUser.System, dbConfig.SystemUserPassword, new
					{
						FirstName = "System",
						LastName = "User",
						Name = "System User",
					    FullName = "System User",
                        EmailAddress = "simon@glantzconsulting.co.uk",
						BirthDate = DateTime.Now,
						IsSystemStandard = true,
						IsUnsubscribed = false,
						CreatedBy = SystemUser.System,
						CreatedOn = DateTime.Now,
						LastUpdatedBy = SystemUser.System,
						LastUpdatedOn = DateTime.Now
					});
				}
			}
		}

		private static void SeedRoles(Roles roles)
		{
			roles.CreateRole(RoleNames.Administrators, true);
			roles.CreateRole(RoleNames.PowerUsers, true);
		    roles.CreateRole(RoleNames.DefaultUsers, true);
            roles.AddUserToRole(SystemUser.System, RoleNames.Administrators);
		}

		private static void SeedPermissions(Roles roles)
		{
			foreach (var item in typeof(ObjectBase).Assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(ObjectBase))))
			{
				var instance = Activator.CreateInstance(item) as IPermissable;
			    var isDefault = (item.GetAttribute<DefaultPermissionsAttribute>()?.Role == RoleNames.DefaultUsers);
			    var isAdmin = (item.GetAttribute<DefaultPermissionsAttribute>()?.Role == RoleNames.Administrators);

			    if (!isAdmin)
			    {
			        roles.CreatePermission(instance.CreatePermissionName, true);
			        roles.AddPermissionsToRole(instance.CreatePermissionName, RoleNames.PowerUsers);
			        if (isDefault)
			        {
			            roles.AddPermissionsToRole(instance.CreatePermissionName, RoleNames.DefaultUsers);
			        }

			        roles.CreatePermission(instance.EditPermissionName, true);
			        roles.AddPermissionsToRole(instance.EditPermissionName, RoleNames.PowerUsers);
			        if (isDefault)
			        {
			            roles.AddPermissionsToRole(instance.EditPermissionName, RoleNames.DefaultUsers);
			        }

			        roles.CreatePermission(instance.DeletePermissionName, true);
			        if (isDefault)
			        {
			            roles.AddPermissionsToRole(instance.DeletePermissionName, RoleNames.DefaultUsers);
			        }

			        roles.CreatePermission(instance.ViewPermissionName, true);
			        roles.AddPermissionsToRole(instance.ViewPermissionName, RoleNames.PowerUsers);
			        if (isDefault)
			        {
			            roles.AddPermissionsToRole(instance.ViewPermissionName, RoleNames.DefaultUsers);
			        }
			    }
			}
		}

	}
}
