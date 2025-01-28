using Medness.Business.Entities;

namespace Medness.Business.Interfaces
{
	public interface IStuffHolder
	{
		string id { get; }

		bool Holds(Item item);

		void AcquireStuff(Item item);
	}
}
