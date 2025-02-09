using Medness.Business.Entities;
using Medness.Testing.Common.TestData;
using System;

namespace Medness.UnitTesting
{
	[TestClass]
	public class TestCharacter
	{
		CharacterData characterData;

		[TestInitialize]
		public void Initialize()
		{
			characterData = new CharacterData();
		}

		[TestMethod]
		public void TestCharacterNull()
		{
			Assert.ThrowsException<ArgumentNullException>(
				() => new Character("TEST_ID", null, true));
		}

		[TestMethod]
		public void TestCharacterEquality()
		{
			string commonId = "TEST_ID";
			Character character1 = new Character(commonId, "char1", true);
			Character character2 = new Character(commonId, "char2", false);
			Assert.AreEqual(character1, character2);
		}

		[TestMethod]
		public void TestCharacterInequality()
		{
			Assert.AreNotEqual(
				characterData.testCharacters.Get(CharacterData.AnsgardeId),
				characterData.testCharacters.Get(CharacterData.AldemareId));
		}

		[TestMethod]
		public void TestCharacterPlayablility()
		{
			Assert.IsTrue(characterData.testCharacters.Get(CharacterData.AnsgardeId).isPlayable.Equals(true));
			Assert.IsFalse(characterData.testCharacters.Get(CharacterData.BarTenderId).isPlayable.Equals(true));
		}

		[TestMethod]
		public void TestCharacterScene()
		{
			string scenestring = "TEST_ID";
			Character ansgardeCharacter = characterData.testCharacters.Get(CharacterData.AnsgardeId);
			ansgardeCharacter.EntersScene(scenestring);
			Assert.IsTrue(ansgardeCharacter.IsInScene(scenestring));
		}
	}
}
