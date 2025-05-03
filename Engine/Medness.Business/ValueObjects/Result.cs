using Medness.Business.Interfaces;
using Medness.Business.Resources;

namespace Medness.Business.ValueObjects
{
	/// <summary>
	/// Describes the result of a call to a method.
	/// </summary>
	public class Result : IResult
	{
		/// <summary>
		/// The value of the result.
		/// </summary>
		public string Value { get; }

		/// <summary>
		/// A flag indicating if the result is a success or if an error happened.
		/// </summary>
		public bool IsSuccess { get; }


		/// <summary>
		/// The error message (if any)
		/// </summary>
		public string ErrorMessage { get; }

		/// <summary>
		/// The stack trace locating where an error happened (if any).
		/// </summary>
		public string StackTrace { get; }

		/// <summary>
		/// Creates a new instance of class <see cref="Result"/>.
		/// </summary>
		/// <param name="value">The value of the result.</param>
		/// <remarks>If value corresponds to en error code in resources, the error message is setup.</remarks>
		public Result(string value)
		{
			ArgumentNullException.ThrowIfNull(value, nameof(value));

			Value = value;
			ErrorMessage = Errors.ResourceManager.GetString(value) ?? $"Unknown error code {value}";
			IsSuccess = string.Equals(Value, nameof(Errors.ERR_SUCCESS), StringComparison.OrdinalIgnoreCase);
			if (!IsSuccess)
			{
				StackTrace = Environment.StackTrace;
			}
		}

		/// <summary>
		/// Creates a new instance of class <see cref="Result"/>.
		/// </summary>
		/// <param name="value">The value of the result.</param>
		/// <remarks>If value corresponds to en error code in resources, the error message is setup.</remarks>
		public Result(string value, string errorMessage)
		{
			ArgumentNullException.ThrowIfNull(value, nameof(value));
			ArgumentNullException.ThrowIfNull(errorMessage, nameof(errorMessage));

			Value = value;
			ErrorMessage = errorMessage;
			IsSuccess = string.Equals(Value, nameof(Errors.ERR_SUCCESS), StringComparison.OrdinalIgnoreCase);
			if (!IsSuccess)
			{
				StackTrace = Environment.StackTrace;
			}
		}
	}
}
