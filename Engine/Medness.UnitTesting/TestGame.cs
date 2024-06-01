using Medness.Business.Entities;

namespace Medness.UnitTesting
{
	[TestClass]
	public class TestGame
	{
		[TestMethod]
		[DataRow(null)]
		public void TestGameNull(Player player)
		{
			Assert.ThrowsException<ArgumentNullException>(() => new Game(player));
		}
	}
}
