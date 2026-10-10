using Medness.StateMachine.GameVariables;

namespace Medness.StateMachine.Transitions
{
    internal class TransitionConditionCompareToString : TransitionConditionCompareToConst
	{
		private GameVariableString _operand1;
		private readonly string _operand2;
		
		internal TransitionConditionCompareToString(GameVariableString operand1, string operand2)
		{
			_operand1 = operand1;
			_operand2 = operand2;
		}

		internal TransitionConditionCompareToString(TransitionConditionRelationalOperator op, GameVariableString operand1, string operand2) : this(operand1, operand2)
		{
			RelationalOperator = op;
		}

		internal override bool Execute()
		{
			return _operand1.Value == _operand2;
		}
	}
}
