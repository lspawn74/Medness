﻿using Medness.Business.Entities;
using Medness.Business.Enums;
using Medness.Business.Event.Args;
using Medness.Business.Interfaces;

namespace Medness.Business.ValueObjects
{
	public class DialogueTrigger
	{
		public readonly string objectId = string.Empty;

		public readonly string argument1Id = string.Empty;
		public readonly string argument2Id = string.Empty;

		public readonly DialogueItemTriggerType type;

		private IRepository _repository;

		#region Constructors
		public DialogueTrigger(string object_id, IRepository repository, DialogueItemTriggerType trigger_type)
		{
			ArgumentNullException.ThrowIfNull(object_id);
			ArgumentNullException.ThrowIfNull(trigger_type);

			objectId = object_id;
			type = trigger_type;
			_repository = repository;
		}

		public DialogueTrigger(string object_id, IRepository repository, string argument_id, DialogueItemTriggerType trigger_type)
			: this(object_id, repository, trigger_type)
		{
			ArgumentNullException.ThrowIfNull(argument_id);

			argument1Id = argument_id;
		}

		public DialogueTrigger(string object_id, IRepository repository, string argument1_id, string argument2_id, DialogueItemTriggerType trigger_type):
			this(object_id, repository, argument1_id, trigger_type)
		{
			ArgumentNullException.ThrowIfNull(argument2_id);

			argument2Id = argument2_id;
		}
		#endregion

		public void Dispatch()
		{
			Scene scene;
			Character character;
			DialogueItem dialogueItem;
			Item item;

			switch (type)
			{
				case DialogueItemTriggerType.SceneActivated:
					scene = ((IRepository<Scene>)_repository).Get(objectId);
					if (scene == null)
					{
						throw new ArgumentException($"Scene {objectId} not declared in scenes repository.");
					}
					else
					{
						scene.Activated += Scene_Activated;
					}
					break;
				case DialogueItemTriggerType.CharacterEnters:
					character = ((IRepository<Character>)_repository).Get(objectId);
					if (character == null)
					{
						throw new ArgumentException($"Character {objectId} not declared in characters repository.");
					}
					else
					{
						character.EnteredScene += Character_EnteredScene;
					}
					break;
				case DialogueItemTriggerType.DialogueFinished:
					dialogueItem = ((IRepository<DialogueItem>)_repository).Get(objectId);
					if (dialogueItem == null)
					{
						throw new ArgumentException($"Dialogue item {objectId} not declared in dialogue items repository.");
					}
					else
					{
						dialogueItem.PlayFinished += DialogueItem_PlayFinished;
					}
					break;
				case DialogueItemTriggerType.ItemMoved:
					item = ((IItemRepository)_repository).Get(objectId);
					if (item == null)
					{
						throw new ArgumentException($"Item {objectId} not declared in items repository.");
					}
					else
					{
						item.Moved += Item_Moved;
					}
					break;
				case DialogueItemTriggerType.ItemUsed:
					item = ((IItemRepository)_repository).Get(objectId);
					if (item == null)
					{
						throw new ArgumentException($"Item {objectId} not declared in items repository.");
					}
					else
					{
						item.Used += Item_Used;
					}
					break;
				case DialogueItemTriggerType.ChosenDialogue:
					dialogueItem = ((IRepository<DialogueItem>)_repository).Get(objectId);
					if (dialogueItem == null)
					{
						throw new ArgumentException($"Dialogue item {objectId} not declared in dialogue items repository.");
					}
					else
					{
						dialogueItem.Chosen += DialogueItem_Chosen;
					}
					break;
				default:
					// Should not happen (means the code is incomplete)
					throw new ApplicationException("Unhandled dialogue trigger");
			}
		}

		#region Events
		public event EventHandler PlayRequested;
		protected virtual void OnPlayRequested()
		{
			PlayRequested?.Invoke(this, EventArgs.Empty);
		}
		#endregion

		#region Events handling
		private void Scene_Activated(object sender, SceneEventArgs e)
		{
			OnPlayRequested();
		}

		private void Character_EnteredScene(object sender, CharacterEventArgs e)
		{
			// Play dialogue only if the character entered the scene specified in trigger's arguments.
			if (e.Character.IsInScene(argument1Id))
				OnPlayRequested();
		}

		private void DialogueItem_PlayFinished(object sender, DialogueItemEventArgs e)
		{
			OnPlayRequested();
		}

		private void Item_Moved(object sender, ItemMoveEventArgs e)
		{
			// Play dialogue only if the item has been moved from a given stuff holder to another given stuff holder.
			if (e.Source.id == argument1Id && e.Destination.id == argument2Id)
				OnPlayRequested();
		}

		private void Item_Used(object sender, ItemEventArgs e)
		{
			OnPlayRequested();
		}

		private void DialogueItem_Chosen(object sender, EventArgs e)
		{
			OnPlayRequested();
		}
		#endregion

	}
}
