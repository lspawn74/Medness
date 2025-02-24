﻿using Medness.Business.Entities;
using Medness.Business.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Medness.Testing.Common.Repositories
{
	public class SceneRepository : IRepository<Scene>
	{
		private Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>();

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

		public Scene Get(string id)
		{
			if (_scenes.TryGetValue(id, out Scene scene))
				return scene;
			return null;
		}

		public IEnumerator<Scene> GetEnumerator()
		{
			return _scenes.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
