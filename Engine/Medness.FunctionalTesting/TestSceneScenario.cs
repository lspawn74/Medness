using Medness.Business.Entities;
using Medness.Business.Interfaces;
using Medness.Testing.Common.TestData;

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
		public void TestAddRemoveScene(string id, string name)
		{
			// GIVEN a game and a scene
			Scene newScene = new Scene(id, name);

			// WHEN the scene is added to the game
			IResult result = gameData.testGame.AddScene(newScene);

			// THEN this scene is added to the list of playable game's scenes
			Assert.IsTrue(result.IsSuccess);
			Assert.IsTrue(gameData.testGame.HasScene(id));

			// Check adding null scene
			result = gameData.testGame.AddScene(null);
			Assert.IsFalse(result.IsSuccess);
		}

		[TestMethod]
		[DynamicData(nameof(SceneData.GetScenesArgs), typeof(SceneData), DynamicDataSourceType.Method)]
		public void TestSwitchScene(string id, string name)
		{
			// GIVEN a game and a scene
			Scene newScene = new Scene(id, name);

			// WHEN the scene is displayed and it's not a game's scene
			Assert.IsFalse(gameData.testGame.Switch(newScene).IsSuccess);

			// THEN this scene doesn't become the current game's scenes
			Assert.IsFalse(gameData.testGame.IsActive(newScene));

			// AND WHEN the scene is displayed and it's a game's scene
			Assert.IsTrue(gameData.testGame.AddScene(newScene).IsSuccess);
			Assert.IsTrue(gameData.testGame.Switch(newScene).IsSuccess);

			// THEN this scene becomes the current game's scenes
			Assert.IsTrue(gameData.testGame.IsActive(newScene));
		}
	}
}
