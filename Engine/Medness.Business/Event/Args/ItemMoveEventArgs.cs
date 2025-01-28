using Medness.Business.Entities;
using Medness.Business.Interfaces;

namespace Medness.Business.Event.Args
{
	public class ItemMoveEventArgs
	{
		public Item Item { get; set; }

		public IStuffHolder Source { get; set; }

		public IStuffHolder Destination { get; set; }

		public ItemMoveEventArgs(Item item, IStuffHolder source, IStuffHolder destination)
		{
			Item = item;
			Destination = destination;
			Source = source;
		}
	}
}
