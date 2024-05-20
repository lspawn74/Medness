using Medness.Business.Entities;
using Medness.Business.Enums;

namespace Medness.FunctionalTesting
{
	[TestClass]
	public class TestPlayerScenario
	{
		#region Test data

		private const PlayerIdentity _playerIdentity = PlayerIdentity.Human;

		#endregion

		[TestMethod]
		[DataRow(_playerIdentity)]
		public void TestSwitch(PlayerIdentity playerIdentity)
		{
			// GIVEN a game and a player
			Player computerPlayer = new Player(PlayerIdentity.Computer);
			Game game = new Game(computerPlayer);
			Player player = new Player(playerIdentity);

			// WHEN I switch to this player
			game.SwitchPlayer(player);

			// THEN the game's active player becomes this player
			Assert.IsTrue(game.IsPlayer(player)); 
		}
	}
}