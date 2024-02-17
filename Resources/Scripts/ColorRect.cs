using Godot;
using System;

public partial class ColorRect : Godot.ColorRect
{

	private bool mousein;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Color = new Godot.Color(1, 0, 0, 1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
	private void _on_mouse_entered()
    {
		mousein = true;
        Color = new Godot.Color(1, 0, 0, 1);
	}	
    
    private void _on_mouse_exited()
    {
		mousein = false;
        Color = new Godot.Color(1, 1, 1, 1);
	}

}