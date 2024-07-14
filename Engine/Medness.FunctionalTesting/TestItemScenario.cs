using Medness.Business.Entities;
using Medness.Testing.Common.TestData;
using System;

namespace Medness.FunctionalTesting
{
	[TestClass]
	public class TestItemScenario
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
		public void TestAssignItem(Guid itemId, string itemName, Guid characterId)
		{
			// GIVEN an item and a character
			Item item = new Item(itemId, itemName);
			Character ansgarde = characterData.testCharacters["Ansgarde"];

			// WHEN the player adds this character
			ansgarde.AssignItem(item);

			// THEN this character is added to the game
			Assert.IsTrue(ansgarde.HasItem(itemId));
		}
	}
}
