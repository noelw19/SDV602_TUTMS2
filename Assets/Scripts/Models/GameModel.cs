using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;



using System.Text;

// Is this a factory?

public static class GameModel
{

	static String _name;

	public static string Name{
		get 
		{ 
			return _name;  
		}
		set{
			_name = value; 
		}

	}

    public static Location currentLocale;
    public static Location startLocation;
    public static Player currentPlayer;
    public static DataService ds = new DataService("Tut2DATABASE.db");

    public static void testDatabase()
    {
        ds.CreateDB();
        var people = ds.GetPersons();
        foreach(Person p in people)
        {
            Debug.Log(p.Age + "," + p.Name);
        }

        var locations = ds.GetLocations();
        foreach(Location l in locations)
        {
            Debug.Log(l.Id  + "," + l.Name +"," + l.Story);
        }
    }
    public static void MakeGame()
    {
        Location forest, castle;
        currentLocale = new Location
        {
            Name = "Forest",
            Story = " Run!!"
        };
        forest = currentLocale;

        forest.addLocation("North", "Castle", "Crocodiles");

        castle = forest.getLocation("North");
        castle.addLocation("South", forest);

    }

}

