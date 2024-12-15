using Medness.Business.Entities;

namespace Medness.Business.Interfaces
{
	public interface ISceneRepository
	{
		public void Add(Scene Scene);

		public Scene Get(string id);
	}
}
