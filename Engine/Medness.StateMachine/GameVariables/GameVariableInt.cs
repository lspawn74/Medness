namespace Medness.StateMachine.GameVariables
{
	public class GameVariableInt : GameVariable
	{
		public int Value { get; }

		public GameVariableInt(string name, int value) : base(name)
		{
			Value = value;
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is int iObj)
				return Value == iObj;
			return false;
		}
	}
}
