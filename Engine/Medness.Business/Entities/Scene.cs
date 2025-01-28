using Medness.Business.Event.Args;
using Medness.Business.Interfaces;

namespace Medness.Business.Entities
{
    public class Scene : IStuffHolder
	{
		public string id { get; }
		public readonly string name;

		public Scene(string identity, string sceneName)
		{
			ArgumentNullException.ThrowIfNull(sceneName, nameof(sceneName));

			id = identity;
			name = sceneName;
		}


		#region IStuffHolder
		public void AcquireStuff(Item item)
		{
			ArgumentNullException.ThrowIfNull(item, nameof(item));
			item.MoveTo(this);
		}

		public bool Holds(Item item)
		{
			ArgumentNullException.ThrowIfNull(item, nameof(item));
			return item.GetHolder() == this;
		}
		#endregion

		#region Actions
		public void Activates()
		{
			OnActivated();
		}
		#endregion

		#region Events
		public event EventHandler<SceneEventArgs> Activated;
		private void OnActivated()
		{
			Activated?.Invoke(this, new SceneEventArgs(this));
		}
		#endregion

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
