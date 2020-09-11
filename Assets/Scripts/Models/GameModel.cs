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
    
    public static Player currentPlayer;
    public static Location startLocation;
    public static DataService ds = new DataService("Tut2DATABASE.db");

    public static void SetupGame()
    {
        ds.CreateDB();

    }
    public static void MakeGame()
    {
        // Only make a  game if we dont have locations
        if (!GameModel.ds.haveLocations()) {

            Location forest, castle;
            currentLocale = GameModel.ds.storeNewLocation("Forest", " Run!! ");

            forest = currentLocale;

            forest.addLocation("North", "Castle", "Crocodiles");

            castle = forest.getLocation("North");
            castle.addLocation("South", forest);


            // Make a player record
            currentPlayer = GameModel.ds.storeNewPlayer("no name yet", "no password",
                                                         currentLocale.Id, 100, 0);
            startLocation = currentLocale; // this might be redundant
        }
        else
        {
            currentPlayer = GameModel.ds.getPlayer("no name yet"); // will add a variable for player name
            currentLocale = GameModel.ds.GetLocation(currentPlayer.LocationId);
        }

    }

}

