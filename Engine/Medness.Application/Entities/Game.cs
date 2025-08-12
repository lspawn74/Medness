using Medness.Business.Entities;
using Medness.Business.Interfaces;
using Medness.Business.Resources;

namespace Medness.Application.Entities
{
	/// <summary>
	/// This class represents the most high-level class of the engine.
	/// It contains references to characters, scenes, items and dialogues.
	/// It contains the identity if the current active player.
	/// It contains the identity of the currently active scene.
	/// </summary>
	public class Game
    {
		#region Fields

		/// <summary>The current player.</summary>
		private Player player;

		/// <summary>The repositories used in the game.</summary>
        public readonly IRepository<Character> characterRepository;
        public readonly IRepository<Scene> sceneRepository;
		public readonly IRepository<Item> itemRepository;
		public readonly IRepository<DialogueItem> dialogueItemRepository;

		/// <summary>The currently active character.</summary>
        private string _activeCharacter;

		/// <summary>The currently active scene.</summary>
        private string _activeScene;

		#endregion

		#region Constructors
		/// <summary>Creates a new instance of class <see cref="Game"/>.</summary>
		/// <param name="gamePlayer">The initial active player.</param>
		/// <param name="characterRepository">The repository containing the characters of the game.</param>
		/// <param name="sceneRepository">The repository containing the scenes of the game.</param>
		/// <param name="itemRepository">The repository containing items of the game.</param>
		/// <param name="dialogueItemRepository">The repository containing dialogue items of the game.</param>
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
		/// <summary>
		/// Switches the currently active player to another player. Making it the new active player.
		/// </summary>
		/// <param name="otherPlayer">The other player to switch to.</param>
		/// <returns>
		/// A <see cref="IResult"/> object containing an error message if any.
		/// In case of success, the returned object flag <see cref="IResult.IsSuccess"> is set to true.
		/// Possible errors :
		/// - <see cref="Results.ErrorNullPlayer"/>
		/// </returns>
		public IResult Switch(Player otherPlayer)
        {
			// Critical error : There can't be a null player (something is wrong in the caller)
			if (otherPlayer is null)
			{
				return Results.ErrorNullPlayer;
			}

            player = otherPlayer;
            PlayerSwitched?.Invoke(this, EventArgs.Empty);

			return Results.Success;
		}

		/// <summary>
		/// Checks for the identity of the currently active player.
		/// </summary>
		/// <param name="otherPlayer">The player to compare to currently active player.</param>
		/// <returns>
		/// <see langword="true"/> if <paramref name="otherPlayer"/> is the active player.
		/// <see langword="false"/> otherwise.
		/// </returns>
		public bool IsPlayer(Player otherPlayer)
        {
            return player == otherPlayer;
        }
        #endregion

        #region Player events
		/// <summary>This event is triggered when active player changes.</summary>
        public event EventHandler PlayerSwitched;
		#endregion

		#region Characters methods
		/// <summary>
		/// Adds a character to the game's characters repository.
		/// </summary>
		/// <param name="character">The character to add to the repository.</param>
		/// <returns>
		/// A <see cref="IResult"/> object containing an error message if any.
		/// In case of success, the returned object flag <see cref="IResult.IsSuccess"> is set to true.
		/// Possible errors :
		/// - <see cref="Results.ErrorNullCharacter"/>
		/// </returns>
		public IResult AddCharacter(Character character)
        {
			if (character is null)
			{
				return Results.ErrorNullCharacter;
			}
			
			characterRepository.Add(character);
			return Results.Success;
		}

		/// <summary>
		/// Checks if a specific character is in the game's characters repository.
		/// </summary>
		/// <param name="characterId">The id of the character to check.</param>
		/// <returns>
		/// <see langword="true"/> if <paramref name="characterId"/> is the id of an existing character in the game.
		/// <see langword="false"/> otherwise.
		/// </returns>
		public bool HasCharacter(string characterId)
        {
			return characterRepository.Contains(characterId).IsSuccess;
        }

		/// <summary>
		/// Switches the currently active character to another character. Making it the new active character.
		/// </summary>
		/// <param name="character">The other character to switch to.</param>
		/// <returns>
		/// A <see cref="IResult"/> object containing an error message if any.
		/// In case of success, the returned object flag <see cref="IResult.IsSuccess"> is set to true.
		/// Possible errors :
		/// - <see cref="Results.ErrorNullCharacter"/>
		/// - <see cref="Results.ErrorUnknownId"/> if the character is not in the game's characters repository.
		/// </returns>
		public IResult Switch(Character character)
		{
			if (character is null)
			{
				return Results.ErrorNullCharacter;
			}

			if (!characterRepository.Contains(character.id).IsSuccess)
			{
				return Results.ErrorUnknownId;
			}

			_activeCharacter = character.id;
			return Results.Success;
		}

		/// <summary>
		/// Checks for the identity of the currently active character.
		/// </summary>
		/// <param name="character">The character to compare to currently active character.</param>
		/// <returns>
		/// <see langword="true"/> if <paramref name="character"/> is the active character.
		/// <see langword="false"/> otherwise.
		/// </returns>
		public bool IsActive(Character character)
        {
			return (character is null) ? false : _activeCharacter == character.id;
        }

