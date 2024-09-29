using Medness.Business.ValueObjects;
using System;

namespace Medness.UnitTesting
{
	[TestClass]
	internal class TestDialogueSessionItem
	{
		[TestInitialize]
		public void Initialize()
		{

		}

		[TestMethod]
		public void TestDialogueSessionItemNull()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new DialogueSessionItem(null));
		}
	}
}
