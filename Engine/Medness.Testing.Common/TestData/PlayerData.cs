using Medness.Business.Entities;
using Medness.Business.Enums;
using System.Collections.Generic;

namespace Medness.Testing.Common.TestData
{
	public class PlayerData
	{
		#region Objects test data
		public IDictionary<PlayerIdentity, Player> testPlayers;

		public PlayerData()
		{
			testPlayers = new Dictionary<PlayerIdentity, Player>
			{
				{ PlayerIdentity.Computer, new Player(PlayerIdentity.Computer) },
				{ PlayerIdentity.Human, new Player(PlayerIdentity.Human) },
			};
		}
		#endregion
	}
}
