using Medness.Business.Entities;
using Medness.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Medness.Testing.Common.Repositories
{
	/// <summary>
	///		Items repository used to contain objects of a scene or objects in a character's stuff.
	/// </summary>
	public class ItemRepository : IItemRepository
	{
		#region Private fields
		private Dictionary<string, Item> _items = new Dictionary<string, Item>();
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

		/// <summary>
		///		Gets an item from the repository.
		/// </summary>
		/// <param name="id">The id of the item to get.</param>
		public Item Get(string id)
		{
			if (_items.TryGetValue(id, out Item item))
				return item;
			return null;
		}

		/// <summary>
		///		Gets all items of an items holder (a scene or a character).
		/// </summary>
		/// <param name="holder">The holder of the items to get.</param>
		public IEnumerable<Item> GetAll(IStuffHolder holder)
		{
			return _items.Where(kv => kv.Value.GetHolder() == holder)?.Select(kv => kv.Value);
		}
		#endregion
	}
}
