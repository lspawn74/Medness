using Medness.Application.Interfaces;
using Medness.Business.Entities;

namespace Medness.Application.Entities
{
	public class Game
	{
		private Player player;
        private ICharacterRepository _characterRepository;

        public Game(Player gamePlayer, ICharacterRepository characterRepository)
        {
            ArgumentNullException.ThrowIfNull(gamePlayer);
            ArgumentNullException.ThrowIfNull(characterRepository);
            player = gamePlayer;
            _characterRepository = characterRepository;
        }

        public void SwitchPlayer(Player otherPlayer)
        {
            player = otherPlayer;
        }

        public void AddCharacter(Character character)
        {
			_characterRepository.Add(character);
		}

        public bool HasCharacter(Guid characterId)
        {
            return _characterRepository.Get(characterId) != null;
        }

        public bool IsPlayer(Player otherPlayer)
        {
            return player == otherPlayer;
        }
    }
}
