using Medness.Business.Entities;

namespace Medness.Business.Event.Args
{
	public class DialogueItemEventArgs : EventArgs
    {
        public DialogueItem DialogueItem { get; set; }

        public DialogueItemEventArgs(DialogueItem dialogueItem)
        {
            DialogueItem = dialogueItem;
        }
    }
}
