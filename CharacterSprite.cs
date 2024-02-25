using Godot;
using Medness.Enums;
using Medness.Singletons;
using System.Collections.Generic;

namespace Medness
{

	public partial class CharacterSprite : AnimatedSprite2D
	{
		#region Injected nodes
		private PlayableCharacter _parentNode;
		private Globals _globals; // Global data usable across all scenes
		private CharacterProperties _characterProperties;
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
			_parentNode = (PlayableCharacter)GetParent<CharacterBody2D>();

			// Get character properties
			_globals = GetNode<Globals>("/root/Globals");
			_characterProperties = _globals.CharactersProperties[_parentNode.Character];

			// Do some processing when game is on
			SetProcess(true);
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			if (_parentNode.Velocity == Vector2.Zero)
			{
				Play(_idleAnimations[_characterProperties.AnimationDirection]);
			}
			else
			{
				Play(_walkAnimations[_characterProperties.AnimationDirection]);
			}

			return;
		}
		#endregion
	}
}
