using Medness.Business.ValueObjects;

namespace Medness.Business.Event.Args
{
	public class DialogueTriggerEventArgs
	{
		public DialogueTrigger dialogueTrigger;

		public DialogueTriggerEventArgs(DialogueTrigger dialogue_trigger)
		{
			dialogueTrigger = dialogue_trigger;
		}
	}
}
