using Medness.Business.Entities;
using Medness.Testing.Common.TestData;
using System;
using System.Collections.Generic;

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
		public void TestAddScene(Guid id, string name)
		{
			// GIVEN a game and a scene
			Scene newScene = new Scene(id, name);

			// WHEN the scene is added to the game
			gameData.testGame.AddScene(newScene);

			// THEN this scene is added to the list of playable game's scenes
			Assert.IsTrue(gameData.testGame.HasScene(id));
		}
	}
}
