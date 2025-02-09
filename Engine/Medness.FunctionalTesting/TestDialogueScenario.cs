using Medness.Business.Entities;
using Medness.Testing.Common.TestData;

namespace Medness.FunctionalTesting
{
	[TestClass]
	public class TestDialogueScenario
	{
		private DialogueData dialogueData;
		private int playStartedEventHandled;
		private int playFinishedEventHandled;

		[TestInitialize]
		public void Initialize()
		{
			dialogueData = new DialogueData();
			playStartedEventHandled = 0;
			playFinishedEventHandled = 0;
		}

		[TestMethod]
		public void TestTriggerDialogueWhenSceneActivates()
		{
			// Get dialogue item for forest scene activation
			DialogueItem sceneActivatedDlgItem = dialogueData.dialogueItems.Get(DialogueData.ForestSceneActivatedDlgItemId);

			// Set event handlers on dialogue events
			sceneActivatedDlgItem.PlayStarted += PlayStarted;
			sceneActivatedDlgItem.PlayFinished += PlayFinished;

			// Raise the event of bar scene activating (and not the forest)
			Scene barScene = dialogueData.SceneData.testScenes.Get(SceneData.SceneBarId);
			barScene.Activates();

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Raise the event of forest scene activating
			Scene forestScene = dialogueData.SceneData.testScenes.Get(SceneData.SceneForestId);
			forestScene.Activates();

			// Check that dialogue is played
			Assert.IsTrue(playStartedEventHandled == 1);
			Assert.IsTrue(playFinishedEventHandled == 1);
		}

		[TestMethod]
		public void TestTriggerDialogueWhenCharacterEntersScene()
		{
			// Get dialogue item for Morgause entering bar
			DialogueItem characterEnteredSceneDlgItem = dialogueData.dialogueItems.Get(DialogueData.MorgauseEntersBarDlgItemId);

			// Set event handlers on dialogue events
			characterEnteredSceneDlgItem.PlayStarted += PlayStarted;
			characterEnteredSceneDlgItem.PlayFinished += PlayFinished;

			// Raise the event of Ansgarde entering the bar (and not Morgause)
			Character ansgardeCharacter = dialogueData.CharacterData.testCharacters.Get(CharacterData.AnsgardeId);
			ansgardeCharacter.EntersScene(SceneData.SceneBarId);

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Raise the event of Morgause entering the forest (and not the bar)
			Character morgauseCharacter = dialogueData.CharacterData.testCharacters.Get(CharacterData.MorgauseId);
			morgauseCharacter.EntersScene(SceneData.SceneForestId);

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Raise the event of Morgause entering the bar
			morgauseCharacter.EntersScene(SceneData.SceneBarId);

			// Check that dialogue is played
			Assert.IsTrue(playStartedEventHandled == 1);
			Assert.IsTrue(playFinishedEventHandled == 1);
		}

		[TestMethod]
		public void TestTriggerDialogueWhenDialogueFinished()
		{
			// Get dialogue item for forest scene activation
			DialogueItem sceneActivatedDlgItem = dialogueData.dialogueItems.Get(DialogueData.ForestSceneActivatedDlgItemId);

			// Get dialogue item for Morgause entering bar
			DialogueItem characterEnteredSceneDlgItem = dialogueData.dialogueItems.Get(DialogueData.MorgauseEntersBarDlgItemId);

			// Get dialogue item for the scene activation dialogue finishing
			DialogueItem dialogueFinishedDlgItem = dialogueData.dialogueItems.Get(DialogueData.DialogueFinishedDlgItemId);

			// Set event handlers on dialogue events
			sceneActivatedDlgItem.PlayStarted += PlayStarted;
			sceneActivatedDlgItem.PlayFinished += PlayFinished;
			dialogueFinishedDlgItem.PlayStarted += PlayStarted;
			dialogueFinishedDlgItem.PlayFinished += PlayFinished;

			// Raise the event of Morgause entering the bar (and not the forest scene activating)
			Character morgauseCharacter = dialogueData.CharacterData.testCharacters.Get(CharacterData.MorgauseId);
			morgauseCharacter.EntersScene(SceneData.SceneBarId);

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Raise the event of forest scene activating
			Scene forestScene = dialogueData.SceneData.testScenes.Get(SceneData.SceneForestId);
			forestScene.Activates();

			// Check that dialogue is played and that the handler has been called twice
			// (since forest scene activation also triggered the handler)
			Assert.IsTrue(playStartedEventHandled == 2);
			Assert.IsTrue(playFinishedEventHandled == 2);
		}

