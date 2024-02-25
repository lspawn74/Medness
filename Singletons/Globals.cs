using Godot;
using Medness.Enums;
using System.Collections.Generic;

namespace Medness.Singletons
{
	/// <summary>Global data that is used in all scenes of the game.</summary>
	public partial class Globals : Node
	{
		/// <summary>Gets or sets characters properties such as their walking speed or the stuff they hold, etc...</summary>
		public Dictionary<Character, CharacterProperties> CharactersProperties { get; set; } = new Dictionary<Character, CharacterProperties>();

		public Character CurrentCharacter { get; set; }

		public override void _Ready()
		{
			CharactersProperties[Character.ANSGARDE] = new CharacterProperties();
			CharactersProperties[Character.ANSGARDE].Speed = 400.0f;
			CharactersProperties[Character.ANSGARDE].AnimationDirection = CharacterAnimationDirection.FACE;

			CharactersProperties[Character.ALDEMARE] = new CharacterProperties();
			CharactersProperties[Character.ALDEMARE].Speed = 400.0f;
			CharactersProperties[Character.ALDEMARE].AnimationDirection = CharacterAnimationDirection.FACE;

			CurrentCharacter = Character.ANSGARDE;
		}

	}
}
