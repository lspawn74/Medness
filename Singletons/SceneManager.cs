using Godot;
using Medness.Enums;
using Medness.Singletons;
using System;
using System.Collections.Generic;

public partial class SceneManager : Node
{
	// Root viewport
	Window _root;

	// packed scenes
	private Node _stuffScene;
	private Node _theGameScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_root = GetTree().Root;
		_stuffScene = ResourceLoader.Load<PackedScene>("res://Stuff.tscn").Instantiate();
	}

	public void SwitchToStuff()
	{
		if (_theGameScene == null)
			_theGameScene = GetTree().CurrentScene;

		_root.RemoveChild(_theGameScene);
		_root.AddChild(_stuffScene);
	}

	public void SwitchToGame()
	{
		_root.RemoveChild(_stuffScene);
		_root.AddChild(_theGameScene);
	}
}
