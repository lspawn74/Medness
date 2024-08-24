using Medness.Business.Repositories;
using Medness.Business.ValueObjects;

namespace Medness.Business.Entities
{
	public class Scene
	{
		public readonly Guid id;
		public readonly string name;
		public readonly IItemRepository items;

		public Scene(Guid identity, string sceneName)
		{
			ArgumentNullException.ThrowIfNull(sceneName, nameof(sceneName));

			id = identity;
			name = sceneName;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (obj is Scene sceneObj)
				return sceneObj.id == id;

			return false;
		}

		public override int GetHashCode()
		{
			return id.GetHashCode();
		}
	}
}
