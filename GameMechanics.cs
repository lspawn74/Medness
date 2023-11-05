using Godot;
using Medness;
using System.Collections.Generic;

public partial class GameMechanics : Node
{
	#region Fields
	private bool isMoving = false; // Flag indicating the sprite is in movement
	private Vector2 targetPosition; // The position the sprite have to reach
	#endregion

	#region Injected Nodes
	private CharactersProperties charactersProperties;
	#endregion

	#region Properties
	public CharacterType SelectedCharacterType { get; set; } = CharacterType.PRINCESS;
	#endregion

	#region Life Cycles
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		charactersProperties = GetNode<CharactersProperties>("/root/CharactersProperties");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
	}
	#endregion

	#region Actions
	// Initializes a sprite movement by setting the isMoving flag and the target position
	// on the screen.
	// NB : The sprite node is responsible for not calling this method
	// if it's not the currently selected character.
	public void InitializeMovement(AnimatedSprite2D sprite, Vector2 target)
	{
		targetPosition = target;
		isMoving = true;
	}

	// Moves a character sprite to the location clicked by the mouse.
	// NB : The sprite node is responsible for not calling this method
	// if it's not the currently selected character.
	public void Move(AnimatedSprite2D sprite, double delta)
	{
	}

	// Sets the horizontal side of the sprite
	// If the argument flip is true, the sprite is turned towards left.
	public void SetSide(AnimatedSprite2D sprite, bool flip)
	{
		if (flip)
		{
			sprite.Offset = charactersProperties.Properties[SelectedCharacterType].LeftOrientationOffset;
		}
		else
		{
			sprite.Offset = charactersProperties.Properties[SelectedCharacterType].RightOrientationOffset;
		}
		sprite.FlipH = flip;
	}
	#endregion
}
