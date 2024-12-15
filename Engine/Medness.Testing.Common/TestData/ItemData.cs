using Medness.Business.Entities;
using System.Collections.Generic;

namespace Medness.Testing.Common.TestData
{
	public class ItemData
	{
		#region Constants
		public const string RopeName = "Corde";
		public const string KeyName = "Clé";
		public const string AlcoholGlassName = "Verre d'alcool";
		#endregion

		#region Objects test data
		public Dictionary<string, Item> testItems;

		public ItemData()
		{
			testItems = new Dictionary<string, Item>
			{
				{ RopeName,  new Item("ROPE", RopeName ) },
				{ KeyName,  new Item( "KEY", KeyName ) },
				{ AlcoholGlassName , new Item("ALCOHOL", AlcoholGlassName) },
			};
		}
		#endregion

		#region Arguments test data
		public static IEnumerable<object[]> GetItemsArgs()
		{
			yield return new object[] { "ROPE", RopeName };
			yield return new object[] { "KEY", KeyName };
			yield return new object[] { "ALCOHOL", AlcoholGlassName };
		}
		#endregion
	}
}
