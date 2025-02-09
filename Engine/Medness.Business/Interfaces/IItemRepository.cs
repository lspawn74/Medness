using Medness.Business.Entities;

namespace Medness.Business.Interfaces
{
	public interface IItemRepository : IRepository<Item>
	{
		/// <summary>
		///		Gets all items of an items holder (a scene or a character).
		/// </summary>
		/// <param name="holder">The holder of the items to get.</param>
		IEnumerable<Item> GetAll(IStuffHolder holder);
	}
}
