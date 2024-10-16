using Godot;
using System;

public partial class Sys : Node2D
{
    [Export]
    Node2D Sol = new Node2D();
    [Export]
    Node2D Planets = new Node2D();
    [Export]
    Node2D Gates = new Node2D();
    

    public override void _Ready()
	{
		
	}
}
