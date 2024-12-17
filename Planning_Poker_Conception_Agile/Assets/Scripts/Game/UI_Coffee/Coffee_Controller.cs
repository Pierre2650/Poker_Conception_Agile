using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coffee_Controller : MonoBehaviour
{
    [Header("Continue")]
    public GameObject current;
    public GameObject[] continueGame = new GameObject[2];


    [Header("Path Folder")]
    public GameObject objFilePath;
    private TMP_Text textFilePath;
   
    private string documentsPath;


    [Header("Foreign Scripts")]
    public Vote_Controller vote_Scrpt;
    public Results_Controller results_Scrpt;


    private void Awake()
    {
        textFilePath = objFilePath.GetComponent<TMP_Text>();
        documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        textFilePath.text = documentsPath;
    }

    private void OnEnable()
    {
        documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        saveCurrentBacklogState();
        
    }


    private void saveCurrentBacklogState()
    {

        //1.create a new json file
        //2.Take Backlog
        //3.trasform into json format, string?
        //4.write in file
        //5. save file

        string json = "{\r\n\t\"Backlog\":[\r\n";
        //3.
        json = serialiazeBacklog(json);

        json += "\t]\r\n}";

        //Save file
        string fileName = "Backlog_Current_State.json";
        documentsPath += "\\" + fileName;

        File.WriteAllText(documentsPath, json);

    }

    private string serialiazeBacklog(string json)
    {
        int i = 0;
        //3.
        foreach (Backlog_Information x in GameSettings.backlogList)
        {
            if (i == (GameSettings.numberOfTaskEvaluted + GameSettings.numberOfTasksToEvalute) - 1)
            {
                json += "\t\t" + JsonUtility.ToJson(x) + "\r\n";

            }
            else
            {
                json += "\t\t" + JsonUtility.ToJson(x) + ",\r\n";

            }

            i++;
        }

        return json;

    }
    public void pressContinue()
    {
        results_Scrpt.restart();
        vote_Scrpt.reStartVote();
        vote_Scrpt.round = 0;
        vote_Scrpt.textNotepad.text = "";
        vote_Scrpt.setRound(0);


        for (int i = 0; i < 2; i++) {
            continueGame[i].SetActive(true);
        }

        current.SetActive(false);

    }

    public void pressExitGame()
    {
        Application.Quit();

    }


    public void pressMenu()
    {
        GameSettings.reset();
        SceneManager.LoadScene("Menu");
    }
}
