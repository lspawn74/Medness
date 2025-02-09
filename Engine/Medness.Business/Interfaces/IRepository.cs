namespace Medness.Business.Interfaces
{
	/// <summary>
	/// This empty interface is required for polymorphism
	/// </summary>
	public interface IRepository
	{
	}

	public interface IRepository<T> : IRepository, IEnumerable<T>
	{
		/// <summary>
		///		Adds an entity into the repository.
		/// </summary>
		/// <param name="entity">The entity to add.</param>
		void Add(T entity);

		/// <summary>
		///		Gets an entity from the repository.
		/// </summary>
		/// <param name="id">The id of the entity to get.</param>
		T Get(string id);
	}
}
