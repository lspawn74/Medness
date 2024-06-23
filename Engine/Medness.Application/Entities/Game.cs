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

		}
		#endregion

		#region Player methods
		public void Switch(Player otherPlayer)
        {
            player = otherPlayer;
        }
        public bool IsPlayer(Player otherPlayer)
        {
            return player == otherPlayer;
        }
		#endregion

		#region Characters methods
		public void AddCharacter(Character character)
        {
			_characterRepository.Add(character);
		}

        public void RemoveCharacter(Character character)
        {
            _characterRepository.Remove(character);
        }

        public bool HasCharacter(Guid characterId)
        {
            return _characterRepository.Get(characterId) != null;
        }

        public void Switch(Character character)
        {
            if (_characterRepository.Get(character.id) != null)
            {
                _activeCharacter = character.id;
                return;
            }
            _activeCharacter = Guid.Empty;
		}

        public bool IsActive(Character character)
        {
            return _activeCharacter == character.id;
        }
		#endregion

		#region scene methods
		public void AddScene(Scene scene)
		{
			_sceneRepository.Add(scene);
		}

		public void RemoveScene(Scene scene)
		{
			_sceneRepository.Remove(scene);
		}

		public bool HasScene(Guid sceneId)
		{
			return _sceneRepository.Get(sceneId) != null;
		}
		#endregion
	}
}
