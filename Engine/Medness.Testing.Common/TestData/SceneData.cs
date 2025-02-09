using Medness.Business.Entities;
using Medness.Testing.Common.Repositories;
using System.Collections.Generic;

namespace Medness.Testing.Common.TestData
{
	public class SceneData
	{
		#region Constants
		public const string SceneVillageId = "SC_VILLAGE";
		public const string SceneForestId = "SC_FOREST";
		public const string SceneBarId = "SC_BAR";
		public const string SceneVillage = "Village";
		public const string SceneForest = "Forêt";
		public const string SceneBar = "Auberge";
		#endregion

		#region Objects test data
		public SceneRepository testScenes;

		public SceneData()
		{
			testScenes = new SceneRepository();
			testScenes.Add(new Scene(SceneVillageId, SceneVillage));
			testScenes.Add(new Scene(SceneForestId, SceneForest));
			testScenes.Add(new Scene(SceneBarId, SceneBar));
		}
		#endregion

		#region Arguments test data
		public static IEnumerable<object[]> GetScenesArgs()
		{
			yield return new object[] { SceneVillageId, SceneVillage };
			yield return new object[] { SceneForestId, SceneForest };
			yield return new object[] { SceneBarId, SceneBar };
		}
		#endregion

	}
}
