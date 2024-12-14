using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Remove_Tasks_Controller : MonoBehaviour
{
    public GameObject exceptions;
    private TMP_Text textException;

    private void Start()
    {
        textException = exceptions.GetComponent<TMP_Text>();
    }

    public void removeLastTask()
    {

        if (GameSettings.numberOfTasksToEvalute > 0)
        {
            foreach (Backlog_Information task in GameSettings.backlogList)
            {
                if (task.Value == "None")
                {
                    GameSettings.backlogList.Remove(task);
                    GameSettings.numberOfTasksToEvalute--;

                    

                    if (GameSettings.numberOfTasksToEvalute == 0)
                    {
                        showException(4);
                        removeAllTasks();

                    }
                    else
                    {
                        showException(0);
                    }

                    break;
                }
            }


        }
        else {
            showException(1);

        }

    }

    public void removeAllTasks()
    {

        if (GameSettings.numberOfTasksToEvalute + GameSettings.numberOfTaskEvaluted > 0)
        {
           
            GameSettings.backlogList.Clear();

            GameSettings.numberOfTasksToEvalute= 0;
            GameSettings.numberOfTaskEvaluted = 0;


        }
        else
        {
            showException(1);
        }


    }

    private void showException(int x)
    {
        switch (x)
        {
            case 0:

                exceptions.SetActive(false);

                break;
                
            case 1:
                textException.text = "*No Tasks to remove";

                exceptions.SetActive(true); 
                break;


            case 4:

                textException.text = "*No task to evaluate data has been cleared";

                exceptions.SetActive(true);
                break;


        }

    }

}
