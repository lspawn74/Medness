using Medness.Business.Event.Args;
using Medness.Business.Interfaces;

namespace Medness.Business.Entities
{
	public class Item
	{
		public readonly string id;
		public readonly string name;
		private IStuffHolder holder;

		public Item(string identity, string itemName)
		{
			ArgumentNullException.ThrowIfNull(itemName, nameof(itemName));
			id = identity;
			name = itemName;
		}

		#region Actions
		public void MoveTo(IStuffHolder newHolder)
		{
			ArgumentNullException.ThrowIfNull(newHolder, nameof(newHolder));
			IStuffHolder previousHolder = holder;
			holder = newHolder;
			OnMoved(previousHolder, newHolder);
		}

		public void Use(Scene scene)
		{
			OnUsed(scene);
		}

		public void Use(Item destinationItem)
		{
			OnUsed(destinationItem);
		}

		public IStuffHolder GetHolder()
		{
			return holder;
		}
		#endregion

		#region Events
		public event EventHandler<ItemMoveEventArgs> Moved;
		private void OnMoved(IStuffHolder previousHolder, IStuffHolder newHolder)
		{
			Moved?.Invoke(this, new ItemMoveEventArgs(this, previousHolder, newHolder));
		}

		public event EventHandler<ItemUsedEventArgs> Used;
		private void OnUsed(Scene scene)
		{
			Used?.Invoke(this, new ItemUsedEventArgs(this, holder, scene));
		}
		private void OnUsed(Item destinationItem)
		{
			Used?.Invoke(this, new ItemUsedEventArgs(this, holder, destinationItem));
		}
		#endregion

		#region Equality
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (obj is Item itemObj)
				return itemObj.id == id;

			return false;
		}

		public override int GetHashCode()
		{
			return id.GetHashCode();
		}
		#endregion
	}
}
