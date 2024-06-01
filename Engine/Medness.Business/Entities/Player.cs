using Medness.Business.Enums;

namespace Medness.Business.Entities
{
	public class Player
	{
		public readonly PlayerIdentity id;

        public Player(PlayerIdentity playerId)
        {
            id = playerId;
        }

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (obj is  Player playerObj)
				return playerObj.id == id;
			
			return false;
		}

		public override int GetHashCode()
		{
			return id.GetHashCode();
		}
	}
}
