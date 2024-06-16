using Medness.Application.Entities;
using Medness.Application.Interfaces;
using Medness.Business.Entities;
using Medness.Business.Enums;
using Medness.FunctionalTesting.Repositories;

namespace Medness.FunctionalTesting
{
	[TestClass]
	public class TestCharacterScenario
	{
		#region Test data
		private Player _computerPlayer;
		private ICharacterRepository _characterRepository;
		private Game _game;
		private const string _ansgardeName = "Ansgarde";
		private const string _aldemareName = "Aldemare";
		private const string _robinName = "Robin";
		private const string _morgauseName = "Morgause";
		#endregion

		#region Dynamic test data
		private static IEnumerable<object[]> GetCharactersData()
		{
			yield return new object[] { Guid.NewGuid(), _ansgardeName, true };
			yield return new object[] { Guid.NewGuid(), _aldemareName, true };
			yield return new object[] { Guid.NewGuid(), _robinName, true };
			yield return new object[] { Guid.NewGuid(), _morgauseName, true };
		}
		#endregion

		[TestInitialize]
		public void Init()
		{
			_computerPlayer = new Player(PlayerIdentity.Computer);
			_characterRepository = new CharacterRepository();
			_game = new Game(_computerPlayer, _characterRepository);
		}

		[TestMethod]
		[DynamicData(nameof(GetCharactersData), DynamicDataSourceType.Method)]
		public void TestAddPlayableCharacter(Guid id, string name, bool playable)
		{
			// GIVEN a game and a playable character
			Character character = new Character(id, name, playable);

			// WHEN the player adds this character
			_game.AddCharacter(character);

			// THEN this character is added to the game
			Assert.IsTrue(_game.HasCharacter(character.id));
		}

		[TestMethod]
		[DynamicData(nameof(GetCharactersData), DynamicDataSourceType.Method)]
		public void TestRemovePlayableCharacter(Guid id, string name, bool playable)
		{
			// GIVEN a game and a playable character in the game
			Character character = new Character(id, name, playable);
			_game.AddCharacter(character);

			// WHEN the player removes this character
			_game.RemoveCharacter(character);

			// THEN this character is removed from the game
			Assert.IsFalse(_game.HasCharacter(character.id));
		}

		[TestMethod]
		public void TestSwitchPlayableCharacter()
		{
			// GIVEN a game with two or more characters (one active)
			Character character1 = new Character(Guid.NewGuid(), _ansgardeName, true);
			_game.AddCharacter(character1);
			_game.Switch(character1);
			Character character2 = new Character(Guid.NewGuid(), _aldemareName, true);
			_game.AddCharacter(character2);

			// WHEN I switch to the inactive Character
			_game.Switch(character2);

			// THEN the game's active character becomes this character..
			Assert.IsTrue(_game.IsActive(character2));
		}
	}
}
