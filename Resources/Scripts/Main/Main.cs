using Godot;
using System;

public partial class Main : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var fps = DisplayServer.ScreenGetRefreshRate();
		Engine.MaxFps = (int)fps;
		Engine.PhysicsJitterFix = 1;
		Engine.PhysicsTicksPerSecond = 144;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
