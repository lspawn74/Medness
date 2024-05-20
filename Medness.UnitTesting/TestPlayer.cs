using Medness.Business.Entities;
using Medness.Business.Enums;

namespace Medness.UnitTesting
{
	[TestClass]
	public class TestPlayer
	{
		[TestMethod]
		public void TestPlayerEquals()
		{
			Player player1 = new Player(PlayerIdentity.Computer);
			Player player2 = new Player(PlayerIdentity.Computer);
			Assert.AreEqual(player1, player2);
		}

		[TestMethod]
		public void TestPlayerNotEquals()
		{
			Player player1 = new Player(PlayerIdentity.Computer);
			Player player2 = new Player(PlayerIdentity.Human);
			Assert.AreNotEqual(player1, player2);
		}
	}
}