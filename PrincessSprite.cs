using Godot;
using Godot.Collections;
using Medness;

namespace Medness
{
	public partial class PrincessSprite : AnimatedSprite2D
	{
		#region Injected nodes
		private GameMechanics _gameMechanics; // The game mechanics holds info like: which character is selected.
		private CharactersProperties _charactersProperties; // A dictionary holding all characters properties
		private CharacterBody2D _princessBody;
		#endregion

		#region Private fields
		private Dictionary<CharacterAnimationDirection, string> _idleAnimations = new Dictionary<CharacterAnimationDirection, string>()
	{
		{ CharacterAnimationDirection.FACE, "idle_face" },
		{ CharacterAnimationDirection.BACK, "idle_back" },
		{ CharacterAnimationDirection.LEFT, "idle_left" },
		{ CharacterAnimationDirection.RIGHT, "idle_right" },
	};
		private Dictionary<CharacterAnimationDirection, string> _walkAnimations = new Dictionary<CharacterAnimationDirection, string>()
	{
		{ CharacterAnimationDirection.FACE, "walk_face" },
		{ CharacterAnimationDirection.BACK, "walk_back" },
		{ CharacterAnimationDirection.LEFT, "walk_left" },
		{ CharacterAnimationDirection.RIGHT, "walk_right" },
	};
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
			princessProperties.AnimationDirection = CharacterAnimationDirection.FACE;

			// Do some processing when game is on
			SetProcess(true);
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			if (_princessBody.Velocity == Vector2.Zero)
			{
				Play(_idleAnimations[_charactersProperties.Properties[CharacterType.PRINCESS].AnimationDirection]);
			}
			else
			{
				Play(_walkAnimations[_charactersProperties.Properties[CharacterType.PRINCESS].AnimationDirection]);
			}

			return;
		}
		#endregion
	}
}
