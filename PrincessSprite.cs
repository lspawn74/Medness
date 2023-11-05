using Godot;
using Medness;

public partial class PrincessSprite : AnimatedSprite2D
{
	#region Injected nodes
	private GameMechanics _gameMechanics; // The game mechanics holds info like: which character is selected.
	private CharactersProperties _charactersProperties; // A dictionary holding all characters properties
	private CharacterBody2D _princessBody;
	#endregion

	#region Life Cycles
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Get game mechanics
		_gameMechanics = GetNode<GameMechanics>("/root/GameMechanics");

		_princessBody = GetParent<CharacterBody2D>();

		// Set character properties
		_charactersProperties = GetNode<CharactersProperties>("/root/CharactersProperties");
		CharacterProperties princessProperties = _charactersProperties.Properties[CharacterType.PRINCESS] = new CharacterProperties();
		princessProperties.Speed = 400.0; // Speed in pixels/s
		princessProperties.LeftOrientationOffset = Offset;
		princessProperties.RightOrientationOffset = Offset;

		// Do some processing when game is on
		SetProcess(true);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_princessBody.Velocity == Vector2.Zero)
			Play("idle");
		else
		{
			_gameMechanics.SetSide(this, _princessBody.Velocity.X < 0);
			Play("walk");
		}

		return;
	}
#endregion
}
