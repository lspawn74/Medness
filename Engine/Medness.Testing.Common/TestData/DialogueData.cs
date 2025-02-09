using Medness.Business.Entities;
using Medness.Business.Enums;
using Medness.Business.ValueObjects;
using Medness.Testing.Common.Repositories;
using System.Collections.Generic;

namespace Medness.Testing.Common.TestData
{
	public class DialogueData
	{
		#region Constants
		public const string ForestSceneActivatedDiagItemId = "DLGITEM_FOREST_SCENE_ACTIVATED";
		public const string MorgauseEntersBarDiagItemId = "DLGITEM_MORGAUSE_ENTERS_BAR";
		#endregion

		#region Objects test data
		public CharacterData CharacterData;
		public ItemData ItemData;
		public SceneData SceneData;
		public DialogueItemRepository testItems;
		public Dictionary<string, DialogueTrigger> dialoguetriggers;

		public DialogueData()
		{
			// Initialize repositories
			CharacterData = new CharacterData();
			ItemData = new ItemData();
			SceneData = new SceneData();
			testItems = new DialogueItemRepository();

			// Add test dialogue item triggered for a specific scene activation
			testItems.Add(new DialogueItem(
					ForestSceneActivatedDiagItemId,
					CharacterData.testCharacters.Get(CharacterData.AldemareId),
					new List<DialogueTrigger>
					{
						new DialogueTrigger(SceneData.SceneForestId, DialogueItemTriggerType.SceneActivated)
					},
					ItemData.testItems,
					CharacterData.testCharacters,
					SceneData.testScenes,
					testItems
					));

			// Add test dialogue item triggered for a specific character entering a specific scene
			testItems.Add(new DialogueItem(
					MorgauseEntersBarDiagItemId,
					CharacterData.testCharacters.Get(CharacterData.BarTenderId),
					new List<DialogueTrigger>
					{
						new DialogueTrigger(CharacterData.MorgauseId, SceneData.SceneBarId, DialogueItemTriggerType.CharacterEnters)
					},
					ItemData.testItems,
					CharacterData.testCharacters,
					SceneData.testScenes,
					testItems
					));
		}
		#endregion
	}
}
