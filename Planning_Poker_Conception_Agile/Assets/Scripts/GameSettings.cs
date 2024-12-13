using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    public static string gameMode { get; set; }

    public static int numberOfPlayers { get; set; } = 0;

    public static List<string> playerNames {  get; set; } = new List<string>();

    public static int[] choiceTimer { get; set; } = new int[2];
    public static int[] debateTimer { get; set; } = new int[2];

    public static List<Backlog_Information> backlogList { get; set; } = new List<Backlog_Information>();
    public static int numberOfTasksToEvalute { get; set; } = 0;
    public static int numberOfTaskEvaluted { get; set; } = 0;




}
