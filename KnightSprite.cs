using Godot;
using Medness;
using System;

public partial class KnightSprite : AnimatedSprite2D
{
	#region Injected nodes
	private GameMechanics gameMechanics; // The game mechanics holds info like: which character is selected.
	private CharactersProperties charactersProperties; // A dictionary holding all characters properties
	#endregion

	#region Life Cycles
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Set knight at the center of the screen
		Position = new Vector2(460.0f, 890.0f);

		// Scale knight
		Scale = new Vector2(0.25f, 0.25f);

		// Get game mechanics
		gameMechanics = GetNode<GameMechanics>("/root/GameMechanics");

		// Set character properties
		charactersProperties = GetNode<CharactersProperties>("/root/CharactersProperties");
		CharacterProperties knightProperties = charactersProperties.Properties[CharacterType.KNIGHT] = new CharacterProperties();
		knightProperties.Speed = 300.0; // Lateral speed (left/right) in pixels/s
		knightProperties.LeftOrientationOffset = new Vector2(-90.0f, -200.0f);
		knightProperties.RightOrientationOffset = new Vector2(90.0f, -200.0f);

		// Do some processing when game is on
		SetProcess(true);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (gameMechanics is null)
			return;

		if (gameMechanics.SelectedCharacterType != CharacterType.KNIGHT)
			return;

		if (Input.IsMouseButtonPressed(MouseButton.Left))
			gameMechanics.InitializeMovement(this, GetGlobalMousePosition());
		
		gameMechanics.Move(this, delta);
	}
	#endregion
}
