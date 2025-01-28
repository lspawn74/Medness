using Medness.Business.Enums;

namespace Medness.Business.ValueObjects
{
	public class DialogueTrigger
	{
		public readonly string objectId = string.Empty;

		public readonly string argument1Id = string.Empty;
		public readonly string argument2Id = string.Empty;

		public readonly DialogueItemTriggerType type;

		public DialogueTrigger(string object_id, DialogueItemTriggerType trigger_type)
		{
			ArgumentNullException.ThrowIfNull(object_id);
			ArgumentNullException.ThrowIfNull(trigger_type);

			objectId = object_id;
			type = trigger_type;
		}

		public DialogueTrigger(string object_id, string argument_id, DialogueItemTriggerType trigger_type)
			: this(object_id, trigger_type)
		{
			ArgumentNullException.ThrowIfNull(argument_id);

			argument1Id = argument_id;
		}

		public DialogueTrigger(string object_id, string argument1_id, string argument2_id, DialogueItemTriggerType trigger_type):
			this(object_id, argument1_id, trigger_type)
		{
			ArgumentNullException.ThrowIfNull(argument2_id);

			argument2Id = argument2_id;
		}
	}
}
