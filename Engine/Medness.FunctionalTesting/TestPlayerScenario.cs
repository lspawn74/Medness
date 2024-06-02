using Medness.Application.Entities;
using Medness.Application.Interfaces;
using Medness.Business.Entities;
using Medness.Business.Enums;
using Medness.FunctionalTesting.Repositories;

namespace Medness.FunctionalTesting
{
	[TestClass]
	public class TestPlayerScenario
	{
		#region Test data
		private const PlayerIdentity _playerIdentity = PlayerIdentity.Human;
		private Player _computerPlayer;
		private ICharacterRepository _characterRepository;
		private Game _game;
		#endregion

		[TestInitialize]
		public void Init()
		{
			_computerPlayer = new Player(PlayerIdentity.Computer);
			_characterRepository = new CharacterRepository();
			_game = new Game(_computerPlayer, _characterRepository);
		}

		[TestMethod]
		[DataRow(_playerIdentity)]
		public void TestSwitch(PlayerIdentity playerIdentity)
		{
			// GIVEN a game and a player
			Player player = new Player(playerIdentity);

			// WHEN I switch to this player
			_game.SwitchPlayer(player);

			// THEN the game's active player becomes this player
			Assert.IsTrue(_game.IsPlayer(player)); 
		}
	}
}