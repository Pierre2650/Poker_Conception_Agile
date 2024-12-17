using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleFileBrowser;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;

public class End_Game_Controller : MonoBehaviour
{
    public GameObject[] userStory = new GameObject[3];
    private TMP_Text[] contenu = new TMP_Text[4];
    private string contenuValue;

    public GameObject nbTasks;
    private TMP_Text textNbTasks;

    public GameObject noteCard;
    private Image imageCard;

    public Sprite[] cardImages;

    private int taskIndex = 0;

    private string jsonFolderPath;


    // Start is called before the first frame update
    void Awake()
    {
        textNbTasks = nbTasks.GetComponent<TMP_Text>();

        imageCard = noteCard.GetComponent<Image>();


        int i = 0;
        foreach (GameObject obj in userStory)
        {

            contenu[i] = obj.GetComponent<TMP_Text>();
            i++;
        }

        contenu[0].text = GameSettings.backlogList[taskIndex].Role;
        contenu[1].text = GameSettings.backlogList[taskIndex].Task;
        contenu[2].text = GameSettings.backlogList[taskIndex].Obj;
        contenuValue = GameSettings.backlogList[taskIndex].Value;

        findValueSprite();

        textNbTasks.text = GameSettings.numberOfTaskEvaluted.ToString();


    }

    public void openFileExplorer()
    {
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        // Show a load file dialog and wait for a response from user
        // Load file/folder: file, Allow multiple selection: true
        // Initial path: default (Documents), Initial filename: empty
        // Title: "Load File", Submit button text: "Load"
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Folders, false, null, null, "Select Folder", "Save");


        // Print whether the user has selected some files or cancelled the operation (FileBrowser.Success)
        Debug.Log(FileBrowser.Success);

        if (FileBrowser.Success)
            OnFolderSelected(FileBrowser.Result); // FileBrowser.Result is null, if FileBrowser.Success is false
    }

    private void OnFolderSelected(string[] folderPath)
    {
        jsonFolderPath = folderPath[0];
        string json = "{\r\n\t\"Backlog\":[\r\n";
        //1.create a new json file
        //2.Take Backlog
        //3.trasform into json format, string?
        //4.write in file
        //5. save file


        //3.
        json = serialiazeBacklog(json);

        json += "\t]\r\n}";

        //Save file
        string fileName = "New_Backlog.json";
        jsonFolderPath += "\\" + fileName; 

        File.WriteAllText(jsonFolderPath, json);


        
        
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



    public void pressNextTastk()
    {
        taskIndex++;

        if (taskIndex  == GameSettings.numberOfTaskEvaluted) {

            taskIndex = 0;
        }
       

        contenu[0].text = GameSettings.backlogList[taskIndex].Role;
        contenu[1].text = GameSettings.backlogList[taskIndex].Task;
        contenu[2].text = GameSettings.backlogList[taskIndex].Obj;
        contenuValue = GameSettings.backlogList[taskIndex].Value;

        findValueSprite();

    }


    private void findValueSprite()
    {
        int i = 0;

        if (int.TryParse(contenuValue, out int a))
        {
            i = a;

            switch (i) {
                case 5: 
                    i = 4;
                    break;

                case 8:
                    i = 5;
                    break;

                case 13:
                    i = 6;
                    break;

                case 20:
                    i = 7;
                    break;

                case 40:
                    i = 8;
                    break;

                case 100:
                    i = 9;
                    break;

            }

        }
        else
        {
            if(contenuValue == "?")
            {
                
               i = 10;
                 
            }

        }


        imageCard.sprite = cardImages[i];

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
