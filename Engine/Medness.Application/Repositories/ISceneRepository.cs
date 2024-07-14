using Medness.Business.Entities;

namespace Medness.Application.Interfaces
{
	public interface ISceneRepository
	{
		public void Add(Scene Scene);

		public void Remove(Scene Scene);

		public Scene Get(Guid id);

		public IEnumerable<Scene> Get(string name);
	}
}
