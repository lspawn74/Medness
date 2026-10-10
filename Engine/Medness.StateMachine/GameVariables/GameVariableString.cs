namespace Medness.StateMachine.GameVariables
{
	public  class GameVariableString : GameVariable
	{
		public string Value { get; }

		public GameVariableString(string name, string value) : base(name)
		{
			Value = value;
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is string sObj)
				return Value == sObj;
			return false;
		}
	}
}
