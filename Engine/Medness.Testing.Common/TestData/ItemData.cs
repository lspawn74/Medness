using Medness.Business.Entities;
using System;
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
				{ RopeName,  new Item(Guid.NewGuid(), RopeName ) },
				{ KeyName,  new Item( Guid.NewGuid(), KeyName ) },
				{ AlcoholGlassName , new Item(Guid.NewGuid(), AlcoholGlassName) },
			};
		}
		#endregion

		#region Arguments test data
		public static IEnumerable<object[]> GetItemsArgs()
		{
			yield return new object[] { Guid.NewGuid(), RopeName };
			yield return new object[] { Guid.NewGuid(), KeyName };
			yield return new object[] { Guid.NewGuid(), AlcoholGlassName };
		}
		#endregion
	}
}
