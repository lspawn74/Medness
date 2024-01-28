using Godot;
using Medness;

namespace Medness
{
	public partial class Princess : CharacterBody2D
	{
		public float Speed = 400.0f;

		#region Injected nodes
		private GameMechanics _gameMechanics; // The game mechanics holds info like: which character is selected.
		private CharactersProperties _charactersProperties; // A dictionary holding all characters properties

		// Get the gravity from the project settings to be synced with RigidBody nodes.
		public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
		#endregion

		#region Private fields
		private Vector2 _targetPosition = Vector2.Zero;
		#endregion

		#region Life cycles
		public override void _Ready()
		{
			// Set initial velocity
			Velocity = Vector2.Zero;

			// Get character properties
			_charactersProperties = GetNode<CharactersProperties>("/root/CharactersProperties");

			// Set initial target position to current global position
			// This will prevent character to move for no reason.
			_targetPosition = GlobalPosition;
		}

		public override void _PhysicsProcess(double delta)
		{
			Vector2 velocity = Velocity;

			// Get mouse click as a target
			if (Input.IsMouseButtonPressed(MouseButton.Left))
				_targetPosition = GetGlobalMousePosition();

			// Get the input direction
			Vector2 direction = GlobalPosition.DirectionTo(_targetPosition);

			// Depending on the error between current position and target position, set the velocity
			Vector2 errorPosition = GlobalPosition - _targetPosition;
			if (Mathf.Abs(errorPosition.X) > 5 || Mathf.Abs(errorPosition.Y) > 5)
			{
				velocity = direction * Speed;

				// Set animation direction
				if (Mathf.Abs(direction.X) < Mathf.Abs(direction.Y))
				{
					if (direction.Y < 0)
						_charactersProperties.Properties[CharacterType.PRINCESS].AnimationDirection = CharacterAnimationDirection.BACK;
					else
						_charactersProperties.Properties[CharacterType.PRINCESS].AnimationDirection = CharacterAnimationDirection.FACE;
				}
				else
				{
					if (direction.X < 0)
						_charactersProperties.Properties[CharacterType.PRINCESS].AnimationDirection = CharacterAnimationDirection.LEFT;
					else
						_charactersProperties.Properties[CharacterType.PRINCESS].AnimationDirection = CharacterAnimationDirection.RIGHT;
				}
			}
			else
			{
				// We arrived at destination. Stop movement.
				velocity = Vector2.Zero;
			}

			// Set the computed velocity as new velocity for the character body
			Velocity = velocity;

			// Move and find info about collisions
			KinematicCollision2D collision = MoveAndCollide(velocity * (float)delta);

			// If we collided on an obstacle, we stop by setting the target position to 
			// the current position
			if (collision != null)
				_targetPosition = GlobalPosition;
		}
		#endregion
	}
}
