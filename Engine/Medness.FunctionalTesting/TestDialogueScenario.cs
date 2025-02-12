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
		public void TestTriggerDialogueWhenItemUsedInScene()
		{
			// Get dialogue item for key being used in forest by Morgause
			DialogueItem itemUsedDlgItem = dialogueData.dialogueItems.Get(DialogueData.KeyUsedInForestDlgItemId);

			// Get characters used in test
			Character morgauseCharacter = dialogueData.CharacterData.testCharacters.Get(CharacterData.MorgauseId);
			Character ansgardeCharacter = dialogueData.CharacterData.testCharacters.Get(CharacterData.AnsgardeId);

			// Get items used in test
			Item ropeItem = dialogueData.ItemData.testItems.Get(ItemData.RopeId);
			Item keyItem = dialogueData.ItemData.testItems.Get(ItemData.KeyId);

			// Get scenes used in test
			Scene forestScene = dialogueData.SceneData.testScenes.Get(SceneData.SceneForestId);
			Scene barScene = dialogueData.SceneData.testScenes.Get(SceneData.SceneBarId);

			// Set event handlers on dialogue events
			itemUsedDlgItem.PlayStarted += PlayStarted;
			itemUsedDlgItem.PlayFinished += PlayFinished;

			// START TESTS :
			// Morgause use rope (and not key) in forest
			morgauseCharacter.AcquireStuff(ropeItem);
			ropeItem.Use(forestScene);

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Morgause use key in bar (and not forest)
			morgauseCharacter.AcquireStuff(keyItem);
			keyItem.Use(barScene);

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Ansgarde (and not Morgause) use key in forest
			ansgardeCharacter.AcquireStuff(keyItem);
			keyItem.Use(forestScene);

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Morgause use key in forest
			morgauseCharacter.AcquireStuff(keyItem);
			keyItem.Use(forestScene);

			// Check that dialogue is played
			Assert.IsTrue(playStartedEventHandled == 1);
			Assert.IsTrue(playFinishedEventHandled == 1);
		}

		[TestMethod]
		public void TestTriggerDialogueWhenItemUsedOnOtherItem()
		{
			// Get dialogue item for key being used on rope by Morgause (merging attempt)
			DialogueItem itemUsedDlgItem = dialogueData.dialogueItems.Get(DialogueData.KeyUsedOnRopeDlgItemId);

			// Get characters used in test
			Character morgauseCharacter = dialogueData.CharacterData.testCharacters.Get(CharacterData.MorgauseId);
			Character ansgardeCharacter = dialogueData.CharacterData.testCharacters.Get(CharacterData.AnsgardeId);

			// Get items used in test
			Item ropeItem = dialogueData.ItemData.testItems.Get(ItemData.RopeId);
			Item keyItem = dialogueData.ItemData.testItems.Get(ItemData.KeyId);
			Item alcoholGlassItem = dialogueData.ItemData.testItems.Get(ItemData.AlcoholGlassId);

			// Set event handlers on dialogue events
			itemUsedDlgItem.PlayStarted += PlayStarted;
			itemUsedDlgItem.PlayFinished += PlayFinished;

			// START TESTS :
			// Morgause use key on alcohol glass (and not rope)
			morgauseCharacter.AcquireStuff(keyItem);
			keyItem.Use(alcoholGlassItem);

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Morgause use alcohol glass (and not key) on rope
			morgauseCharacter.AcquireStuff(alcoholGlassItem);
			alcoholGlassItem.Use(keyItem);

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Ansgarde (and not Morgause) use key on rope
			ansgardeCharacter.AcquireStuff(keyItem);
			keyItem.Use(ropeItem);

			// Check that dialogue is not played
			Assert.IsTrue(playStartedEventHandled == 0);
			Assert.IsTrue(playFinishedEventHandled == 0);

			// Morgause use key on rope
			morgauseCharacter.AcquireStuff(keyItem);
			keyItem.Use(ropeItem);

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
			DialogueItem itemUsedDlgItem = dialogueData.dialogueItems.Get(DialogueData.KeyUsedInForestDlgItemId);

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
