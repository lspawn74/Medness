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
				() => new Character(Guid.NewGuid(), null, true));
		}

		[TestMethod]
		public void TestCharacterEquality()
		{
			Guid commonId = Guid.NewGuid();
			Character character1 = new Character(commonId, "char1", true);
			Character character2 = new Character(commonId, "char2", false);
			Assert.AreEqual(character1, character2);
		}

		[TestMethod]
		public void TestCharacterInequality()
		{
			Assert.AreNotEqual(
				characterData.testCharacters[CharacterData.AnsgardeName],
				characterData.testCharacters[CharacterData.AldemareName]);
		}

		[TestMethod]
		public void TestCharacterPlayablility()
		{
			Assert.IsTrue(characterData.testCharacters[CharacterData.AnsgardeName].isPlayable.Equals(true));
			Assert.IsFalse(characterData.testCharacters[CharacterData.BarTenderName].isPlayable.Equals(true));
		}

		[TestMethod]
		public void TestCharacterScene()
		{
			Guid sceneGuid = Guid.NewGuid();
			characterData.testCharacters[CharacterData.AnsgardeName].EntersScene(sceneGuid);
			Assert.IsTrue(characterData.testCharacters[CharacterData.AnsgardeName].IsInScene(sceneGuid));
		}
	}
}
