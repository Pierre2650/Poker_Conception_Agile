using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    private static string gameMode { get; set; }



    public static string GameMode
    {
        get
        {
            return gameMode; // Return the value of the private field
        }
        set
        {

            gameMode = value; // Assign value to the private field

        }


    }
}
