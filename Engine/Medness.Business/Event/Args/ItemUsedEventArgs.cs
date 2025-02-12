using Medness.Business.Entities;
using Medness.Business.Interfaces;

namespace Medness.Business.Event.Args
{
	public class ItemUsedEventArgs : EventArgs
	{
		public Item Item { get; set; }

		public IStuffHolder User { get; set; }

		public Item DestinationItem { get; set; }

		public Scene Scene { get; set; }
		

		public ItemUsedEventArgs(Item item, IStuffHolder user, Item destinationItem)
		{
			Item = item;
			User = user;
			DestinationItem = destinationItem;
		}

		public ItemUsedEventArgs(Item item, IStuffHolder user, Scene scene)
		{
			Item = item;
			User = user;
			Scene = scene;
		}
	}
}
