using Medness.Business.Entities;

namespace Medness.Business.Event.Args
{
	public class ItemEventArgs : EventArgs
	{
		public Item Item { get; set; }

		public ItemEventArgs(Item item)
		{
			Item = item;
		}
	}
}
