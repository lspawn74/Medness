using Medness.Business.Entities;

namespace Medness.Application.Entities
{
	public class Game
	{
		private Player player;

        public Game(Player gamePlayer)
        {
            ArgumentNullException.ThrowIfNull(gamePlayer);
            player = gamePlayer;
        }

        public void SwitchPlayer(Player otherPlayer)
        {
            player = otherPlayer;
        }

        public void addCharacter(Character character)
        {

        }

        public bool IsPlayer(Player otherPlayer)
        {
            return player == otherPlayer;
        }
    }
}
