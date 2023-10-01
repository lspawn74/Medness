using Godot;
using Medness;
using System.Collections.Generic;

public partial class CharactersProperties : Node
{
	public Dictionary<CharacterType, CharacterProperties> Properties { get; set; } = new Dictionary<CharacterType, CharacterProperties>();
}

public class CharacterProperties
{
	public Vector2 LeftOrientationOffset { get; set; }

	public Vector2 RightOrientationOffset { get; set; }

	public double LateralSpeed { get; set; }

	public double LongitudinalSpeed { get; set; }
}

