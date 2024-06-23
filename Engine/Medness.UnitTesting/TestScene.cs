using Medness.Business.Entities;
using Medness.Testing.Common.TestData;
using System;

namespace Medness.UnitTesting
{
	[TestClass]
	public class TestScene
	{
		SceneData sceneData;

		[TestInitialize]
		public void Initialize()
		{
			sceneData = new SceneData();
		}

		[TestMethod]
		public void TestSceneNull()
		{
			Assert.ThrowsException<ArgumentNullException>(
				() => new Scene(Guid.NewGuid(), null));
		}

		[TestMethod]
		public void TestSceneEquality()
		{
			Guid commonId = Guid.NewGuid();
			Scene scene1 = new Scene(commonId, "sc1");
			Scene scene2 = new Scene(commonId, "sc2");
			Assert.AreEqual(scene1, scene2);
		}

		[TestMethod]
		public void TestSceneInequality()
		{
			Assert.AreNotEqual(
				sceneData.testScenes[SceneData.SceneVillage],
				sceneData.testScenes[SceneData.SceneForest]);
		}
	}
}
