using Medness.Business.Entities;

namespace Medness.Business.Interfaces
{
	public interface IDialogueItemRepository
	{
		/// <summary>
		///		Adds a dialogue item into the repository.
		/// </summary>
		/// <param name="item">The item to add.</param>
		void Add(DialogueItem item);

		/// <summary>
		///		Gets a dialogue item from the repository.
		/// </summary>
		/// <param name="id">The id of the item to get.</param>
		DialogueItem Get(string id);
	}
}
