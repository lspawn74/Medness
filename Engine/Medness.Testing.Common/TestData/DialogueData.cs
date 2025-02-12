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
		public const string ForestSceneActivatedDlgItemId = "DLGITEM_FOREST_SCENE_ACTIVATED";
		public const string MorgauseEntersBarDlgItemId = "DLGITEM_MORGAUSE_ENTERS_BAR";
		public const string DialogueFinishedDlgItemId = "DLGITEM_DIALOGFINISHED";
		public const string ItemMovedDlgItemId = "DLGITEM_MORGAUSE_PICKS_ROPE_IN_FOREST";
		public const string KeyUsedInForestDlgItemId = "DLGITEM_KEY_USED_IN_FOREST_BY_MORGAUSE";
		public const string KeyUsedOnRopeDlgItemId = "DLGITEM_KEY_USED_ON_ROPE_BY_MORGAUSE";
		public const string DialogueItemChosenDlgItemId = "DLGITEM_ANSWER_CHOSEN";
		#endregion

		#region Objects test data
		public CharacterData CharacterData;
		public ItemData ItemData;
		public SceneData SceneData;
		public DialogueItemRepository dialogueItems;
		public Dictionary<string, DialogueTrigger> dialoguetriggers;

		public DialogueData()
		{
			// Initialize repositories
			CharacterData = new CharacterData();
			ItemData = new ItemData();
			SceneData = new SceneData();
			dialogueItems = new DialogueItemRepository();

			// Add test dialogue item triggered for a specific scene activation
			DialogueItem sceneActivatedDlgItem = new DialogueItem(
					ForestSceneActivatedDlgItemId,
					CharacterData.testCharacters.Get(CharacterData.AldemareId),
					new List<DialogueTrigger>
					{
						new DialogueTrigger(
							SceneData.SceneForestId,		// Id of the scene activated
							SceneData.testScenes,			// Scenes repository
							DialogueItemTriggerType.SceneActivated)
					});
			dialogueItems.Add(sceneActivatedDlgItem);

			// Add test dialogue item triggered for a specific character entering a specific scene
			DialogueItem characterEnteredSceneDlgItem = new DialogueItem(
					MorgauseEntersBarDlgItemId,
					CharacterData.testCharacters.Get(CharacterData.BarTenderId),
					new List<DialogueTrigger>
					{
						new DialogueTrigger(
							CharacterData.MorgauseId,		// Id of the chracter entering the scene
							CharacterData.testCharacters,	// Characters repository
							SceneData.SceneBarId,			// Id of the scene where the character enters
							DialogueItemTriggerType.CharacterEnters)
					});
			dialogueItems.Add(characterEnteredSceneDlgItem);

			// Add test dialogue item triggered after a specific dialog finished
			DialogueItem dialogueFinishedDlgItem = new DialogueItem(
					DialogueFinishedDlgItemId,
					CharacterData.testCharacters.Get(CharacterData.MorgauseId),
					new List<DialogueTrigger>
					{
						new DialogueTrigger(
							sceneActivatedDlgItem.id,	// Id of the previous dialogue
							dialogueItems,				// Dialogue items repository
							DialogueItemTriggerType.DialogueFinished)
					});
			dialogueItems.Add(dialogueFinishedDlgItem);

			// Add test dialogue item triggered after a specific item has been moved
			DialogueItem itemMovedDlgItem = new DialogueItem(
					ItemMovedDlgItemId,
					CharacterData.testCharacters.Get(CharacterData.MorgauseId),
					new List<DialogueTrigger>
					{
						new DialogueTrigger(
							ItemData.RopeId,			// Id of the moved item
							ItemData.testItems,			// Items repository
							SceneData.SceneForestId,	// Source holder of the item
							CharacterData.MorgauseId,	// Destination holder of the item
							DialogueItemTriggerType.ItemMoved)
					});
			dialogueItems.Add(itemMovedDlgItem);

			// Add test dialogue item triggered after the key item is used by Morgause in the forest
			DialogueItem keyUsedInForestDlgItem = new DialogueItem(
					KeyUsedInForestDlgItemId,
					CharacterData.testCharacters.Get(CharacterData.MorgauseId),
					new List<DialogueTrigger>
					{
						new DialogueTrigger(
							ItemData.KeyId,				// Id of the used item
							ItemData.testItems,			// Items repository
							CharacterData.MorgauseId,	// Holder of the item
							SceneData.SceneForestId,	// Scene where the item is expected to be used in order to trigger the dialogue
							DialogueItemTriggerType.ItemUsed)
					});
			dialogueItems.Add(keyUsedInForestDlgItem);

			// Add test dialogue item triggered after the key item is used on the rope item by Morgause (merging attempt))
			DialogueItem itemUsedOnOtherItemDlgItem = new DialogueItem(
					KeyUsedOnRopeDlgItemId,
					CharacterData.testCharacters.Get(CharacterData.MorgauseId),
					new List<DialogueTrigger>
					{
						new DialogueTrigger(
							ItemData.KeyId,				// Id of the used item
							ItemData.testItems,			// Items repository
							CharacterData.MorgauseId,	// Holder of the item
							ItemData.RopeId,			// Destination item
							DialogueItemTriggerType.ItemUsed)
					});
			dialogueItems.Add(itemUsedOnOtherItemDlgItem);

			// Add test dialogue item triggered after a specific dialogue is chosen
			DialogueItem dialogueItemChosenDlgItem = new DialogueItem(
					DialogueItemChosenDlgItemId,
					CharacterData.testCharacters.Get(CharacterData.MorgauseId),
					new List<DialogueTrigger>
					{
						new DialogueTrigger(
							DialogueItemChosenDlgItemId,	// Id of the chosen dialogue item
							dialogueItems,					// Dialogue items repository
							DialogueItemTriggerType.ChosenDialogue)
					});
			dialogueItems.Add(dialogueItemChosenDlgItem);

			// Initialize dialogue items
			foreach (DialogueItem item in dialogueItems)
				item.Initialize();
		}
		#endregion
	}
}
