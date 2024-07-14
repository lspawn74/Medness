using Medness.Business.Entities;
using Medness.Testing.Common.TestData;
using System;

namespace Medness.UnitTesting
{
	[TestClass]
	public class TestItem
	{
		ItemData itemData;

		[TestInitialize]
		public void Initialize()
		{
			itemData = new ItemData();
		}

		[TestMethod]
		public void TestItemNull()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new Item(Guid.NewGuid(), null));
		}

		[TestMethod]
		public void TestItemEquality()
		{
			Guid commonId = Guid.NewGuid();
			Item Item1 = new Item(commonId, "item1");
			Item Item2 = new Item(commonId, "item2");
			Assert.AreEqual(Item1, Item2);
		}

		[TestMethod]
		public void TestItemInequality()
		{
			Assert.AreNotEqual(
				itemData.testItems[ItemData.RopeName],
				itemData.testItems[ItemData.KeyName]);
		}
	}
}
