namespace Medness.Business.ValueObjects
{
    public class DialogueSessionItem
    {
        public readonly DialogueItem[] dialogueItems;

        public DialogueSessionItem(string[] dialogues)
        {
            ArgumentNullException.ThrowIfNull(dialogues, nameof(dialogues));
            dialogueItems = new DialogueItem[dialogues.Length];
            Array.Copy(dialogues, dialogueItems, dialogues.Length);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is DialogueSessionItem itemObj)
            {
                if (itemObj.dialogueItems.Length != dialogueItems.Length)
                    return false;
                bool ret = true;
                for (int itemIdx = 0; itemIdx < dialogueItems.Length; itemIdx++)
                    ret = ret && dialogueItems[itemIdx].Equals(itemObj.dialogueItems[itemIdx]);
                return ret;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (DialogueItem item in dialogueItems)
                hash ^= item.GetHashCode();
            return hash;
        }

    }
}
