using Medness.Business.Entities;
using Medness.Business.ValueObjects;
using Medness.Testing.Common.TestData;
using System;
using System.Collections.Generic;

namespace Medness.UnitTesting
{
	[TestClass]
	public class TestDialogueItem
	{
		GameData gameData;

		[TestInitialize]
		public void Initialize()
		{
			gameData = new GameData();
		}

		[TestMethod]
		public void TestDialogueItemNull()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				null,
				new List<DialogueTrigger>(),
				gameData.testGame.itemRepository,
				gameData.testGame.characterRepository,
				gameData.testGame.sceneRepository,
				gameData.testGame.dialogueItemRepository
				));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				null,
				gameData.testGame.itemRepository,
				gameData.testGame.characterRepository,
				gameData.testGame.sceneRepository,
				gameData.testGame.dialogueItemRepository
				));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				new List<DialogueTrigger>(),
				null,
				gameData.testGame.characterRepository,
				gameData.testGame.sceneRepository,
				gameData.testGame.dialogueItemRepository
				));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				new List<DialogueTrigger>(),
				gameData.testGame.itemRepository,
				null,
				gameData.testGame.sceneRepository,
				gameData.testGame.dialogueItemRepository
				));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				new List<DialogueTrigger>(),
				gameData.testGame.itemRepository,
				gameData.testGame.characterRepository,
				null,
				gameData.testGame.dialogueItemRepository
				));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				new List<DialogueTrigger>(),
				gameData.testGame.itemRepository,
				gameData.testGame.characterRepository,
				gameData.testGame.sceneRepository,
				null
				));
		}
	}
}
