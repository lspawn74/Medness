using Medness.Business.Enums;
using Medness.Business.ValueObjects;

namespace Medness.Business.Entities
{
	public class Character
	{
		public readonly Guid id;
		public readonly string name;
		public readonly IsPlayable isPlayable;

        public Character(Guid identity, string characterName, bool playable)
        {
			ArgumentNullException.ThrowIfNull(characterName, nameof(characterName));

			id = identity;
			name = characterName;
			isPlayable = new IsPlayable(playable);
        }

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (obj is Character characterObj)
				return characterObj.id == id;

			return false;
		}

		public override int GetHashCode()
		{
			return id.GetHashCode();
		}
	}
}
