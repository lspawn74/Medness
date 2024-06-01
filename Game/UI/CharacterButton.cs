using Godot;
using Medness.Enums;
using Medness.Singletons;
using System.Linq;

public partial class CharacterButton : TextureButton
{
	#region Injected nodes
	private Globals _globals; // Global data usable across all scenes
	#endregion

	#region Life cycle
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get global node
		_globals = GetNode<Globals>("/root/Globals");

		Pressed += CharacterButton_Pressed;
	}
	#endregion

	#region Events handlers
	private void CharacterButton_Pressed()
	{
		// Select next available character in the scene
		if (_globals == null)
			return;

		// Switch current character in the list of availbale characters
		SwitchToNextCharacter();

		// Update current character's portrait
		TextureNormal = _globals.CurrentCharacterPortrait;
	}
	#endregion

	#region Subroutines
	private void SwitchToNextCharacter()
	{
		if (_globals.CurrentCharacter == _globals.AvailableCharacters.Last())
		{
			_globals.CurrentCharacter = _globals.AvailableCharacters.First();
			return;
		}
		Character nextCharacter = _globals.AvailableCharacters.SkipWhile(c => c != _globals.CurrentCharacter).Skip(1).First();
		_globals.CurrentCharacter = nextCharacter;
	}
	#endregion
}
