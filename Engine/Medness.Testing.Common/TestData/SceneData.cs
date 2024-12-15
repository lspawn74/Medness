using Medness.Business.Entities;
using System.Collections.Generic;

namespace Medness.Testing.Common.TestData
{
	public class SceneData
	{
		#region Constants
		public const string SceneVillageId = "SC_VILLAGE";
		public const string SceneForestId = "SC_FOREST";
		public const string SceneVillage = "Village";
		public const string SceneForest = "Forest";
		#endregion

		#region Objects test data
		public Dictionary<string, Scene> testScenes;

		public SceneData()
		{
			testScenes = new Dictionary<string, Scene>
			{
				{ SceneVillage,  new Scene(SceneVillageId, SceneVillage) },
				{ SceneForest,  new Scene( SceneForestId, SceneForest) }
			};
		}
		#endregion

		#region Arguments test data
		public static IEnumerable<object[]> GetScenesArgs()
		{
			yield return new object[] { SceneVillageId, SceneVillage };
			yield return new object[] { SceneForestId, SceneForest };
		}
		#endregion

	}
}
