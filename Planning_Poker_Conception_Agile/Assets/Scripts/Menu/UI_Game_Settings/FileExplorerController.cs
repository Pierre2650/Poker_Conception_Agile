using SimpleFileBrowser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;




public class FileExplorerController : MonoBehaviour
{
    public GameObject excpetion;
    private TMP_Text textException;
   
    
    private string jsonPath;


    public class Deserializer
    {
        public List<Backlog_Information> Backlog;
    }

    private void Start()
    {
        textException = excpetion.GetComponent<TMP_Text>();


        // Set filters (optional)
        // It is sufficient to set the filters just once (instead of each time before showing the file browser dialog), 
        // if all the dialogs will be using the same filters
        FileBrowser.SetFilters(true, new FileBrowser.Filter("JSON Files", ".json"));

        // Set default filter that is selected when the dialog is shown (optional)
        // Returns true if the default filter is set successfully
        // In this case, set Images filter as the default filter
        FileBrowser.SetDefaultFilter(".json");


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
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, null, null, "Select Files", "Load");


        // Print whether the user has selected some files or cancelled the operation (FileBrowser.Success)
        Debug.Log(FileBrowser.Success);

        if (FileBrowser.Success)
            OnFilesSelected(FileBrowser.Result); // FileBrowser.Result is null, if FileBrowser.Success is false
    }

    private void OnFilesSelected(string[] filePaths)
    {
        jsonPath = filePaths[0];

        if (Path.GetExtension(jsonPath) == ".json")
        {

            // Read File.
            string info;
            info = File.ReadAllText(jsonPath);

          
            //Deserialize
            Deserializer temp = JsonUtility.FromJson<Deserializer>(info);
            Debug.Log(temp.Backlog.Count);

            if (temp.Backlog.Count > 15)
            {
                showException(1);
            }
            else if (GameSettings.numberOfTasks + temp.Backlog.Count > 15)
            {
                showException(3);
            }
            else
            {

                foreach (Backlog_Information x in temp.Backlog) { 
                    GameSettings.backlogList.Add(x);
                }

                GameSettings.numberOfTasks = GameSettings.backlogList.Count;

                showException(0);


            }


        }
        else
        {
            showException(2);
        }
    }

    private void showException(int x)
    {
        switch (x) { 
            case 0:

                excpetion.SetActive(false);

                break;

            case 1:
     
                textException.text = "*NB of Tasks > 15 \r\n" +
                                    "Max Number of task reached";
                excpetion.SetActive(true);

                break;

            case 2:
                textException.text = "*Selected File is not a JSON";

                excpetion.SetActive(true);
                break;

            case 3:
                textException.text = "*Adding the JSON would surpass Max Number of tasks";

                excpetion.SetActive(true);

                break;
        
        }

    }


   

}
