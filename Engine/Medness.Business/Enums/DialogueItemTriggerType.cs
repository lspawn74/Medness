namespace Medness.Business.Enums
{
	public enum DialogueItemTriggerType
	{
		/// <summary>
		/// Triggs a dialogue when a specific scene activates.
		/// The trigger's id contains the expected scene's id.
		/// </summary>
		SceneActivated,

		/// <summary>
		/// Triggs a dialogue when a character enters the activated scene.
		/// The trigger's id contains the expected character's id.
		/// </summary>
		CharacterEnters,

		/// <summary>
		/// Triggs a dialogue when a dialogue finished.
		/// The trigger's id contains the expected dialogue's id.
		/// </summary>
		DialogueFinished,

		/// <summary>
		/// Triggs a dialogue when an item is moved.
		/// The trigger's id contains the expected dialogue's id.
		/// The argument's id continas the expected new holder of the item.
		/// </summary>
		ItemMoved,

		/// <summary>
		/// Triggs a dialogue when a dialogue is selected by the player.
		/// The trigger's id contains the expected dialogue's id.
		/// </summary>
		ChosenDialogue
	}
}
