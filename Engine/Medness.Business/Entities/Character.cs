using Medness.Business.Event.Args;
using Medness.Business.Interfaces;
using Medness.Business.ValueObjects;

namespace Medness.Business.Entities
{
    public class Character : IStuffHolder
	{
		public readonly string id;
		public readonly string name;
		public readonly IsPlayable isPlayable;

		private string _sceneId; // Scene where the character is.

        public Character(string identity, string characterName, bool playable)
        {
			ArgumentNullException.ThrowIfNull(characterName, nameof(characterName));

			id = identity;
			name = characterName;
			isPlayable = new IsPlayable(playable);
			_sceneId = string.Empty;
		}

		public void EntersScene(string destinationSceneId)
		{
			_sceneId = destinationSceneId;
			OnEnteredScene();
		}

		public bool IsInScene(string sceneId)
		{
			return _sceneId == sceneId;
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

		#region Events
		public event EventHandler<CharacterEventArgs> EnteredScene;
		private void OnEnteredScene()
		{
			EnteredScene?.Invoke(this, new CharacterEventArgs(this));
		}
		#endregion

		#region Equality
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (obj is Character characterObj)
				return characterObj.id == id;

			return false;
		}

		public override int GetHashCode()
		{
			return id.GetHashCode();
		}
		#endregion
	}
}
