using Medness.Business.Entities;

namespace Medness.Business.Interfaces
{
	public interface IItemRepository
	{
		/// <summary>
		///		Adds an item into the repository.
		/// </summary>
		/// <param name="item">The item to add.</param>
		void Add(Item item);

		/// <summary>
		///		Gets an item from the repository.
		/// </summary>
		/// <param name="id">The id of the item to get.</param>
		Item Get(string id);

		/// <summary>
		///		Gets all items of an items holder (a scene or a character).
		/// </summary>
		/// <param name="holder">The holder of the items to get.</param>
		IEnumerable<Item> GetAll(IStuffHolder holder);
	}
}
