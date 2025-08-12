namespace Medness.Business.Interfaces
{
	/// <summary>
	/// This interface describes the result of an operation.  
	/// </summary>
	public interface IResult
	{
		/// <summary>
		/// The value of the result.
		/// </summary>
		string Value { get; }

		/// <summary>
		/// A flag indicating if the result is a success or if an error happened.
		/// </summary>
		bool IsSuccess { get; }

		/// <summary>
		/// The error message (if any)
		/// </summary>
		string ErrorMessage { get; }

		/// <summary>
		/// The stack trace locating where an error happened (if any).
		/// </summary>
		string StackTrace {  get; }
	}
}
