using Medness.Business.Entities;
using Medness.Testing.Common.TestData;

namespace Medness.FunctionalTesting
{
	[TestClass]
	public class TestDialogueScenario
	{
		private DialogueData dialogueData;
		private bool playStartedEventHandled;
		private bool playFinishedEventHandled;

		[TestInitialize]
		public void Initialize()
		{
			dialogueData = new DialogueData();
		}

		[TestMethod]
		public void TestSceneActivates()
		{
			// Get dialogue item for forest scene activation
			DialogueItem diagItem = dialogueData.testItems.Get(DialogueData.ForestSceneActivatedDiagItemId);

			// Set event handlers on dialogue events
			playStartedEventHandled = false;
			diagItem.PlayStarted += PlayStarted;
			playFinishedEventHandled = false;
			diagItem.PlayFinished += PlayFinished;

			// Raise the event of bar scene activating
			Scene barScene = dialogueData.SceneData.testScenes.Get(SceneData.SceneBarId);
			barScene.Activates();

			// Check that dialogue is not played
			Assert.IsFalse(playStartedEventHandled);
			Assert.IsFalse(playFinishedEventHandled);

			// Raise the event of forest scene activating
			Scene forestScene = dialogueData.SceneData.testScenes.Get(SceneData.SceneForestId);
			forestScene.Activates();

			// Check that dialogue is played
			Assert.IsTrue(playStartedEventHandled);
			Assert.IsTrue(playFinishedEventHandled);
		}

		[TestMethod]
		public void TestCharacterEntersScene()
		{
			// Get dialogue item
			DialogueItem diagItem = dialogueData.testItems.Get(DialogueData.MorgauseEntersBarDiagItemId);

			// Set event handlers on dialogue events
			playStartedEventHandled = false;
			diagItem.PlayStarted += PlayStarted;
			playFinishedEventHandled = false;
			diagItem.PlayFinished += PlayFinished;

			// Raise the event of Morgause entering the bar
			Character ansgardeCharacter = dialogueData.CharacterData.testCharacters.Get(CharacterData.AnsgardeId);
			ansgardeCharacter.EntersScene(SceneData.SceneBarId);

			// Check that dialogue is not played
			Assert.IsFalse(playStartedEventHandled);
			Assert.IsFalse(playFinishedEventHandled);

			// Raise the event of Morgause entering the forest
			Character morgauseCharacter = dialogueData.CharacterData.testCharacters.Get(CharacterData.MorgauseId);
			morgauseCharacter.EntersScene(SceneData.SceneForestId);

			// Check that dialogue is not played
			Assert.IsFalse(playStartedEventHandled);
			Assert.IsFalse(playFinishedEventHandled);

			// Raise the event of Morgause entering the bar
			morgauseCharacter.EntersScene(SceneData.SceneBarId);

			// Check that dialogue is played
			Assert.IsTrue(playStartedEventHandled);
			Assert.IsTrue(playFinishedEventHandled);
		}

		private void PlayStarted(object sender, Business.Event.Args.DialogueItemEventArgs e)
		{
			playStartedEventHandled = true;
		}

		private void PlayFinished(object sender, Business.Event.Args.DialogueItemEventArgs e)
		{
			playFinishedEventHandled = true;
		}
	}
}
