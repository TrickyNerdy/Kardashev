using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;

public partial class Background : Node2D
{

    [Export] 
    public Dictionary starList = new Dictionary();
    public Godot.Collections.Array<Node> starGroup;
    public override void _Ready()
	{
		 starGroup = GetTree().GetNodesInGroup("Stars");
	}

    public override void _PhysicsProcess(double delta)
    {
        foreach (var i in starGroup) 
        {
            Godot.Collections.Array dist =new ();
            dist.Add(GetNode<Camera2D>("Camera2D").Position.DistanceTo(GetNode<Node2D>(i.ToString()).Position));
            dist.Min();
            
        }
    }
}
