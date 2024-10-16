using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

public partial class test : Node2D
{
	public Dictionary gameSaveFile;
	[Export]
	public float fps;
	[Export]
	public Dictionary gameSave = new Godot.Collections.Dictionary
	{
		{"Coords", new Godot.Collections.Dictionary
			{
				{"Xg", 0},
				{"Yg", 0},
				{"Zg", 0},
			}
		},
		{"ShipInfo", new Godot.Collections.Dictionary
			{
				{"Ship Class", 0},
				{"Ship", 0},
				{"Livery", 0},
				{"Invetory", new Godot.Collections.Dictionary
					{
						{"Tools", new Godot.Collections.Dictionary
							{
								{"Slots", 0},
							}
						},
						{"Weapons", new Godot.Collections.Dictionary
							{
								{"Slots", 0},
							}
							
						},
						{"Storage", new Godot.Collections.Dictionary
							{
								{"Bays", 0},
							}
						}
					}
				}
			}
		},
	};
	public override void _Ready()
	{
		setScreenRate();
		loadGameSave();
	}

    private void loadGameSave()
    {	
		int zero = 0;
        string path = ProjectSettings.GlobalizePath("user://");
		gameSaveFile = loadSave(path,"SaveGame1.json");
		
		foreach(string key in gameSave.Keys)
		{
			if(gameSave[key].AsGodotDictionary() != gameSaveFile[key].AsGodotDictionary())
			{
				gameSave[key] = gameSaveFile[key];
				SaveTextToFile(path,"SaveGame1.json",gameSave);
			}
		}
		
			gameSave = loadSave(path,"SaveGame1.json");
			GD.Print(gameSave.Keys);
	}
    private void setScreenRate()
	{	
		if(fps==0)
		{
			fps = DisplayServer.ScreenGetRefreshRate();
		}
		Engine.MaxFps = (int)fps;
		Engine.PhysicsJitterFix = 1;
		Engine.PhysicsTicksPerSecond = (int)fps;
	}

	private Dictionary loadSave(string path, string file )
	{
		
		string loadedData = (LoadTextFromFile(path,file));

		Json jsonLoader = new Json();
		Error error = jsonLoader.Parse(loadedData);

		if(error != Error.Ok)
		{
			GD.Print(error);
		}

		Dictionary loadedDataDict = (Dictionary)jsonLoader.Data;
		
		return loadedDataDict;
	}

	public override void _Process(double delta)
	{
		
	}

	private void SaveTextToFile(string path, string fileName, Dictionary data)
	{	

		if(!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}

		path = Path.Join(path, fileName);
		try
		{

            File.WriteAllText(path, Json.Stringify(data));
		} 
		catch (System.Exception e)
		{
			GD.Print(e);
		}

	}
	private string LoadTextFromFile(string path, string fileName)
	{
		string data = null;

		path = Path.Join(path, fileName);
		if(!File.Exists(path)) return null;
		
		try{
			data = File.ReadAllText(path);
		}
		catch(System.Exception e)
		{
			GD.Print(e);
		}

		return data;

	}
};
	