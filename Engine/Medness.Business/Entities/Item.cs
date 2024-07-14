namespace Medness.Business.Entities
{
	public class Item
	{
		public readonly Guid id;
		public readonly string name;

		public Item(Guid identity, string itemName)
		{
			ArgumentNullException.ThrowIfNull(itemName, nameof(itemName));

			id = identity;
			name = itemName;
		}

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
	}
}
