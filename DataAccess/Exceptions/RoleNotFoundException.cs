using System;

namespace K9.Base.DataAccessLayer.Exceptions
{
	public class RoleNotFoundException : ApplicationException
	{

		public RoleNotFoundException(string roleName)
			: base($"The Role '{roleName}' was not found.") { }

	}
}
