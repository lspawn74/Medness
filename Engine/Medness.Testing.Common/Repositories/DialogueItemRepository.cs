using Medness.Business.Entities;
using Medness.Business.Interfaces;
using System;
using System.Collections.Generic;

namespace Medness.Testing.Common.Repositories
{
	/// <summary>
	///		Items repository used to contain objects of a scene or objects in a character's stuff.
	/// </summary>
	public class DialogueItemRepository : IRepository<DialogueItem>
	{
		#region Private fields
		private Dictionary<string, DialogueItem> _items = new Dictionary<string, DialogueItem>();
		#endregion

		#region IITemRepository implementation
		/// <summary>
		///		Adds adialogue item into the repository.
		/// </summary>
		/// <param name="item">The item to add.</param>
		public void Add(DialogueItem item)
		{
			ArgumentNullException.ThrowIfNull(item, nameof(item));
			_items[item.id] = item;
		}

		/// <summary>
		///		Gets a dialogue item from the repository.
		/// </summary>
		/// <param name="id">The id of the item to get.</param>
		public DialogueItem Get(string id)
		{
			if (_items.TryGetValue(id, out DialogueItem item))
				return item;
			return null;
		}
		#endregion
	}
}
