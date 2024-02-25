using Godot;
using Medness.Enums;
using Medness.Singletons;

namespace Medness
{
	public partial class PlayableCharacter : CharacterBody2D
	{
		#region Properties
		/// <summary>Gets or sets Character type (exported to be set with properties inspector in Godot)</summary>
		[Export]
		public Character Character { get; set; }
		#endregion

		#region Injected nodes
		private Globals _globals; // Global data usable across all scenes
		#endregion

		#region Private fields
		private Vector2 _targetPosition = Vector2.Zero;
		public CharacterProperties _characterProperties;
		#endregion

		#region Life cycles
		public override void _Ready()
		{
			// Set initial velocity
			Velocity = Vector2.Zero;

			// Get character properties
			_globals = GetNode<Globals>("/root/Globals");
			_characterProperties = _globals.CharactersProperties[Character];

			// Set initial target position to current global position
			// This will prevent character to move for no reason.
			_targetPosition = GlobalPosition;
		}

		public override void _PhysicsProcess(double delta)
		{
			if (_globals.CurrentCharacter != Character)
				return;

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
				velocity = direction * _characterProperties.Speed;

				// Set animation direction
				if (Mathf.Abs(direction.X) < Mathf.Abs(direction.Y))
				{
					if (direction.Y < 0)
						_characterProperties.AnimationDirection = CharacterAnimationDirection.BACK;
					else
						_characterProperties.AnimationDirection = CharacterAnimationDirection.FACE;
				}
				else
				{
					if (direction.X < 0)
						_characterProperties.AnimationDirection = CharacterAnimationDirection.LEFT;
					else
						_characterProperties.AnimationDirection = CharacterAnimationDirection.RIGHT;
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
