using System.Linq;
using System.Data.Entity;

namespace DAL
{
	public class UserRepository : Repository<Models.User>, IUserRepository
	{
		public UserRepository(Models.DataBaseContext databaseContext)
			: base(databaseContext)
		{
		}
        //by
		//public IQueryable<Models.User> GetActiveUsers()
		//{
		//	var varUsers =
		//		Get()
		//		.Where(current => current.IsActive)
		//		;

		//	return (varUsers);
		//}
	}
}
