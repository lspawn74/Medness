using Medness.Business.Interfaces;
using Medness.Business.ValueObjects;

namespace Medness.Business.Resources
{
	public static class Results
	{
		public static readonly IResult Success = new Result(nameof(Errors.ERR_SUCCESS));
		public static readonly IResult ErrorNullPlayer = new Result(nameof(Errors.ERR_NULL_PLAYER));
		public static readonly IResult ErrorNullScene = new Result(nameof(Errors.ERR_NULL_SCENE));
		public static readonly IResult ErrorNullCharacter = new Result(nameof(Errors.ERR_NULL_CHARACTER));
		public static readonly IResult ErrorNullItem = new Result(nameof(Errors.ERR_NULL_ITEM));
		public static readonly IResult ErrorUnknownId = new Result(nameof(Errors.ERR_UNKNOWN_ID));
	}
}
