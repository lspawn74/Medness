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
		CharacterData characterData;

		[TestInitialize]
		public void Initialize()
		{
			characterData = new CharacterData();
		}

		[TestMethod]
		public void TestDialogueItemNull()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				null,
				characterData.testCharacters.Get(CharacterData.AnsgardeId),
				new List<DialogueTrigger>()));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				null,
				new List<DialogueTrigger>()));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(
				"Test",
				characterData.testCharacters.Get(CharacterData.AnsgardeId),
				null));
		}
	}
}
