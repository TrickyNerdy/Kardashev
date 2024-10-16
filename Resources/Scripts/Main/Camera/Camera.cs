using Godot;
using System;

public partial class Camera : Godot.Camera2D
{

	float px;
	float py;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	
		
		
		px =  Approach(Position.X, GetLocalMousePosition().X, 70f );
		py =  Approach(Position.Y, GetLocalMousePosition().Y, 70f );

		Position = new Vector2(px,py);

		
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
	
