using Godot;
using Medness;

public partial class PrincessSprite : AnimatedSprite2D
{
	#region Injected nodes
	private GameMechanics gameMechanics; // The game mechanics holds info like: which character is selected.
	private CharactersProperties charactersProperties; // A dictionary holding all characters properties
	#endregion

	#region Life Cycles
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Set sprite position
		Position = new Vector2(345.0f, 900.0f);

		// Scale sprite
		Scale = new Vector2(0.14f, 0.14f);

		// Get game mechanics
		gameMechanics = GetNode<GameMechanics>("/root/GameMechanics");

		// Set character properties
		charactersProperties = GetNode<CharactersProperties>("/root/CharactersProperties");
		CharacterProperties princessProperties = charactersProperties.Properties[CharacterType.PRINCESS] = new CharacterProperties();
		princessProperties.LateralSpeed = 300.0; // Lateral speed (left/right) in pixels/s
		princessProperties.LongitudinalSpeed = 100.0; // Longitudinal speed (up/down) in pixels/s
		princessProperties.LeftOrientationOffset = Offset;
		princessProperties.RightOrientationOffset = Offset;

		// Do some processing when game is on
		SetProcess(true);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (gameMechanics is null)
			return;

		if (gameMechanics.SelectedCharacterType != CharacterType.PRINCESS)
			return;

		if (Input.IsMouseButtonPressed(MouseButton.Left))
			gameMechanics.InitializeMovement(this, GetGlobalMousePosition());

		gameMechanics.Move(this, delta);
	}
	#endregion
}
