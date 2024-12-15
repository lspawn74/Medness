using Medness.Business.Entities;
using Medness.Testing.Common.TestData;
using System;

namespace Medness.FunctionalTesting
{
	[TestClass]
	public class TestCharacterScenario
	{
		GameData gameData;
		CharacterData characterData;
		SceneData sceneData;

		[TestInitialize]
		public void Initialize()
		{
			gameData = new GameData();
			characterData = new CharacterData();
			sceneData = new SceneData();
		}

		[TestMethod]
		[DynamicData(nameof(CharacterData.GetCharactersArgs), typeof(CharacterData), DynamicDataSourceType.Method)]
		public void TestAddPlayableCharacter(string id, string name, bool playable)
		{
			// GIVEN a game and a playable character
			Character character = new Character(id, name, playable);

			// WHEN the player adds this character
			gameData.testGame.AddCharacter(character);

			// THEN this character is added to the game
			Assert.IsTrue(gameData.testGame.HasCharacter(character.id));
		}

		[TestMethod]
		public void TestSwitchPlayableCharacter()
		{
			// GIVEN a game with two or more characters (one active)
			Character character1 = characterData.testCharacters[CharacterData.AnsgardeName];
			Character character2 = characterData.testCharacters[CharacterData.AldemareName];
			gameData.testGame.AddCharacter(character1);
			gameData.testGame.Switch(character1);
			gameData.testGame.AddCharacter(character2);

			// WHEN I switch to the inactive Character
			gameData.testGame.Switch(character2);

			// THEN the game's active character becomes this character..
			Assert.IsTrue(gameData.testGame.IsActive(character2));
		}

		[TestMethod]
		public void TestCharacterEntersScene()
		{
			// GIVEN a character and a destination game's scene
			Character character = characterData.testCharacters[CharacterData.AnsgardeName];
			Scene destinationScene = sceneData.testScenes[SceneData.SceneForest];
			Assert.ThrowsException<ArgumentException>(() => gameData.testGame.EntersScene(character, destinationScene));
			gameData.testGame.AddCharacter(character);
			Assert.ThrowsException<ArgumentException>(() => gameData.testGame.EntersScene(character, destinationScene));
			gameData.testGame.AddScene(destinationScene);

			// WHEN the character enters the destination
			gameData.testGame.EntersScene(character, destinationScene);

			// THEN the character's current scene becomes the destination scene.
			Assert.IsTrue(character.IsInScene(destinationScene.id));
		}
	}
}
