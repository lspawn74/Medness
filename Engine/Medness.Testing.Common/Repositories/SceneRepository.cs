using Medness.Application.Interfaces;
using Medness.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Medness.Testing.Common.Repositories
{
	public class SceneRepository : ISceneRepository
	{
		private Dictionary<Guid, Scene> _scenes = new Dictionary<Guid, Scene>();

		public void Add(Scene scene)
		{
			ArgumentNullException.ThrowIfNull(scene, nameof(scene));
			_scenes[scene.id] = scene;
		}

		public void Remove(Scene scene)
		{
			ArgumentNullException.ThrowIfNull(scene, nameof(scene));
			_scenes.Remove(scene.id);
		}

		public Scene Get(Guid id)
		{
			if (_scenes.TryGetValue(id, out Scene scene))
				return scene;
			return null;
		}

		public IEnumerable<Scene> Get(string name)
		{
			return _scenes.Where(x => x.Value.name == name)?.Select(x => x.Value);
		}
	}
}
