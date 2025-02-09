using Medness.Business.Entities;
using Medness.Testing.Common.Repositories;
using System.Collections.Generic;

namespace Medness.Testing.Common.TestData
{
	public class ItemData
	{
		#region Constants
		public const string RopeId = "ITEM_ROPE";
		public const string KeyId = "ITEM_KEY";
		public const string AlcoholId = "ITEM_ALCOHOL";
		public const string RopeName = "Corde";
		public const string KeyName = "Clé";
		public const string AlcoholGlassName = "Verre d'alcool";
		#endregion

		#region Objects test data
		public ItemRepository testItems;

		public ItemData()
		{
			testItems = new ItemRepository();
			testItems.Add(new Item(RopeId, RopeName));
			testItems.Add(new Item(KeyId, KeyName));
			testItems.Add(new Item(AlcoholId, AlcoholGlassName));
		}
		#endregion

		#region Arguments test data
		public static IEnumerable<object[]> GetItemsArgs()
		{
			yield return new object[] { RopeId, RopeName };
			yield return new object[] { KeyId, KeyName };
			yield return new object[] { AlcoholId, AlcoholGlassName };
		}
		#endregion
	}
}
