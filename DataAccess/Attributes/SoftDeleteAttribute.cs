using System;

namespace K9.Base.DataAccessLayer.Attributes
{
    /// <summary>
    /// Entity will be marked as deleted but not removed from the database
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
	public class SoftDeleteAttribute : Attribute
	{
		
	}
}
