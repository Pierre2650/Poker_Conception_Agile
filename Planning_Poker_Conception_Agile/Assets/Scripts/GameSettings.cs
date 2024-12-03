using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    //Creer une structure pour minutes et secondes;
    // est ces attrubut
    public static string gameMode { get; set; }

    public static List<Backlog_Information> backlogList { get; set; } = new List<Backlog_Information>();

    public static int numberOfTasks = 0;

}
