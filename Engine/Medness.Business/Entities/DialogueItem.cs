using Medness.Business.Enums;
using Medness.Business.Event.Args;
using Medness.Business.Interfaces;
using Medness.Business.ValueObjects;

namespace Medness.Business.Entities
{
	public class DialogueItem
    {
        /// <summary>Id of the dialogue.</summary>
        public readonly string id;

        /// <summary>Character saying the dialogue item.</summary>
        public readonly Character character;

        private IEnumerable<DialogueTrigger> _triggers;
		private IItemRepository _itemRepository;
        private ICharacterRepository _characterRepository;
        private ISceneRepository _sceneRepository;
        private IDialogueItemRepository _dialogueItemRepository;

        public DialogueItem(
            string dialogueId,
            Character sayingCharacter,
            IEnumerable<DialogueTrigger> triggers,
            IItemRepository itemRepository,
            ICharacterRepository characterRepository,
            ISceneRepository sceneRepository,
            IDialogueItemRepository dialogueItemRepository)
        {
            ArgumentNullException.ThrowIfNull(id, nameof(id));
            ArgumentNullException.ThrowIfNull(sayingCharacter, nameof(sayingCharacter));
            ArgumentNullException.ThrowIfNull(triggers, nameof(triggers));
            ArgumentNullException.ThrowIfNull(itemRepository, nameof(itemRepository));
            ArgumentNullException.ThrowIfNull(characterRepository, nameof(characterRepository));
            ArgumentNullException.ThrowIfNull(sceneRepository, nameof(sceneRepository));
            ArgumentNullException.ThrowIfNull(dialogueItemRepository, nameof(dialogueItemRepository));

            id = dialogueId;
            character = sayingCharacter;
            _triggers = triggers;
            _itemRepository = itemRepository;
            _characterRepository = characterRepository;
            _sceneRepository = sceneRepository;
            _dialogueItemRepository = dialogueItemRepository;

            // Set event handlers based on dialogue triggers
            foreach (DialogueTrigger trigger in triggers)
            {
                Dispatch(trigger);
            }
        }

        private void Dispatch(DialogueTrigger trigger)
        {
			Scene scene;
			Character character;
			DialogueItem dialogueItem;
			Item item;

			switch (trigger.type)
            {
                case DialogueItemTriggerType.SceneActivated:
                    scene = _sceneRepository.Get(trigger.objectId);
                    if (scene == null)
                    {
                        throw new ArgumentException($"Scene {trigger.objectId} not declared in scenes repository.");
                    }
                    else
                    {
						scene.Activated += Scene_Activated;
                    }
                    break;
				case DialogueItemTriggerType.CharacterEnters:
                    character = _characterRepository.Get(trigger.objectId);
                    if (character == null)
                    {
                        throw new ArgumentException($"Character {trigger.objectId} not declared in characters repository.");
                    }
                    else
                    {
						character.EnteredScene += Character_EnteredScene;
                    }
					break;
				case DialogueItemTriggerType.DialogueFinished:
                    dialogueItem = _dialogueItemRepository.Get(trigger.objectId);
                    if (dialogueItem == null)
                    {
						throw new ArgumentException($"Dialogue item {trigger.objectId} not declared in dialogue items repository.");
					}
                    else
                    {
						dialogueItem.PlayFinished += DialogueItem_PlayFinished;
                    }
					break;
				case DialogueItemTriggerType.ItemMoved:
                    item = _itemRepository.Get(trigger.objectId);
                    if (item == null)
                    {
						throw new ArgumentException($"Item {trigger.objectId} not declared in items repository.");
					}
                    else
                    {
						item.Moved += Item_Moved;
                    }
					break;
				case DialogueItemTriggerType.ItemUsed:
					item = _itemRepository.Get(trigger.objectId);
					if (item == null)
					{
						throw new ArgumentException($"Item {trigger.objectId} not declared in items repository.");
					}
					else
					{
						item.Used += Item_Used;
					}
					break;
				case DialogueItemTriggerType.ChosenDialogue:
					dialogueItem = _dialogueItemRepository.Get(trigger.objectId);
					if (dialogueItem == null)
					{
						throw new ArgumentException($"Dialogue item {trigger.objectId} not declared in dialogue items repository.");
					}
					else
					{
						dialogueItem.Chosen += DialogueItem_Chosen;
					}
					break;
                default:
                    // Should not happen (means the code is incomplete)
                    throw new ArgumentException("Unhandled dialogue trigger", nameof(trigger));
			}
		}

		#region Events handling
		private void Scene_Activated(object sender, SceneEventArgs e)
		{
			OnPlayStarted();
		}

		private void Character_EnteredScene(object sender, CharacterEventArgs e)
		{
			OnPlayStarted();
		}

		private void DialogueItem_PlayFinished(object sender, DialogueItemEventArgs e)
		{
			OnPlayStarted();
		}

		private void Item_Moved(object sender, ItemMoveEventArgs e)
		{
            // Play dialogue only if the item has been moved from the a given stuff holder to another given stuff holder.
            DialogueTrigger dialogueTrigger = _triggers
                .FirstOrDefault(t => t.objectId == e.Item.id && t.argument1Id == e.Source.id && t.argument2Id == e.Destination.id);
			if (dialogueTrigger != null )
                OnPlayStarted();
		}

		private void Item_Used(object sender, ItemEventArgs e)
		{
			OnPlayStarted();
		}

		private void DialogueItem_Chosen(object sender, EventArgs e)
		{
			OnPlayStarted();
		}
        #endregion

        #region Actions
        public void Choose()
        {
            OnChosen();
        }
        #endregion

        #region Events
        public event EventHandler<DialogueItemEventArgs> PlayStarted;
		public event EventHandler<DialogueItemEventArgs> PlayFinished;
		private void OnPlayStarted()
        {
            PlayStarted?.Invoke(this, new DialogueItemEventArgs(this));

			// After dialogue played, we trigger the DialogueFinished event
			PlayFinished?.Invoke(this, new DialogueItemEventArgs(this));
		}

        public event EventHandler Chosen;
        private void OnChosen()
        {
			Chosen?.Invoke(this, new DialogueItemEventArgs(this));
		}
		#endregion

		#region Equality
		public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is DialogueItem itemObj)
                return id == itemObj.id;

            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
        #endregion
    }
}
