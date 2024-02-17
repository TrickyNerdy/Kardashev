using Godot;
using System;

public partial class UI : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//var scene = GD.Load<PackedScene>("res://UI.tscn"); var inst = scene.Instantiate(); AddChild(inst);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
