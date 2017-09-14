﻿

namespace K9.Base.DataAccessLayer.Config
{
	public class DatabaseConfiguration
	{
		public bool AutomaticMigrationsEnabled { get; set; }

		public bool AutomaticMigrationDataLossAllowed { get; set; }

		public string SystemUserPassword { get; set; }

		public string DefaultUserPassword { get; set; }
		
	}
}
