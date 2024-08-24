using Medness.Business.Entities;

namespace Medness.Business.Repositories
{
	public interface IItemRepository
	{
		/// <summary>
		///		Adds an item into the repository.
		/// </summary>
		/// <param name="item">The item to add.</param>
		public void Add(Item item);

		public void Remove(Item item);

		public Item Get(Guid id);

		public IEnumerable<Item> Get(string name);
	}
}
