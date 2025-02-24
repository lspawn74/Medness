﻿using Medness.Business.Entities;
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
			gameData.testGame.AddScene(newScene);

			// THEN this scene is added to the list of playable game's scenes
			Assert.IsTrue(gameData.testGame.HasScene(id));
		}

		[TestMethod]
		[DynamicData(nameof(SceneData.GetScenesArgs), typeof(SceneData), DynamicDataSourceType.Method)]
		public void TestSwitchScene(string id, string name)
		{
			// GIVEN a game and a scene
			Scene newScene = new Scene(id, name);

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
