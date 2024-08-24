using Medness.Business.Entities;
using Medness.Testing.Common.TestData;
using Medness.Business.Repositories;
using System;
using System.Linq;

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
		public void TestMoveItem(Scene destinationScene, Character character)
		{
			// Create an item
			Guid itemId = Guid.NewGuid();
			string itemName = "Test Item";
			Item item = new Item(itemId, itemName);

			// Get scene item repository
			IItemRepository sceneItemRepository = destinationScene.items;

			// Check that item isn't in the scene repository
			Assert.IsNull(sceneItemRepository.Get(itemId));
			Assert.AreEqual(sceneItemRepository.Get(itemName).Count(), 0);

			// Put item in the scene
			item.MoveTo(sceneItemRepository);

			// Check that item is in the scene
			Assert.AreEqual(sceneItemRepository.Get(itemId), item);
			Assert.AreEqual(sceneItemRepository.Get(itemName).FirstOrDefault(), item);

			// Move item from scene to character stuff
			IItemRepository characterStuff = character.stuff;

			// Check that item is not in the character's stuff
			Assert.IsNull(characterStuff.Get(itemId));
			Assert.AreEqual(characterStuff.Get(itemName).Count(), 0);

			item.MoveTo(characterStuff);

			// Check that item is no more in the scene repository
			Assert.IsNull(sceneItemRepository.Get(itemId));
			Assert.AreEqual(sceneItemRepository.Get(itemName).Count(), 0);

			// Check that item is in the character stuff
			Assert.AreEqual(characterStuff.Get(itemId), item);
			Assert.AreEqual(characterStuff.Get(itemName).FirstOrDefault(), item);
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
