using Godot;
using Medness.Enums;
using Medness.Singletons;
using System;
using System.Collections.Generic;
using System.Threading;

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

		// Idle animations
		private Dictionary<CharacterAnimationDirection, string> _idleAnimations = new Dictionary<CharacterAnimationDirection, string>()
		{
			{ CharacterAnimationDirection.FACE, "idle_face" },
			{ CharacterAnimationDirection.BACK, "idle_back" },
			{ CharacterAnimationDirection.LEFT, "idle_left" },
			{ CharacterAnimationDirection.RIGHT, "idle_right" },
		};

		// Small moves made randomly when in idle for too long (up to 3 small moves)
		private Random _randomMove = new Random();
		private Random _randomStartTime = new Random();
		private StringName _currentSmallMove;
		private List<Dictionary<CharacterAnimationDirection, string>> _idleSmallMoves = new List<Dictionary<CharacterAnimationDirection, string>>()
		{
			// Eyes blinking
			new Dictionary<CharacterAnimationDirection, string>()
			{
				{ CharacterAnimationDirection.FACE, "face_blink" },
				{ CharacterAnimationDirection.BACK, "idle_back" },
				{ CharacterAnimationDirection.LEFT, "left_blink" },
				{ CharacterAnimationDirection.RIGHT, "right_blink" },
			}
		};

		// Walking movements animations
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

			// Set random start time for small moves (start time in seconds since the idle time of the character)
			ResetSmallMoves();

			// Do some processing when game is on
			SetProcess(true);
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
			if (_parentNode.Velocity == Vector2.Zero)
			{
				if (this.Animation == _currentSmallMove)
				{
					int framesCount = this.SpriteFrames.GetFrameCount(_currentSmallMove);
					if (this.Frame == framesCount - 1)
					{
						ResetSmallMoves();
						Play(_idleAnimations[_characterProperties.AnimationDirection]);
					}
				}
				else
				{
					Play(_idleAnimations[_characterProperties.AnimationDirection]);
				}
				if (_parentNode.IdleTimeCounter >= _characterProperties.SmallMoveStartTime)
				{
					_currentSmallMove = _idleSmallMoves[_randomMove.Next(_idleSmallMoves.Count)][_characterProperties.AnimationDirection] ;
					Play(_currentSmallMove);
					_parentNode.IdleTimeCounter = 0.0;
				}
			}
			else
			{
				Play(_walkAnimations[_characterProperties.AnimationDirection]);
			}

			return;
		}
		#endregion

		#region Subroutines
		private void ResetSmallMoves()
		{
			// Reset current small move to nothing
			_currentSmallMove = "";

			// Set random start time for small moves (start time in seconds since the idle time of the character)
			_characterProperties.SmallMoveStartTime = _randomStartTime.Next(5) + 1;
		}
		#endregion
	}
}
