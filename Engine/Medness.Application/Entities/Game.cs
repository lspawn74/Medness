using Medness.Business.Entities;
using Medness.Business.Interfaces;

namespace Medness.Application.Entities
{
	public class Game
    {
        private Player player;
        public readonly ICharacterRepository characterRepository;
        public readonly ISceneRepository sceneRepository;
		public readonly IItemRepository itemRepository;
		public readonly IDialogueItemRepository dialogueItemRepository;
        private string _activeCharacter;
        private string _activeScene;

        #region Constructors
        public Game(
			Player gamePlayer,
			ICharacterRepository characterRepository,
			ISceneRepository sceneRepository,
			IItemRepository itemRepository,
			IDialogueItemRepository dialogueItemRepository)
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
			characterRepository.Add(character);
		}

		public bool HasCharacter(string characterId)
        {
            return characterRepository.Get(characterId) != null;
        }

		public void Switch(Character character)
		{
			if (characterRepository.Get(character.id) == null)
				return;
			_activeCharacter = character.id;
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
		}
		#endregion

		#region Scene methods
		public void AddScene(Scene scene)
		{
			sceneRepository.Add(scene);
		}

		public bool HasScene(string sceneId)
		{
			return sceneRepository.Get(sceneId) != null;
		}

		public void Switch(Scene scene)
		{
			if (sceneRepository.Get(scene.id) == null)
				return;
			_activeScene = scene.id;
			scene.Activates();
		}

		public bool IsActive(Scene scene)
		{
			return _activeScene == scene.id;
		}

		#endregion
		#region Items methods
		public void AddItem(Item item)
		{
			itemRepository.Add(item);
		}

		public bool HasItem(string itemId)
		{
			return itemRepository.Get(itemId) != null;
		}
		#endregion
	}
}
