using Medness.Business.Entities;

namespace Medness.Business.Repositories
{
	internal interface IItemRepository
	{
		public void Add(Item item);

		public void Remove(Item item);

		public Item Get(Guid id);

		public IEnumerable<Item> Get(string name);
	}
}
