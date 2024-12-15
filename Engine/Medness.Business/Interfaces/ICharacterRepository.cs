using Medness.Business.Entities;

namespace Medness.Business.Interfaces
{
	public interface ICharacterRepository
	{
		public void Add(Character character);

		public Character Get(string id);
	}
}
