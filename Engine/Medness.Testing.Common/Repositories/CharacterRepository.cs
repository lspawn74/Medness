using Medness.Business.Entities;
using Medness.Business.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Medness.Testing.Common.Repositories
{
	public class CharacterRepository : IRepository<Character>
	{
		private Dictionary<string, Character> _characters = new Dictionary<string, Character>();

		public void Add(Character character)
		{
			ArgumentNullException.ThrowIfNull(character, nameof(character));
			_characters[character.id] = character;
		}

		public Character Get(string id)
		{
			if (_characters.TryGetValue(id, out Character character))
				return character;
			return null;
		}

		public IEnumerator<Character> GetEnumerator()
		{
			return _characters.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
