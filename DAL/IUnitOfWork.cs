namespace DAL
{
	public interface IUnitOfWork : System.IDisposable
	{
		IUserRepository UserRepository { get; }

		void Save();
	}
}
