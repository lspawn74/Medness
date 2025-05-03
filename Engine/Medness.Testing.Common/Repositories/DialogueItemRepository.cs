using Medness.Business.Entities;
using Medness.Business.Interfaces;
using Medness.Business.Resources;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Medness.Testing.Common.Repositories
{
	/// <summary>Represents the repository containing dialogue items of the game.</summary>
	public class DialogueItemRepository : IRepository<DialogueItem>
	{
		#region Private fields
		/// <summary>The dialogue items are stored in an internal dictionary.</summary>
		private Dictionary<string, DialogueItem> _items = new Dictionary<string, DialogueItem>();
		#endregion

		#region IRepository implementation
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

		/// <summary>
		///		Checks for the existence of a dialogue item in the repository.
		/// </summary>
		/// <param name="id">The id of the dialogue item to check.</param>
		/// <returns>A <see cref="IResult"/> object with a flag <see cref="IResult.ISuccess"/>
		/// set to <see langword="true"/> if the dialogue item exists in the repository. And set to
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
		/// Exposes the enumerator, which supports a simple iteration over a collection of <see cref="DialogueItem"> type.
		/// </summary>
		public IEnumerator<DialogueItem> GetEnumerator()
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
