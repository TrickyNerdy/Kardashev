using Godot;
using System;

public partial class Sol : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var collectibleScene = ResourceLoader.Load<PackedScene>("res://Star.tscn");
		var collectible = collectibleScene.Instantiate();
		AddChild(collectible);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
