using Medness.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			_items[item.id] = item;
		}

		public Item Get(Guid id)
		{
			return _items[id];
		}

		public IEnumerable<Item> Get(string name)
		{
			throw new NotImplementedException();
		}

		public void Remove(Item item)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
