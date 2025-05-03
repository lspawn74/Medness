using Medness.Business.Event.Args;
using Medness.Business.Interfaces;
using Medness.Business.Resources;

namespace Medness.Business.Entities
{
	/// <summary>Represents a scene of the game.</summary>
	public class Scene : IStuffHolder
	{
		#region Fields
		/// <summary>Scene's Id (to easily identify it in a file or a repository).</summary>
		/// <remarks>This field is part of the <see cref="IStuffHolder"/> interface.</remarks>
		public string id { get; }

		/// <summary>The scene's name.</summary>
		public readonly string name;
		#endregion

		#region Constructor
		/// <summary>Creates a new instance of class <see cref="Scene"/>.</summary>
		/// <param name="identity">A string identifying the scene for easy recovery in a file or a repository.</param>
		/// <param name="sceneName">The name of the character.</param>
		public Scene(string identity, string sceneName)
		{
			ArgumentNullException.ThrowIfNull(identity, nameof(identity));
			ArgumentNullException.ThrowIfNull(sceneName, nameof(sceneName));

			id = identity;
			name = sceneName;
		}
		#endregion

		#region IStuffHolder
		/// <summary>This method is to be called when the <see cref="IStuffHolder"/> acquires a given item.</summary>
		/// <param name="item">The item acquired by the <see cref="IStuffHolder"/>.</param>
		/// <returns>
		/// A <see cref="IResult"/> object containing an error message if any.
		/// In case of success, the returned object flag <see cref="IResult.IsSuccess"> is set to true.
		/// Possible errors :
		/// - <see cref="Results.ErrorNullItem"/>
		/// </returns>
		public IResult AcquireStuff(Item item)
		{
			if (item is null)
			{
				return Results.ErrorNullItem;
			}

			item.MoveTo(this);
			return Results.Success;
		}

		/// <summary>Checks if the <see cref="IStuffHolder"/> holds a given item.</summary>
		/// <param name="item">The item to check against the <see cref="IStuffHolder"/> stuff.</param>
		/// <returns>
		/// <see langword="true"/> if the <see cref="IStuffHolder"> holds the item.
		/// <see langword="false"/> otherwise.
		/// </returns>
		public bool Holds(Item item)
		{
			return (item is null) ? false : item.GetHolder() == this;
		}
		#endregion

		#region Actions
		/// <summary>Activates this scene.</summary>
		public void Activates()
		{
			OnActivated();
		}
		#endregion

		#region Events
		/// <summary>Event raised when the scene is activated.</summary>
		public event EventHandler<SceneEventArgs> Activated;
		private void OnActivated()
		{
			Activated?.Invoke(this, new SceneEventArgs(this));
		}
		#endregion

		#region Equality
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
		#endregion
	}
}
