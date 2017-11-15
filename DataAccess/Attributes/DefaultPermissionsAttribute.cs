using System;

namespace K9.Base.DataAccessLayer.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
	public class DefaultPermissionsAttribute : Attribute
	{
		public string Role { get; set; }
		
	}
}
