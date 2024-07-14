using Medness.Application.Events.Args;
using Medness.Application.Interfaces;
using Medness.Business.Entities;

namespace Medness.Application.Entities
{
	public class Game
    {
        private Player player;
        private ICharacterRepository _characterRepository;
        private ISceneRepository _sceneRepository;
        private Guid _activeCharacter;
        private Guid _activeScene;

        #region Constructors
        public Game(Player gamePlayer, ICharacterRepository characterRepository, ISceneRepository sceneRepository)
        {
            ArgumentNullException.ThrowIfNull(gamePlayer);
            ArgumentNullException.ThrowIfNull(characterRepository);
            ArgumentNullException.ThrowIfNull(sceneRepository);
            player = gamePlayer;
            _characterRepository = characterRepository;
            _activeCharacter = Guid.Empty;
            _sceneRepository = sceneRepository;
            _activeScene = Guid.Empty;
        }
        #endregion

        #region Player methods
        public void Switch(Player otherPlayer)
        {
            player = otherPlayer;
            PlayerSwitched?.Invoke(this, EventArgs.Empty);
		}
		public bool IsPlayer(Player otherPlayer)
        {
            return player == otherPlayer;
        }
        #endregion

        #region Player events
        public event EventHandler? PlayerSwitched;
        #endregion

        #region Characters methods
        public void AddCharacter(Character character)
        {
			_characterRepository.Add(character);
            CharacterAdded?.Invoke(this, new CharacterEventArgs(character));
		}

        public void RemoveCharacter(Character character)
        {
            _characterRepository.Remove(character);
			CharacterRemoved?.Invoke(this, new CharacterEventArgs(character));
		}

		public bool HasCharacter(Guid characterId)
        {
            return _characterRepository.Get(characterId) != null;
        }

		public void Switch(Character character)
		{
			if (_characterRepository.Get(character.id) == null)
				return;
			_activeCharacter = character.id;
			CharacterSelected?.Invoke(this, new CharacterEventArgs(character));
		}

		public bool IsActive(Character character)
        {
            return _activeCharacter == character.id;
        }

        public void EntersScene(Character character, Scene scene)
        {
            if (!HasCharacter(character.id))
                throw new ArgumentException("No character with Id " + character.id + " in game.");

			if (!HasScene(scene.id))
				throw new ArgumentException("No scene with Id " + scene.id + " in game.");

            character.EntersScene(scene.id);
			CharacterEnteredScene?.Invoke(this, new CharacterEventArgs(character));
		}
		#endregion

		#region Characters events
		public event EventHandler<CharacterEventArgs>? CharacterAdded;
		public event EventHandler<CharacterEventArgs>? CharacterRemoved;
		public event EventHandler<CharacterEventArgs>? CharacterSelected;
		public event EventHandler<CharacterEventArgs>? CharacterEnteredScene;
		#endregion

		#region scene methods
		public void AddScene(Scene scene)
		{
			_sceneRepository.Add(scene);
            SceneAdded?.Invoke(this, new SceneEventArgs(scene));
		}

		public void RemoveScene(Scene scene)
		{
			_sceneRepository.Remove(scene);
			SceneRemoved?.Invoke(this, new SceneEventArgs(scene));
		}

		public bool HasScene(Guid sceneId)
		{
			return _sceneRepository.Get(sceneId) != null;
		}

		public void Switch(Scene scene)
		{
			if (_sceneRepository.Get(scene.id) == null)
				return;
			_activeScene = scene.id;
			SceneDisplayed?.Invoke(this, new SceneEventArgs(scene));
		}

		public bool IsActive(Scene scene)
		{
			return _activeScene == scene.id;
		}
		#endregion

		#region Scene events
		public event EventHandler<SceneEventArgs>? SceneAdded;
		public event EventHandler<SceneEventArgs>? SceneRemoved;
		public event EventHandler<SceneEventArgs>? SceneDisplayed;
		#endregion
	}
}
