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
				() => new Scene("TEST_ID", null));
		}

		[TestMethod]
		public void TestSceneEquality()
		{
			string commonId = "TEST_ID";
			Scene scene1 = new Scene(commonId, "sc1");
			Scene scene2 = new Scene(commonId, "sc2");
			Assert.AreEqual(scene1, scene2);
		}

		[TestMethod]
		public void TestSceneInequality()
		{
			Assert.AreNotEqual(
				sceneData.testScenes.Get(SceneData.SceneVillageId),
				sceneData.testScenes.Get(SceneData.SceneForestId));
		}
	}
}
