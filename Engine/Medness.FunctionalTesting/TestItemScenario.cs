using Medness.Business.Entities;
using Medness.Testing.Common.TestData;

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
		public void TestMoveItem()
		{
			// Create an item
			string itemId = "TEST_ID";
			string itemName = "Test Item";
			Item item = new Item(itemId, itemName);

			// Get scene item repository
			Scene scene = sceneData.testScenes[SceneData.SceneForest];

			// Check that item isn't in the scene repository
			Assert.AreEqual(scene.Holds(item), false);

			// Put item in the scene
			item.MoveTo(scene);

			// Check that item is in the scene
			Assert.AreEqual(scene.Holds(item), true);

			// Move item from scene to character stuff
			Character character = characterData.testCharacters[CharacterData.AnsgardeName];

			// Check that item is not in the character's stuff
			Assert.AreEqual(character.Holds(item), false);

			// Move item to character's stuff
			item.MoveTo(character);

			// Check that item is no more in the scene repository
			Assert.AreEqual(scene.Holds(item), false);

			// Check that item is in the character stuff
			Assert.AreEqual(character.Holds(item), true);
		}

		[TestMethod]
		[DynamicData(nameof(ItemData.GetItemsArgs), typeof(ItemData), DynamicDataSourceType.Method)]
		public void TestAssignItem(string itemId, string itemName)
		{
			// GIVEN an item and a character
			Item item = new Item(itemId, itemName);
			Character ansgarde = characterData.testCharacters["Ansgarde"];

			// WHEN the player assings the item to the character
			ansgarde.AcquireStuff(item);

			// THEN this character has this item in its inventory
			Assert.IsTrue(ansgarde.Holds(item));
		}
	}
}
