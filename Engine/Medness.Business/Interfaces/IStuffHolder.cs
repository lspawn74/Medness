using Medness.Business.Entities;

namespace Medness.Business.Interfaces
{
	public interface IStuffHolder
	{
		bool Holds(Item item);

		void AcquireStuff(Item item);
	}
}
