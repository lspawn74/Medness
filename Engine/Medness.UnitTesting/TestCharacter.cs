using Medness.Business.Entities;
using System.ComponentModel.Design;

namespace Medness.UnitTesting
{
	[TestClass]
	public class TestCharacter
	{
		private const string _ansgardeName = "Ansgarde";
		private const string _aldemareName = "Aldemare";
		private const string _robinName = "Robin";
		private const string _morgauseName = "Morgause";
		private const string _npcName = "NPC";
		private Dictionary<string, Character> _characters = new Dictionary<string, Character>
		{
			{ _ansgardeName,  new Character(Guid.NewGuid(), _ansgardeName, true ) },
			{ _aldemareName,  new Character( Guid.NewGuid(), _aldemareName, true ) },
			{ _robinName,  new Character(Guid.NewGuid(), _robinName, true) },
			{ _morgauseName,  new Character(Guid.NewGuid(), _morgauseName, true) },
			{ _npcName,  new Character(Guid.NewGuid(), _npcName, false) }
		};

		[TestInitialize]
		public void Init()
		{

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
			Assert.IsTrue(character1.Equals(character2));
		}

		[TestMethod]
		public void TestCharacterInequality()
		{
			Assert.IsFalse(_characters[_ansgardeName].Equals(_characters[_aldemareName]));
		}

		[TestMethod]
		public void TestCharacterPlayablility()
		{
			Assert.IsTrue(_characters[_ansgardeName].isPlayable.Equals(true));
			Assert.IsFalse(_characters[_npcName].isPlayable.Equals(true));
		}
	}
}
