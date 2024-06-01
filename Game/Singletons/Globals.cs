using Godot;
using Medness.Enums;
using System.Collections.Generic;

namespace Medness.Singletons
{
	/// <summary>Global data that is used in all scenes of the game.</summary>
	public partial class Globals : Node
	{
		#region Fields
		private Character _currentCharacter;
		private Dictionary<Character, Texture2D> _characterPortraits;
		#endregion

		#region Properties
		/// <summary>Gets or sets characters properties such as their walking speed or the stuff they hold, etc...</summary>
		public Dictionary<Character, CharacterProperties> CharactersProperties { get; set; } = new Dictionary<Character, CharacterProperties>();

		public Character CurrentCharacter
		{
			get { return _currentCharacter; }
			set { SetCurrenCharacter(value); }
		}

		public Texture2D CurrentCharacterPortrait { get; private set; }

		// Characters available in the game (this list extends when new characters are unlocked)
		public List<Character> AvailableCharacters { get; } = new List<Character>() { Character.ANSGARDE, Character.ALDEMARE };

		#endregion

		#region Life Cycles
		public override void _Ready()
		{
			// Initialize characters portraits
			_characterPortraits = new Dictionary<Character, Texture2D>()
			{
				{ Character.ANSGARDE, (Texture2D)ResourceLoader.Load("res://Assets/princess/Blender/Ansgarde_portrait.png") },
				{ Character.ALDEMARE, (Texture2D)ResourceLoader.Load("res://Assets/knight/Blender/Aldemar_portrait.png") }
			};

			CharactersProperties[Character.ANSGARDE] = new CharacterProperties();
			CharactersProperties[Character.ANSGARDE].Speed = 400.0f;
			CharactersProperties[Character.ANSGARDE].AnimationDirection = CharacterAnimationDirection.FACE;

			CharactersProperties[Character.ALDEMARE] = new CharacterProperties();
			CharactersProperties[Character.ALDEMARE].Speed = 400.0f;
			CharactersProperties[Character.ALDEMARE].AnimationDirection = CharacterAnimationDirection.FACE;

			CurrentCharacter = Character.ANSGARDE;
		}
		#endregion

		#region Subroutines
		private void SetCurrenCharacter(Character newValue)
		{
			_currentCharacter = newValue;
			CurrentCharacterPortrait = _characterPortraits[_currentCharacter];
		}
		#endregion
	}
}