		/// <summary>
		/// Makes a given character enter a given scene.
		/// </summary>
		/// <param name="character">The character to add to the scene.</param>
		/// <param name="scene">The scene in which the character is to be added.</param>
		/// <returns>
		/// A <see cref="IResult"/> object containing an error message if any.
		/// In case of success, the returned object flag <see cref="IResult.IsSuccess"> is set to true.
		/// Possible errors :
		/// - <see cref="Results.ErrorNullCharacter"/>
		/// - <see cref="Results.ErrorNullScene"/>
		/// - <see cref="Results.ErrorUnknownId"/> if the character or the scene are not in the game's repositories.
		/// </returns>
		public IResult EntersScene(Character character, Scene scene)
        {
			if (character is null)
			{
				return Results.ErrorNullCharacter;
			}

			if (scene is null)
			{
				return Results.ErrorNullScene;
			}

			IResult containsCharacterResult = characterRepository.Contains(character.id);
			if (!containsCharacterResult.IsSuccess)
			{
				return containsCharacterResult;
			}

			IResult containsSceneResult = sceneRepository.Contains(scene.id);
			if (!containsSceneResult.IsSuccess)
			{
				return containsSceneResult;
			}

            character.EntersScene(scene.id);
			return Results.Success;
		}
		#endregion

		#region Scene methods
		/// <summary>
		/// Adds a scene to the game's scene repository.
		/// </summary>
		/// <param name="scene">The <see cref="Scene"/> to add.</param>
		/// <returns>
		/// A <see cref="IResult"/> object containing an error message if any.
		/// In case of success, the returned object flag <see cref="IResult.IsSuccess"> is set to true.
		/// Possible errors :
		/// - <see cref="Results.ErrorNullScene"/>
		/// </returns>
		public IResult AddScene(Scene scene)
		{
			if (scene is null)
			{
				return Results.ErrorNullScene;
			}

			sceneRepository.Add(scene);
			return Results.Success;
		}

		/// <summary>
		/// Checks wether the game's scenes repository contains the scene with the given scene Id.
		/// </summary>
		/// <param name="sceneId">Scene Id to look for in the game's scenes repository.</param>
		/// <returns>
		/// <see langword="true"/> if the scene is in the game's scenes repository.
		/// <see langword="false"/> otherwise.
		/// </returns>
		public bool HasScene(string sceneId)
		{
			return sceneRepository.Contains(sceneId).IsSuccess;
		}

		/// <summary>
		/// Switches from the current scene to a new one given in argument.
		/// </summary>
		/// <param name="scene">The <see cref="Scene"/> to switch to.</param>
		/// <returns>
		/// A <see cref="IResult"/> object containing an error message if any.
		/// In case of success, the returned object flag <see cref="IResult.IsSuccess"> is set to true.
		/// Possible errors :
		/// - <see cref="Results.ErrorNullScene"/>
		/// - <see cref="Results.ErrorUnknownId"/> if the scene is not in the game's scenes repository.
		/// </returns>
		public IResult Switch(Scene scene)
		{
			if (scene is null)
			{
				return Results.ErrorNullScene;
			}

			if (!sceneRepository.Contains(scene.id).IsSuccess)
			{
				return Results.ErrorUnknownId;
			}

			_activeScene = scene.id;
			scene.Activates();

			return Results.Success;
		}

		/// <summary>
		/// Checks for the identity of the currently active scene.
		/// </summary>
		/// <param name="scene">The scene to compare to currently active scene.</param>
		/// <returns>
		/// <see langword="true"/> if <paramref name="scene"/> is the active scene.
		/// <see langword="false"/> otherwise.
		/// </returns>
		public bool IsActive(Scene scene)
		{
			return (scene is null) ? false : _activeScene == scene.id;
		}

		#endregion

		#region Items methods
		/// <summary>
		/// Adds a item to the game's item repository.
		/// </summary>
		/// <param name="item">The <see cref="item"/> to add.</param>
		/// <returns>
		/// A <see cref="IResult"/> object containing an error message if any.
		/// In case of success, the returned object flag <see cref="IResult.IsSuccess"> is set to true.
		/// Possible errors :
		/// - <see cref="Results.ErrorNullItem"/>
		/// </returns>
		public IResult AddItem(Item item)
		{
			if (item is null)
			{
				return Results.ErrorNullItem;
			}

			itemRepository.Add(item);
			return Results.Success;
        }

		/// <summary>
		/// Checks wether the game's items repository contains the item with the given item Id.
		/// </summary>
		/// <param name="itemId">item Id to look for in the game's items repository.</param>
		/// <returns>
		/// <see langword="true"/> if the item is in the game's items repository.
		/// <see langword="false"/> otherwise.
		/// </returns>
		public bool HasItem(string itemId)
		{
			return itemRepository.Get(itemId) != null;
		}
		#endregion
	}
}
