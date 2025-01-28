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
		CharacterData characterData;

		[TestInitialize]
		public void Initialize()
		{
			gameData = new GameData();
			characterData = new CharacterData();
		}

		[TestMethod]
		public void TestDialogueItemNull()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				null,
				characterData.testCharacters[CharacterData.AnsgardeName],
				new List<DialogueTrigger>(),
				gameData.testGame.itemRepository,
				gameData.testGame.characterRepository,
				gameData.testGame.sceneRepository,
				gameData.testGame.dialogueItemRepository
				));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				null,
				new List<DialogueTrigger>(),
				gameData.testGame.itemRepository,
				gameData.testGame.characterRepository,
				gameData.testGame.sceneRepository,
				gameData.testGame.dialogueItemRepository
				));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				characterData.testCharacters[CharacterData.AnsgardeName],
				null,
				gameData.testGame.itemRepository,
				gameData.testGame.characterRepository,
				gameData.testGame.sceneRepository,
				gameData.testGame.dialogueItemRepository
				));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				characterData.testCharacters[CharacterData.AnsgardeName],
				new List<DialogueTrigger>(),
				null,
				gameData.testGame.characterRepository,
				gameData.testGame.sceneRepository,
				gameData.testGame.dialogueItemRepository
				));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				characterData.testCharacters[CharacterData.AnsgardeName],
				new List<DialogueTrigger>(),
				gameData.testGame.itemRepository,
				null,
				gameData.testGame.sceneRepository,
				gameData.testGame.dialogueItemRepository
				));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				characterData.testCharacters[CharacterData.AnsgardeName],
				new List<DialogueTrigger>(),
				gameData.testGame.itemRepository,
				gameData.testGame.characterRepository,
				null,
				gameData.testGame.dialogueItemRepository
				));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				characterData.testCharacters[CharacterData.AnsgardeName],
				new List<DialogueTrigger>(),
				gameData.testGame.itemRepository,
				gameData.testGame.characterRepository,
				gameData.testGame.sceneRepository,
				null
				));
		}
	}
}
