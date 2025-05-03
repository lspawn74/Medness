using Medness.Business.Entities;
using Medness.Business.Interfaces;
using Medness.Business.Resources;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Medness.Testing.Common.Repositories
{
	/// <summary>Represents the repository containing items of the game.</summary>
	public class ItemRepository : IRepository<Item>
	{
		#region Private fields
		/// <summary>The items are stored in an internal dictionary.</summary>
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
		/// <summary>
		///		Checks for the existence of a item in the repository.
		/// </summary>
		/// <param name="id">The id of the item to check.</param>
		/// <returns>A <see cref="IResult"/> object with a flag <see cref="IResult.ISuccess"/>
		/// set to <see langword="true"/> if the item exists in the repository. And set to
		/// <see langword="false"/> otherwise.</returns>
		public IResult Contains(string id)
		{
			if (_items.ContainsKey(id))
				return Results.Success;
			return Results.ErrorUnknownId;
		}
		#endregion

		#region IEnumerable implementation
		/// <summary>
		/// Exposes the enumerator, which supports a simple iteration over a collection of <see cref="Item"> type.
		/// </summary>
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
