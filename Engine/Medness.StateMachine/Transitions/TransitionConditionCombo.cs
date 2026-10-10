namespace Medness.StateMachine.Transitions
{
	public class TransitionConditionCombo
    {
        internal List<TransitionConditionCompareToConst> _conditions { get; } = [];

        public bool Execute()
        {
            bool result = false;
            foreach (var _condition in _conditions)
            {
                switch (_condition.RelationalOperator)
                {
                    case TransitionConditionRelationalOperator.NOTHING:
                        result = _condition.Execute();
                        break;
                    case TransitionConditionRelationalOperator.OR:
                        result |= _condition.Execute();
                        break;
                    case TransitionConditionRelationalOperator.AND:
                        result &= _condition.Execute();
                        break;
                }
            }
            return result;
        }
	}
}
