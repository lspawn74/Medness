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
	public override void _Process(double delta)
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
		// Compute the position error between current position and target position
		float xError = targetPosition.X - sprite.Position.X;
		if (Mathf.Abs(xError) <= 10.0f)
		{
			sprite.Translate(new Vector2(xError, 0.0f));
			xError = 0.0f;
		}

		// Movement stopping criterias
		float yError = targetPosition.Y - sprite.Position.Y;
		if (Mathf.Abs(yError) <= 10.0f)
		{
			sprite.Translate(new Vector2(0.0f, yError));
			yError = 0.0f;
		}

		if (xError == 0.0f && yError == 0.0f)
			isMoving = false;

		// Movement
		if (isMoving)
		{
			sprite.Play("walk");

			SetSide(sprite, Mathf.Sign(xError) < 0);

			double lateralSpeed = charactersProperties.Properties[SelectedCharacterType].LateralSpeed;
			double longitudinalSpeed = charactersProperties.Properties[SelectedCharacterType].LongitudinalSpeed;

			// Move to minimize the position error
			sprite.Translate(new Vector2(
				(float)(delta * lateralSpeed * (double)Mathf.Sign(xError) * (double)Mathf.Min(1.0f, Mathf.Abs(xError))),
				(float)(delta * longitudinalSpeed * (double)Mathf.Sign(yError) * (double)Mathf.Min(1.0f, Mathf.Abs(yError)))
				));
		}
		else
		{
			sprite.Play("idle");
		}
	}

	// Sets the horizontal side of the sprite
	// If the argument flip is true, the sprite is turned towards left.
	private void SetSide(AnimatedSprite2D sprite, bool flip)
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
