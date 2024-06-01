using Medness.Business.Enums;

namespace Medness.Business.Entities
{
	public class Character
	{
		public readonly CharacterIdentity id;

        public Character(CharacterIdentity characterIdentity)
        {
            id = characterIdentity;
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
