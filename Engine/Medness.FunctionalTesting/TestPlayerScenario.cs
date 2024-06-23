using Medness.Business.Entities;
using Medness.Business.Enums;
using Medness.Testing.Common.TestData;

namespace Medness.FunctionalTesting
{
	[TestClass]
	public class TestPlayerScenario
	{
		PlayerData playerData;
		GameData gameData;

		[TestInitialize]
		public void Init()
		{
			playerData = new PlayerData();
			gameData = new GameData();
		}

		[TestMethod]
		public void TestSwitch()
		{
			// GIVEN a game and a player
			Player humanPlayer = playerData.testPlayers[PlayerIdentity.Human];

			// WHEN I switch to this player
			gameData.testGame.Switch(humanPlayer);

			// THEN the game's active player becomes this player
			Assert.IsTrue(gameData.testGame.IsPlayer(humanPlayer)); 
		}
	}
}