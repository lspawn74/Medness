using Medness.Business.Entities;
using Medness.Business.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Medness.Testing.Common.Repositories
{
	/// <summary>
	///		Items repository used to contain objects of a scene or objects in a character's stuff.
	/// </summary>
	public class ItemRepository : IRepository<Item>
	{
		#region Private fields
		private Dictionary<string, Item> _items = new Dictionary<string, Item>();
		#endregion

		#region IRepository implementation
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

		public IEnumerator<Item> GetEnumerator()
		{
			return _items.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		#endregion


	}
}
