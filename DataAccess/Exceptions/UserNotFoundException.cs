using System;

namespace K9.DataAccessLayer.Exceptions
{
	public class UserNotFoundException : ApplicationException
	{

		public UserNotFoundException(string username)
			: base($"The user '{username}' was not found.") { }

	}
}
