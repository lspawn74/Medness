using Medness.Application.Interfaces;
using Medness.Business.Entities;

namespace Medness.UnitTesting.Repositories
{
	public class CharacterRepository : ICharacterRepository
	{
		private Dictionary<Guid, Character> _characters = new Dictionary<Guid, Character>();

		public void Add(Character character)
		{
			ArgumentNullException.ThrowIfNull(character, nameof(character));
			_characters[character.id] = character;
		}

		public Character Get(Guid id)
		{
			if (_characters.ContainsKey(id))
				return _characters[id];
			return null;
		}

		public IEnumerable<Character> Get(string name)
		{
			return _characters.Where(x => x.Value.name == name)?.Select(x => x.Value);
		}
	}
}
