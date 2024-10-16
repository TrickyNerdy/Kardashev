using Godot;
using Godot.Collections;
using System;
using System.Text.Json;


public partial class MainOld : Node2D
{

	public class Star<T, U>
	{
		public String DisplayName { get; set; }
		public float Xg { get; set; }
		public float Yg { get; set; }
		public float Zg { get; set; }
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var fps = DisplayServer.ScreenGetRefreshRate();
		Engine.MaxFps = (int)fps;
		Engine.PhysicsJitterFix = 1;
		Engine.PhysicsTicksPerSecond = 144;

		//Set the window to the center of the screen and focus the mouse to the window
		
		var myjson = ReadJsonFile("res://Resources/Data/stars.json");
		var stars = JsonSerializer.Deserialize<Star<string, Vector3>[]>(myjson);
		calculateNeareStar(stars);
		GD.Print("Hello, World!");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public string ReadJsonFile(string path)
	{
		var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
		string jsoncontent = file.GetAsText();
		return jsoncontent;
	}
	
	//calculate each star's two nearest neighbors and print them to the console
	public void calculateNeareStar(Star<string, Vector3>[] stars)
	{
		for (int i = 0; i < stars.Length; i++)
		{
			float minDistance = float.MaxValue;
			float secondMinDistance = float.MaxValue;
			int minIndex = 0;
			int secondMinIndex = 0;
			for (int j = 0; j < stars.Length; j++)
			{
				if (i != j)
				{
					float distance = (stars[i].Xg - stars[j].Xg) * (stars[i].Xg - stars[j].Xg) + (stars[i].Yg - stars[j].Yg) * (stars[i].Yg - stars[j].Yg) + (stars[i].Zg - stars[j].Zg) * (stars[i].Zg - stars[j].Zg);
					if (distance < minDistance)
					{
						secondMinDistance = minDistance;
						secondMinIndex = minIndex;
						minDistance = distance;
						minIndex = j;
					}
					else if (distance < secondMinDistance)
					{
						secondMinDistance = distance;
						secondMinIndex = j;
					}
				}
			}
			GD.Print("Star: " + stars[i].DisplayName + " has two nearest neighbors: " + stars[minIndex].DisplayName + " and " + stars[secondMinIndex].DisplayName);
		}	
	}
}
