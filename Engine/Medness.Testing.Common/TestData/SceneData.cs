using Medness.Business.Entities;
using System.Collections.Generic;
using System;

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
				{ SceneVillage,  new Scene(Guid.NewGuid(), SceneVillage) },
				{ SceneForest,  new Scene( Guid.NewGuid(), SceneForest) }
			};
		}
		#endregion

		#region Arguments test data
		public static IEnumerable<object[]> GetScenesArgs()
		{
			yield return new object[] { Guid.NewGuid(), SceneVillage };
			yield return new object[] { Guid.NewGuid(), SceneForest };
		}
		#endregion

	}
}
