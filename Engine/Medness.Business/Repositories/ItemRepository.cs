using Medness.Business.Entities;

namespace Medness.Business.Repositories
{
	/// <summary>
	///		Items repository used to contain objects of a scene or objects in a character's stuff.
	/// </summary>
	public class ItemRepository : IItemRepository
	{
		#region Private fields
		private Dictionary<Guid, Item> _items = new Dictionary<Guid, Item>();
		#endregion

		#region IITemRepository implementation
		/// <summary>
		///		Adds an item into the repository.
		/// </summary>
		/// <param name="item">The item to add.</param>
		public void Add(Item item)
		{
			ArgumentNullException.ThrowIfNull(item, nameof(item));
			_items[item.id] = item;
		}

		public Item Get(Guid id)
		{
			if (_items.TryGetValue(id, out Item item))
				return item;
			return null;
		}

		public IEnumerable<Item> Get(string name)
		{
			return _items.Where(x => x.Value.name == name)?.Select(x => x.Value);
		}

		public void Remove(Item item)
		{
			ArgumentNullException.ThrowIfNull(item, nameof(item));
			_items.Remove(item.id);
		}
		#endregion
	}
}
