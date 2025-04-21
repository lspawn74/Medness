using Medness.Business.Entities;
using Medness.Business.Interfaces;

namespace Medness.Application.Entities
{
	public class Game
    {
        private Player player;
        public readonly IRepository<Character> characterRepository;
        public readonly IRepository<Scene> sceneRepository;
		public readonly IRepository<Item> itemRepository;
		public readonly IRepository<DialogueItem> dialogueItemRepository;
        private string _activeCharacter;
        private string _activeScene;

        #region Constructors
        public Game(
			Player gamePlayer,
			IRepository<Character> characterRepository,
			IRepository<Scene> sceneRepository,
			IRepository<Item> itemRepository,
			IRepository<DialogueItem> dialogueItemRepository)
        {
            ArgumentNullException.ThrowIfNull(gamePlayer);
            ArgumentNullException.ThrowIfNull(characterRepository);
            ArgumentNullException.ThrowIfNull(sceneRepository);
			ArgumentNullException.ThrowIfNull(itemRepository);
			ArgumentNullException.ThrowIfNull(dialogueItemRepository);

			player = gamePlayer;
            this.characterRepository = characterRepository;
            _activeCharacter = string.Empty;
            this.sceneRepository = sceneRepository;
			this.itemRepository = itemRepository;
			this.dialogueItemRepository = dialogueItemRepository;
            _activeScene = string.Empty;
        }
        #endregion

        #region Player methods
        public void Switch(Player otherPlayer)
        {
			//c'est voulu de ne pas tester la nullité dans aucunes des méthodes ?
            player = otherPlayer; //ici tu peux assigner une null ref
            PlayerSwitched?.Invoke(this, EventArgs.Empty);
		}
		public bool IsPlayer(Player otherPlayer)
        {
            return player == otherPlayer;//ici osef
        }
        #endregion

        #region Player events
        public event EventHandler PlayerSwitched;
        #endregion

        #region Characters methods
        public void AddCharacter(Character character)
        {
			characterRepository.Add(character);//ici le check peut etre fait dans le add effectivement mais est-ce qu'un bool succes ou IResult doit etre remonté pour avoir l'info d'un échec ?
		}

		public bool HasCharacter(string characterId)
        {
            return characterRepository.Get(characterId) != null;//ici c'est mieux de le traiter dans le get
        }

		public void Switch(Character character)
		{
			if (characterRepository.Get(character.id) == null)//ici crash possible null.id
				return;
			_activeCharacter = character.id;
		}

		public bool IsActive(Character character)
        {
            return _activeCharacter == character.id;//idem crash possible
        }

        public void EntersScene(Character character, Scene scene)//idem pour les deux
        {
            if (!HasCharacter(character.id))
                throw new ArgumentException("No character with Id " + character.id + " in game.");

			if (!HasScene(scene.id))
				throw new ArgumentException("No scene with Id " + scene.id + " in game.");

            character.EntersScene(scene.id);
		}
		#endregion

		#region Scene methods
		public void AddScene(Scene scene)
		{
			sceneRepository.Add(scene);//pas de nécessité de traiter la nullité ici mais un bool ou IResult ? sauf si le resultat n'a pas vocation à être traité
		}

		public bool HasScene(string sceneId)
		{
			return sceneRepository.Get(sceneId) != null;//osef
		}

		public void Switch(Scene scene)
		{
			if (sceneRepository.Get(scene.id) == null)//crash
				return;
			_activeScene = scene.id;//idem
			scene.Activates();
		}

		public bool IsActive(Scene scene)
		{
			return _activeScene == scene.id;//idem
		}

		#endregion

		#region Items methods
		public void AddItem(Item item)
		{
			itemRepository.Add(item);//pas de nécessité de traiter la nullité ici mais un bool ou IResult ? sauf si le resultat n'a pas vocation à être traité
        }

        public bool HasItem(string itemId)
		{
			return itemRepository.Get(itemId) != null;
		}
		#endregion
	}
}
