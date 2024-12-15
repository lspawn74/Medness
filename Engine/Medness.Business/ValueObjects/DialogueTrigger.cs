using Medness.Business.Entities;
using Medness.Business.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace Medness.Business.ValueObjects
{
	public class DialogueTrigger
	{
		public readonly string objectId = string.Empty;

		public readonly string argumentId = string.Empty;

		public readonly DialogueItemTriggerType type;

		public DialogueTrigger(string object_id, string argument_id, DialogueItemTriggerType trigger_type)
		{
			ArgumentNullException.ThrowIfNull(object_id);
			ArgumentNullException.ThrowIfNull(argument_id);
			ArgumentNullException.ThrowIfNull(trigger_type);

			objectId = object_id;
			argumentId = argument_id;
			type = trigger_type;
		}

		public DialogueTrigger(string object_id, DialogueItemTriggerType trigger_type)
		{
			ArgumentNullException.ThrowIfNull(object_id);
			ArgumentNullException.ThrowIfNull(trigger_type);

			objectId = object_id;
			type = trigger_type;
		}
	}
}
