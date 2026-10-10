namespace Medness.StateMachine.Transitions
{
	internal abstract class TransitionConditionCompareToConst
	{
		internal TransitionConditionRelationalOperator RelationalOperator { get; set; } = TransitionConditionRelationalOperator.NOTHING;
		internal abstract bool Execute();
	}
}
