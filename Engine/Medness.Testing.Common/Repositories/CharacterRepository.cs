using Medness.Business.Entities;
using Medness.Business.Interfaces;
using Medness.Business.Resources;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Medness.Testing.Common.Repositories
{
	/// <summary>Represents the repository containing characters of the game.</summary>
	public class CharacterRepository : IRepository<Character>
	{
		#region Private fields
		/// <summary>The characters are stored in an internal dictionary.</summary>
		private Dictionary<string, Character> _characters = new Dictionary<string, Character>();
		#endregion

		#region IRepository implementation
		/// <summary>
		///		Adds a character into the repository.
		/// </summary>
		/// <param name="character">The character to add.</param>
		public void Add(Character character)
		{
			ArgumentNullException.ThrowIfNull(character, nameof(character));
			_characters[character.id] = character;
		}

		/// <summary>
		///		Gets a character from the repository.
		/// </summary>
		/// <param name="id">The id of the character to get.</param>
		public Character Get(string id)
		{
			if (_characters.TryGetValue(id, out Character character))
				return character;
			return null;
		}

		/// <summary>
		///		Checks for the existence of a character in the repository.
		/// </summary>
		/// <param name="id">The id of the character to check.</param>
		/// <returns>A <see cref="IResult"/> object with a flag <see cref="IResult.ISuccess"/>
		/// set to <see langword="true"/> if the character exists in the repository. And set to
		/// <see langword="false"/> otherwise.</returns>
		public IResult Contains(string id)
		{
			if (_characters.ContainsKey(id))
				return Results.Success;
			return Results.ErrorUnknownId;
		}
		#endregion

		#region IEnumerable implementation
		/// <summary>
		/// Exposes the enumerator, which supports a simple iteration over a collection of <see cref="Character"> type.
		/// </summary>
		public IEnumerator<Character> GetEnumerator()
		{
			return _characters.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		#endregion
	}
}
