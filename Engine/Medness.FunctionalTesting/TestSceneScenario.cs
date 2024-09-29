using Medness.Business.Entities;
using Medness.Business.Repositories;
using Medness.Testing.Common.TestData;
using System;

namespace Medness.FunctionalTesting
{
	[TestClass]
	public class TestSceneScenario
	{
		GameData gameData;

		[TestInitialize]
		public void Initialize()
		{
			gameData = new GameData();
		}

		[TestMethod]
		[DynamicData(nameof(SceneData.GetScenesArgs), typeof(SceneData), DynamicDataSourceType.Method)]
		public void TestAddRemoveScene(Guid id, string name, IItemRepository itemRepo)
		{
			// GIVEN a game and a scene
			Scene newScene = new Scene(id, name, itemRepo);

			// WHEN the scene is added to the game
			gameData.testGame.AddScene(newScene);

			// THEN this scene is added to the list of playable game's scenes
			Assert.IsTrue(gameData.testGame.HasScene(id));

			// WHEN the scene is removed from the game
			gameData.testGame.RemoveScene(newScene);

			// THEN this scene is removed from the list of playable game scenes
			Assert.IsFalse(gameData.testGame.HasScene(id));
		}

		[TestMethod]
		[DynamicData(nameof(SceneData.GetScenesArgs), typeof(SceneData), DynamicDataSourceType.Method)]
		public void TestSwitchScene(Guid id, string name, IItemRepository itemRepo)
		{
			// GIVEN a game and a scene
			Scene newScene = new Scene(id, name, itemRepo);

			// WHEN the scene is displayed and it's not a game's scene
			gameData.testGame.Switch(newScene);

			// THEN this scene doesn't become the current game's scenes
			Assert.IsFalse(gameData.testGame.IsActive(newScene));

			// AND WHEN the scene is displayed and it's a game's scene
			gameData.testGame.AddScene(newScene);
			gameData.testGame.Switch(newScene);

			// THEN this scene becomes the current game's scenes
			Assert.IsTrue(gameData.testGame.IsActive(newScene));
		}
	}
}
