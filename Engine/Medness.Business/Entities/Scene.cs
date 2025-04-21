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
			//pas de vérif sur identity ?

			//pour sceneName, je ne sais pas si tu allow le string.Empty, si oui tu peux être moins violent en faisant
			//name = sceneName ?? "";
			//sauf si tu veux vraiment remonter l'erreur à celui qui appelle le constructeur avec une valeur null
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
