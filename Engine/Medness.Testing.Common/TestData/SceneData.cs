using Medness.Business.Entities;
using Medness.Business.Repositories;
using System;
using System.Collections.Generic;

namespace Medness.Testing.Common.TestData
{
	public class SceneData
	{
		#region Constants
		public const string SceneVillage = "Village";
		public const string SceneForest = "Forest";
		#endregion

		#region Objects test data
		public Dictionary<string, Scene> testScenes;

		public SceneData()
		{
			testScenes = new Dictionary<string, Scene>
			{
				{ SceneVillage,  new Scene(Guid.NewGuid(), SceneVillage, new ItemRepository()) },
				{ SceneForest,  new Scene( Guid.NewGuid(), SceneForest, new ItemRepository()) }
			};
		}
		#endregion

		#region Arguments test data
		public static IEnumerable<object[]> GetScenesArgs()
		{
			yield return new object[] { Guid.NewGuid(), SceneVillage, new ItemRepository() };
			yield return new object[] { Guid.NewGuid(), SceneForest, new ItemRepository() };
		}
		#endregion

	}
}
