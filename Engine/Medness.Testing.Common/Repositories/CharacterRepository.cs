using Medness.Application.Interfaces;
using Medness.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Medness.Testing.Common.Repositories
{
	public class CharacterRepository : ICharacterRepository
	{
		private Dictionary<Guid, Character> _characters = new Dictionary<Guid, Character>();

		public void Add(Character character)
		{
			ArgumentNullException.ThrowIfNull(character, nameof(character));
			_characters[character.id] = character;
		}

		public void Remove(Character character)
		{
			ArgumentNullException.ThrowIfNull(character, nameof(character));
			_characters.Remove(character.id);
		}

		public Character Get(Guid id)
		{
			if (_characters.TryGetValue(id, out Character character))
				return character;
			return null;
		}

		public IEnumerable<Character> Get(string name)
		{
			return _characters.Where(x => x.Value.name == name)?.Select(x => x.Value);
		}
	}
}
