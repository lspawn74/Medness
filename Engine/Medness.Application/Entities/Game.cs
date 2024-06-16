using Medness.Application.Interfaces;
using Medness.Business.Entities;

namespace Medness.Application.Entities
{
	public class Game
	{
		private Player player;
        private ICharacterRepository _characterRepository;
        private Guid _activeCharacter;

		#region Constructors
		public Game(Player gamePlayer, ICharacterRepository characterRepository)
        {
            ArgumentNullException.ThrowIfNull(gamePlayer);
            ArgumentNullException.ThrowIfNull(characterRepository);
            player = gamePlayer;
            _characterRepository = characterRepository;
            _activeCharacter = Guid.Empty;

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
    }
}
