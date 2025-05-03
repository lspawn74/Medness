using Medness.Business.ValueObjects;

namespace Medness.UnitTesting
{
	[TestClass]
	public class TestResultManagement
	{
		[TestMethod]
		public void TestResult()
		{
			// Checks the behaviour of result when an inexisting error code is set in argument
			const string errorCodeNotExisting = "NOT_AN_EXISTING_ERROR";
			Result result = new Result(errorCodeNotExisting);
			Assert.AreEqual(result.Value, errorCodeNotExisting);
			Assert.IsFalse(result.IsSuccess);
			Assert.IsTrue(result.StackTrace is not null);

			// Check the behaviour of result in case of success
			const string errorCodeSuccess = "ERR_SUCCESS";
			result = new Result(errorCodeSuccess);
			Assert.AreEqual(result.Value, errorCodeSuccess);
			Assert.IsTrue(result.IsSuccess);
			Assert.IsNull(result.StackTrace);

			// Check the behaviour of result in case of error
			const string errorCode = "ERR_NULL_SCENE";
			result = new Result(errorCode);
			Assert.AreEqual(result.Value, errorCode);
			Assert.IsFalse(result.IsSuccess);
			Assert.IsTrue(result.StackTrace is not null);
		}
	}
}
