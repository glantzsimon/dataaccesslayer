using System.Data.Entity;
using System.Linq;
using K9.Base.DataAccessLayer.Exceptions;
using K9.Base.DataAccessLayer.Models;
using K9.SharedLibrary.Models;

namespace K9.Base.DataAccessLayer.Helpers
{
	public class Users : IUsers
	{
		private readonly DbContext _db;
		private readonly IRepository<User> _repository;

		public Users(DbContext db, IRepository<User> repository)
		{
			_db = db;
			_repository = repository;
		}

		public IUser GetUser(string username)
		{
			var user = _repository.GetQuery($"SELECT TOP 1 * FROM [User] WHERE [Username] = '{username}'").FirstOrDefault();
			if (user == null)
			{
				throw new UserNotFoundException(username);
			}
			return user;
		}

	}
}
