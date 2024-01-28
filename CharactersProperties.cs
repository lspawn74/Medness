using Godot;
using Medness;
using System.Collections.Generic;

namespace Medness
{
	public partial class CharactersProperties : Node
	{
		public Dictionary<CharacterType, CharacterProperties> Properties { get; set; } = new Dictionary<CharacterType, CharacterProperties>();
	}

	public class CharacterProperties
	{
		public double Speed { get; set; }

		public CharacterAnimationDirection AnimationDirection { get; set; }

		public Stuff Stuff { get; set; }
	}
}
