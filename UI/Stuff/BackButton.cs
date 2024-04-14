using Godot;
using System;

public partial class BackButton : Button
{
	#region Injected nodes
	SceneManager _sceneManager;
	#endregion

	#region Life cycles
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sceneManager = GetNode<SceneManager>("/root/SceneManager");
		Pressed += BackButton_Pressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	#endregion

	#region Event handlers
	private void BackButton_Pressed()
	{
		_sceneManager.SwitchToGame();
	}
	#endregion
}