		[TestMethod]
		public void TestTriggerDialogueWhenItemMoved()
		{
			// Get dialogue item for rope being picked up by Morgause in the forest
			DialogueItem itemMovedDlgItem = dialogueData.dialogueItems.Get(DialogueData.ItemMovedDlgItemId);

			// Set event handlers on dialogue events
			itemMovedDlgItem.PlayStarted += PlayStarted;
			itemMovedDlgItem.PlayFinished += PlayFinished;

			// Put rope and key in the forest
			Scene forestScene = dialogueData.SceneData.testScenes.Get(SceneData.SceneForestId);
			Item keyItem = dialogueData.ItemData.testItems.Get(ItemData.KeyId);
			Item ropeItem = dialogueData.ItemData.testItems.Get(ItemData.RopeId);
			keyItem.MoveTo(forestScene);
			ropeItem.MoveTo(forestScene);

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Raise the event of Morgause picking up a key in the forest (and not the rope)
			Character morgauseCharacter = dialogueData.CharacterData.testCharacters.Get(CharacterData.MorgauseId);
			morgauseCharacter.EntersScene(SceneData.SceneForestId);
			keyItem.MoveTo(morgauseCharacter);

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Raise the event of Morgause picking up a rope in the forest
			ropeItem.MoveTo(morgauseCharacter);

			// Check that dialogue is played
			Assert.IsTrue(playStartedEventHandled == 1);
			Assert.IsTrue(playFinishedEventHandled == 1);
		}

		[TestMethod]
		public void TestTriggerDialogueWhenItemUsed()
		{
			// Get dialogue item for key being used
			DialogueItem itemUsedDlgItem = dialogueData.dialogueItems.Get(DialogueData.ItemUsedDlgItemId);

			// Set event handlers on dialogue events
			itemUsedDlgItem.PlayStarted += PlayStarted;
			itemUsedDlgItem.PlayFinished += PlayFinished;

			// Use rope
			Item ropeItem = dialogueData.ItemData.testItems.Get(ItemData.RopeId);
			ropeItem.Use();

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Use key
			Item keyItem = dialogueData.ItemData.testItems.Get(ItemData.KeyId);
			keyItem.Use();

			// Check that dialogue is played
			Assert.IsTrue(playStartedEventHandled == 1);
			Assert.IsTrue(playFinishedEventHandled == 1);
		}

		[TestMethod]
		public void TestTriggerDialogueWhenDialogueItemChosen()
		{
			// Get dialogue item for dialog being chosen
			DialogueItem dialogueItemChosenDlgItem = dialogueData.dialogueItems.Get(DialogueData.DialogueItemChosenDlgItemId);

			// Get dialogue item for key being used
			DialogueItem itemUsedDlgItem = dialogueData.dialogueItems.Get(DialogueData.ItemUsedDlgItemId);

			// Set event handlers on dialogue events
			dialogueItemChosenDlgItem.PlayStarted += PlayStarted;
			dialogueItemChosenDlgItem.PlayFinished += PlayFinished;

			// Choose dialogue item for key being used (and not the one specific for this test)  
			itemUsedDlgItem.Choose();

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Choose correct dialogue item  
			dialogueItemChosenDlgItem.Choose();

			// Check that dialogue is played
			Assert.IsTrue(playStartedEventHandled == 1);
			Assert.IsTrue(playFinishedEventHandled == 1);
		}

		private void PlayStarted(object sender, Business.Event.Args.DialogueItemEventArgs e)
		{
			playStartedEventHandled++;
		}

		private void PlayFinished(object sender, Business.Event.Args.DialogueItemEventArgs e)
		{
			playFinishedEventHandled++;
		}
	}
}
