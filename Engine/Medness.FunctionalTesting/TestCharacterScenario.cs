using Medness.Application.Entities;
using Medness.Application.Interfaces;
using Medness.Business.Entities;
using Medness.Business.Enums;
using Medness.FunctionalTesting.Repositories;

namespace Medness.FunctionalTesting
{
	public class TestCharacterScenario
	{
		#region Test data
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
		public void TestAddPlayableCharacter(Guid id, string name)
		{
			// GIVEN a game and a playable characer
			Character character = new Character(id, name, playable:true);

			// WHEN the player adds a character
			_game.AddCharacter(character);

			// THEN this character is added to the game
			Assert.IsTrue(_game.HasCharacter(character.id));
		}
	}
}
