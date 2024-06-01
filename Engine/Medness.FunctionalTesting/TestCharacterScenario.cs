using Medness.Business.Entities;
using Medness.Business.Enums;

namespace Medness.FunctionalTesting
{
	public class TestCharacterScenario
	{
		Game _game;
		CharacterRepository _characterRepository;

		[TestInitialize]
		public void Init()
		{
			Player computerPlayer = new Player(PlayerIdentity.Computer);
			_game = new Game(computerPlayer);
		}

		[TestMethod]
		public void TestAddCharacter(CharacterIdentity characterIdentity)
		{
			// GIVEN a game and a characer
			Character character = new Character(characterIdentity);

			// WHEN the player adds a character
			_game.AddCharacter(character);

			// THEN this character is added to the game
			Assert.IsTrue(_game.HasCharacter(characterIdentity));
		}
	}
}
