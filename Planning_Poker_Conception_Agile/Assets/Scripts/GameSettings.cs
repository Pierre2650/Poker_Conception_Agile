using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    public static string gameMode { get; set; } = "Strict";

    public static int numberOfPlayers { get; set; } = 0;

    public static List<string> playerNames {  get; set; } = new List<string>();

    public static int[] choiceTimer { get; set; } = new int[2];
    public static int[] debateTimer { get; set; } = new int[2];

    public static List<Backlog_Information> backlogList { get; set; } = new List<Backlog_Information>();

    public static Backlog_Information taskBeingEvaluated { get; set; } = new Backlog_Information();
    public static int numberOfTasksToEvalute { get; set; } = 0;
    public static int numberOfTaskEvaluted { get; set; } = 0;


    public static void countTasks()
    {
        numberOfTaskEvaluted = 0;
        numberOfTasksToEvalute = 0;
        foreach (Backlog_Information task in backlogList)
        {
            if (task.Value != "None")
            {
                numberOfTaskEvaluted++;
            }
            else
            {
                numberOfTasksToEvalute++;
            }

        }
    }

    public static void reset()
    {
        gameMode = "Strict";
        numberOfPlayers = 0;
        playerNames.Clear();

        for (int i = 0; i < 2; i++) { 
            choiceTimer[i] = 0;
            debateTimer[i] = 0;
        }

        backlogList.Clear();

        taskBeingEvaluated = new Backlog_Information();

        numberOfTaskEvaluted = 0;
        numberOfTasksToEvalute = 0;

    }




}
