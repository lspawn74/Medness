using Medness.Business.Entities;

namespace Medness.Business.ValueObjects
{
	public class IsPlayable
	{
		private bool _isPlayableValue;

		public IsPlayable(bool value)
		{
			_isPlayableValue = value;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as IsPlayable);
		}

		public bool Equals(IsPlayable other)
		{
			return other != null && other._isPlayableValue == _isPlayableValue;
		}

		public bool Equals(bool value)
		{
			return _isPlayableValue == value;
		}

		public override int GetHashCode()
		{
			return _isPlayableValue.GetHashCode();
		}
	}
}
