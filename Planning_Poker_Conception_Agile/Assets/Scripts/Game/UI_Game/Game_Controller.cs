using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public GameObject[] current = new GameObject[2];
    public GameObject next;


    private void Update()
    {
        if(GameSettings.numberOfTasksToEvalute == 0)
        {

            next.SetActive(true);

            for (int i = 0; i < current.Length; i++)
            {
             
                current[i].SetActive(false);
            }

            
        }
    }

    private int findTargetTask(Backlog_Information target)
    {
        int i = 0;
        foreach (Backlog_Information search in GameSettings.backlogList) {

            if(search.Role == target.Role && search.Task == target.Task && search.Obj == target.Obj)
            {
                return i;
            }
           

            i++;
        }

        return -1;
    }

     public void  updateTaskState(Backlog_Information target, string value)
    {
        int i = findTargetTask(target);
        if (i < 0) {
            Debug.Log("Untargetable task, not found");
        }
        else
        {
            GameSettings.backlogList[i].Role = target.Role;
            GameSettings.backlogList[i].Task = target.Task;
            GameSettings.backlogList[i].Obj = target.Obj;
            GameSettings.backlogList[i].Value = value;

            GameSettings.countTasks();

        }

    }

}
