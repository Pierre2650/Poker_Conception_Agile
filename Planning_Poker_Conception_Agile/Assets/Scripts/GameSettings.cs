using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui va permetre de charger un fichier JSON avec un Backlog avec des taches a valider et taches deja validee.
*/
public static class GameSettings
{
    /**@class GameSettings.
   * @brief Classe qui va servir comme la configuration globale pour sauvegarder les paramètres du jeu. Elle va pouvoir etre accedes entre les differentes Scenes.
   * 
   * @var string gameMode
   * @brief  Mode de jeu selectionne.
   *
   * @var int numberOfPlayers
   * @brief Nombre total de joueurs.
   *
   * @var List<string> playerNames
   * @brief Noms des joueurs.
   *
   * @var int[] choiceTimer
   * @brief Chronometre pour le choix des joueurs.
   *
   * @var int[] debateTimer
   * @brief Chronometre pour les debats.
   *
   * @var List<Backlog_Information> backlogList
   * @brief Liste des tâches dans le backlog.
   *
   * @var Backlog_Information taskBeingEvaluated
   * @brief Tâche actuellement en cours d'evaluation.
   *
   * @var int numberOfTasksToEvalute
   * @brief Nombre total de taches a evaluer.
   *
   * @var int numberOfTaskEvaluted
   * @brief Nombre de taches évaluées.
   */

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
        ///@brief Methode qui met a jour le nombre total de taches a evaluer et deja evalue
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
        ///@brief Methode qui reinitialise tout les variables
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
