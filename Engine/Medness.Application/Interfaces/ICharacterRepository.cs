using Medness.Business.Entities;

namespace Medness.Application.Interfaces
{
	public interface ICharacterRepository
	{
		public void Add(Character character);

		public void Remove(Character character);

		public Character Get(Guid id);

		public IEnumerable<Character> Get(string name);
	}
}
