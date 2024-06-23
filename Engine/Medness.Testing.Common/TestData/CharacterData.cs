using Medness.Business.Entities;
using System;
using System.Collections.Generic;

namespace Medness.Testing.Common.TestData
{
	public class CharacterData
	{
		#region Constants
		public const string AnsgardeName = "Ansgarde";
		public const string AldemareName = "Aldemare";
		public const string RobinName = "Robin";
		public const string MorgauseName = "Morgause";
		public const string BarTenderName = "Bar Tender";
		#endregion

		#region Objects test data
		public Dictionary<string, Character> testCharacters;

		public CharacterData()
		{
			testCharacters = new Dictionary<string, Character>
			{
				{ AnsgardeName,  new Character(Guid.NewGuid(), AnsgardeName, true ) },
				{ AldemareName,  new Character( Guid.NewGuid(), AldemareName, true ) },
				{ RobinName , new Character(Guid.NewGuid(), RobinName, true) },
				{ MorgauseName,  new Character(Guid.NewGuid(), MorgauseName, true) },
				{ BarTenderName,  new Character(Guid.NewGuid(), BarTenderName, false) }
			};
		}
		#endregion

		#region Arguments test data
		public static IEnumerable<object[]> GetCharactersArgs()
		{
			yield return new object[] { Guid.NewGuid(), AnsgardeName, true };
			yield return new object[] { Guid.NewGuid(), AldemareName, true };
			yield return new object[] { Guid.NewGuid(), RobinName, true };
			yield return new object[] { Guid.NewGuid(), MorgauseName, true };
			yield return new object[] { Guid.NewGuid(), BarTenderName, false };
		}
		#endregion
	}
}
