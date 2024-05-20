namespace Medness.Business.Entities
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

        public bool IsPlayer(Player otherPlayer)
        {
            return player == otherPlayer;
        }
    }
}
