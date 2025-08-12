using Medness.Business.Entities;
using Medness.Business.Interfaces;
using Medness.Business.Resources;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Medness.Testing.Common.Repositories
{
	/// <summary>Represents the repository containing scenes of the game.</summary>
	public class SceneRepository : IRepository<Scene>
	{
		#region Private fields
		/// <summary>The scenes are stored in an internal dictionary.</summary>
		private Dictionary<string, Scene> _scenes = new Dictionary<string, Scene>();
		#endregion

		#region IRepository implementation
		/// <summary>
		///		Adds a scene into the repository.
		/// </summary>
		/// <param name="scene">The scene to add.</param>
		public void Add(Scene scene)
		{
			ArgumentNullException.ThrowIfNull(scene, nameof(scene));
			_scenes[scene.id] = scene;
		}

		/// <summary>
		///		Gets a scene from the repository.
		/// </summary>
		/// <param name="id">The id of the scene to get.</param>
		public Scene Get(string id)
		{
			if (_scenes.TryGetValue(id, out Scene scene))
				return scene;
			return null;
		}

		/// <summary>
		///		Checks for the existence of a scene in the repository.
		/// </summary>
		/// <param name="id">The id of the scene to check.</param>
		/// <returns>A <see cref="IResult"/> object with a flag <see cref="IResult.ISuccess"/>
		/// set to <see langword="true"/> if the scene exists in the repository. And set to
		/// <see langword="false"/> otherwise.</returns>
		public IResult Contains(string id)
		{
			if (_scenes.ContainsKey(id))
				return Results.Success;
			return Results.ErrorUnknownId;
		}
		#endregion

		#region IEnumerable implementation
		/// <summary>
		/// Exposes the enumerator, which supports a simple iteration over a collection of <see cref="Scene"> type.
		/// </summary>
		public IEnumerator<Scene> GetEnumerator()
		{
			return _scenes.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		#endregion
	}
}
