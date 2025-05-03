using Medness.Business.Event.Args;
using Medness.Business.Interfaces;
using Medness.Business.Resources;
using Medness.Business.ValueObjects;

namespace Medness.Business.Entities
{
	/// <summary>Represents a character of the game.</summary>
	public class Character : IStuffHolder
	{
		#region Fields
		/// <summary>Character's Id (to easily identify it in a file or a repository).</summary>
		/// <remarks>This field is part of the <see cref="IStuffHolder"/> interface.</remarks>
		public string id { get; }

		/// <summary>The character's name.</summary>
		public readonly string name;

		/// <summary>
		/// This object indicates if the character is playable.
		/// </summary>
		public readonly IsPlayable isPlayable;

		/// <summary>Scene where the character is currently located.</summary>
		private string _sceneId;
		#endregion

		#region Constructor
		/// <summary>Creates a new instance of class <see cref="Character"/>.</summary>
		/// <param name="identity">A string identifying the character for easy recovery in a file or a repository.</param>
		/// <param name="characterName">The name of the character.</param>
		/// <param name="playable">A flag indicating if the character is playable. (<see langword="false"/> means the character is a NPC)</param>
		public Character(string identity, string characterName, bool playable)
        {
			ArgumentNullException.ThrowIfNull(identity, nameof(identity));
			ArgumentNullException.ThrowIfNull(characterName, nameof(characterName));

			id = identity;
			name = characterName;
			isPlayable = new IsPlayable(playable);
			_sceneId = string.Empty;
		}
		#endregion

		#region Public methods
		/// <summary>This method must be invoked when a character enters a given scene.</summary>
		/// <param name="destinationSceneId">The id of the scene where the character is to enter.</param>
		public void EntersScene(string destinationSceneId)
		{
			_sceneId = destinationSceneId;
			OnEnteredScene();
		}

		/// <summary>Checks if the character is in a given scene.</summary>
		/// <param name="sceneId">The id of the scene in which it is required to know about the presence of character.</param>
		/// <returns>
		/// <see langword="true"/> if the character is in the given scene.
		/// <see langword="false"/> otherwise.
		/// </returns>
		public bool IsInScene(string sceneId)
		{
			return _sceneId == sceneId;
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
					// LC : Le défaut ici, c'est que l'invocation peut avoir lieu à chaque abonnement. (donc multiple invocation pour
					// les handlers précédemments abonnés seront invoqués à chaque fois.
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

			// LC : l'évènement est perdu. Tant pis. Fallait être abonné avant (sinon, mauvais design)
			//      Dans le cas d'un jeu point'n'click, une phase d'initialisation va charger les personnages
			//      et faire les abonnements sur les évènements par des managers (genre manager de dialogue)
			//      donc bien avant la survenue des évènements.

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
