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

		/// <summary>
		///		Checks for the existence of an entity in the repository.
		/// </summary>
		/// <param name="id">The id of the entity to check.</param>
		/// <returns>A <see cref="IResult"/> object with a flag <see cref="IResult.ISuccess"/>
		/// set to <see langword="true"/> if the entity exists in the repository. And set to
		/// <see langword="false"/> otherwise.</returns>
		IResult Contains(string id);
	}
}
