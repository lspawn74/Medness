using Medness.Application.Entities;
using Medness.Application.Interfaces;
using Medness.Business.Entities;
using Medness.Business.Enums;
using Medness.UnitTesting.Repositories;

namespace Medness.UnitTesting
{
	[TestClass]
	public class TestGame
	{
		#region Test data
		static List<object[]> _gameArguments = new List<object[]>
		{
			new object[] { null, new CharacterRepository() },
			new object[] { new Player(PlayerIdentity.Computer), null },
		};

		private static IEnumerable<object[]> GetTestData()
		{
			yield return _gameArguments[0];
			yield return _gameArguments[1];
		}
		#endregion

		[TestMethod]
		[DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
		public void TestGameNull(Player player, ICharacterRepository characterRepository)
		{
			Assert.ThrowsException<ArgumentNullException>(() => new Game(player, characterRepository));
		}
	}
}
