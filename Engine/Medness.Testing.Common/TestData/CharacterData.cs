using Medness.Business.Entities;
using Medness.Testing.Common.Repositories;
using System.Collections.Generic;

namespace Medness.Testing.Common.TestData
{
	public class CharacterData
	{
		#region Constants
		public const string AnsgardeId = "CH_ANSGARDE";
		public const string AldemareId = "CH_ALDEMARE";
		public const string RobinId = "CH_ROBIN";
		public const string MorgauseId = "CH_MORGAUSE";
		public const string BarTenderId = "CH_BARTENDER";
		public const string AnsgardeName = "Ansgarde";
		public const string AldemareName = "Aldemare";
		public const string RobinName = "Robin";
		public const string MorgauseName = "Morgause";
		public const string BarTenderName = "Bar Tender";
		#endregion

		#region Objects test data
		public CharacterRepository testCharacters;

		public CharacterData()
		{
			testCharacters = new CharacterRepository();
			testCharacters.Add(new Character(AnsgardeId, AnsgardeName, true));
			testCharacters.Add(new Character(AldemareId, AldemareName, true));
			testCharacters.Add(new Character(RobinId, RobinName, true));
			testCharacters.Add(new Character(MorgauseId, MorgauseName, true));
			testCharacters.Add(new Character(BarTenderId, BarTenderName, false));
		}
		#endregion

		#region Arguments test data
		public static IEnumerable<object[]> GetCharactersArgs()
		{
			yield return new object[] { AnsgardeId, AnsgardeName, true };
			yield return new object[] { AldemareId, AldemareName, true };
			yield return new object[] { RobinId, RobinName, true };
			yield return new object[] { MorgauseId, MorgauseName, true };
			yield return new object[] { BarTenderId, BarTenderName, false };
		}
		#endregion
	}
}
