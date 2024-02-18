using Godot;
using System;

public partial class Camera2D : Godot.Camera2D
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	
		Position = GetLocalMousePosition().Round();


		if(Input.IsActionJustReleased("Middle"))
		{
			switch(Zoom)
			{
			case Vector2(1f,1f):
				Zoom = new Vector2(1.5f,1.5f);
				break;
			case Vector2(1.5f,1.5f):
				Zoom = new Vector2(2,2);
				break;
			case Vector2(2f,2f):
				Zoom = new Vector2(3,3);
				break;
			case Vector2(3,3):
				Zoom = new Vector2(1,1);
				break;
			}
			
		}
	}
	public float Approach(float start, float end, float shift)
	{
		if (start < end)
			return Math.Min(start + shift, end); 
		else
			return Math.Max(start - shift, end);
	}
}
	
