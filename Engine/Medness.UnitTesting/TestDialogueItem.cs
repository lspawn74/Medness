using Medness.Business.ValueObjects;
using System;

namespace Medness.UnitTesting
{
	[TestClass]
	public class TestDialogueItem
	{
		[TestInitialize]
		public void Initialize()
		{

		}

		[TestMethod]
		public void TestDialogueItemNull()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(null, "test"));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem("test", null));
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueItem(null, null));
		}
	}
}
