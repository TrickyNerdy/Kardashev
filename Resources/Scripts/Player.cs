using Godot;
using Microsoft.VisualBasic.FileIO;
using System;

public partial class Player : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	float speed = .8f;
	Vector2 _movement = Vector2.Zero;
	float vx;
	float vy;
	float accel = 0.02f;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		var kLeft        = Input.IsKeyPressed(Key.A);
		var kRight       = Input.IsKeyPressed(Key.D);
		var kUp          = Input.IsKeyPressed(Key.W);
		var kDown        = Input.IsKeyPressed(Key.S);
       	
		if(kRight && !kLeft)
		{
			vx = Approach(vx, speed, accel);
		}
		if(kLeft && !kRight)
		{
			vx = Approach(vx, -speed, accel);
		}
		if(kUp && !kDown)
		{
			vy = Approach(vy, -speed, accel);
		}
		if(kDown && !kUp)
		{
			vy= Approach(vy, speed, accel);
		}

		if (!kRight && !kLeft)
    		vx = Approach(vx, 0, accel);

		if (!kUp && !kDown)
			vy = Approach(vy, 0, accel); 
		
	}

    public override void _PhysicsProcess(double delta)
    {
		Vector2 ww = new Vector2(vx,vy);
		MoveAndCollide(ww*(speed*((float)delta * 1000.0f)));

		LookAt(GetGlobalMousePosition());
	}
	public float Approach(float start, float end, float shift)
	{
		if (start < end)
			return Math.Min(start + shift, end); 
		else
			return Math.Max(start - shift, end);
	}

}
