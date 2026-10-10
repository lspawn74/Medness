using Medness.StateMachine.GameVariables;

namespace Medness.StateMachine.Transitions
{
    internal class TransitionConditionCompareToInt : TransitionConditionCompareToConst
	{
		private GameVariableInt _operand1;
		private readonly int _operand2;
		
		internal TransitionConditionCompareToInt(GameVariableInt operand1, int operand2)
		{
			_operand1 = operand1;
			_operand2 = operand2;
		}

		internal TransitionConditionCompareToInt(TransitionConditionRelationalOperator op, GameVariableInt operand1, int operand2) : this(operand1, operand2)
		{
			RelationalOperator = op;
		}

		internal override bool Execute()
		{
			return _operand1.Value == _operand2;
		}
	}
}
