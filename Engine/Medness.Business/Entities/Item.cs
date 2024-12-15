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
			holder = newHolder;
			OnMoved();
		}

		public IStuffHolder GetHolder()
		{
			return holder;
		}
		#endregion

		#region Events
		public event EventHandler<ItemEventArgs> Moved;
		private void OnMoved()
		{
			Moved?.Invoke(this, new ItemEventArgs(this));
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
