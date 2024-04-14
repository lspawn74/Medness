using Godot;

public partial class PouchButton : TextureButton
{
	#region Injected nodes
	private SceneManager _sceneManager;
	#endregion

	#region Life cycles
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_sceneManager = GetNode<SceneManager>("/root/SceneManager");
		Pressed += PouchButton_Pressed;
	}
	#endregion

	#region Events handlers
	private void PouchButton_Pressed()
	{
		// Navigate to the pouch of the current character
		_sceneManager.SwitchToStuff();
	}
	#endregion
}
