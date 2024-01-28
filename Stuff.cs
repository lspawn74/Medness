using Godot;
using System.Collections.Generic;

namespace Medness
{
	/// <summary>
	/// Stuff carried by a character.
	/// </summary>
	public partial class Stuff : Node
	{
		public List<Object> Objects { get; set; } = new List<Object>();

		// Called when the node enters the scene tree for the first time.
		public override void _Ready()
		{
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}
	}
}
