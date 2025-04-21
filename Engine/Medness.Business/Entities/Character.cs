using Medness.Business.Event.Args;
using Medness.Business.Interfaces;
using Medness.Business.ValueObjects;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Medness.Business.Entities
{
    public class Character : IStuffHolder
	{
		public string id { get; }
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

		private CharacterEventArgs _storedSceneEntrance;
        private event EventHandler<CharacterEventArgs> _enteredScene;
        public event EventHandler<CharacterEventArgs> EnteredScene
		{
			add
			{
				_enteredScene += value;
				if (_storedSceneEntrance is not null)
					_enteredScene?.Invoke(this, _storedSceneEntrance);
			}
			remove
			{
				_enteredScene -= value;
			}
		}
		private void OnEnteredScene()
		{
			//si il n'y a pas d'abonnement il se passe quoi ?
			//on a déjà eu des pb à cause du cycle de vie de nos programmes au taf car le consommateur arrive après l'event, il est donc jeté dans le vide
			//peut etre robustifier ça avec un système similaire aux events, en gardant la notif dans un coin tant que le consommateur n'est pas la
			//puis perso je suis vraiment pas fan des events :p ça apporte trop souvent des problèmes, même si des fois il n'y a pas vraiment d'autres façon de faire et je les utilise quand meme
			
			//ici à la place de ce code tu pourrais implémenter un Delegate custom pour gérérer ça en dehors de ta classe
			if (_enteredScene is null)
				_storedSceneEntrance = new(this);
			else
				_enteredScene?.Invoke(this, new(this));
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
