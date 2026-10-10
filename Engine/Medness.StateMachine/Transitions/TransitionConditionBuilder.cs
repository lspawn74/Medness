using Medness.StateMachine.GameVariables;

namespace Medness.StateMachine.Transitions
{
	public class TransitionConditionBuilder
	{
		private TransitionConditionCombo _conditionCombo;

		public TransitionConditionBuilder()
		{
			_conditionCombo = new TransitionConditionCombo();
		}

		public TransitionConditionBuilder FirstCondition(GameVariableInt var, int value)
		{
			_conditionCombo._conditions.Add(
				new TransitionConditionCompareToInt(
					TransitionConditionRelationalOperator.NOTHING,
					var,
					value)
				);
			return this;
		}

		public TransitionConditionBuilder FirstCondition(GameVariableString var, string value)
		{
			_conditionCombo._conditions.Add(
				new TransitionConditionCompareToString(
					TransitionConditionRelationalOperator.NOTHING,
					var,
					value)
				);
			return this;
		}

		public TransitionConditionBuilder OrCondition(GameVariableInt var, int value)
		{
			_conditionCombo._conditions.Add(
				new TransitionConditionCompareToInt(
					TransitionConditionRelationalOperator.OR,
					var,
					value)
				);
			return this;
		}

		public TransitionConditionBuilder OrCondition(GameVariableString var, string value)
		{
			_conditionCombo._conditions.Add(
				new TransitionConditionCompareToString(
					TransitionConditionRelationalOperator.OR,
					var,
					value)
				);
			return this;
		}

		public TransitionConditionBuilder AndCondition(GameVariableInt var, int value)
		{
			_conditionCombo._conditions.Add(
				new TransitionConditionCompareToInt(
					TransitionConditionRelationalOperator.AND,
					var,
					value)
				);
			return this;
		}

		public TransitionConditionBuilder AndCondition(GameVariableString var, string value)
		{
			_conditionCombo._conditions.Add(
				new TransitionConditionCompareToString(
					TransitionConditionRelationalOperator.AND,
					var,
					value)
				);
			return this;
		}

		public TransitionConditionCombo Build()
		{
			return _conditionCombo;
		}
	}
}
