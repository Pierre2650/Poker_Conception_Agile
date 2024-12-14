using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Current_Task_Selection_Controller : MonoBehaviour
{
    public GameObject[] userStory = new GameObject[3];
    private TMP_Text[] contenu = new TMP_Text[3];

    public GameObject nbCompletedtasks;
    private TMP_Text textNbCompleted;

    private int lastRoll = 0;
    // Start is called before the first frame update
    void Awake()
    {
        textNbCompleted = nbCompletedtasks.GetComponent<TMP_Text>();
        int i = 0;
        foreach (GameObject obj in userStory) {

            contenu[i] = obj.GetComponent<TMP_Text>();
            i++;
        }

        foreach (Backlog_Information temp in GameSettings.backlogList) {
            if (temp.Value == "None")
            {
                contenu[0].text = temp.Role;
                contenu[1].text = temp.Task;
                contenu[2].text = temp.Obj;

                break;
            }
        }


    }


    private void Update()
    {
        textNbCompleted.text = GameSettings.numberOfTaskEvaluted.ToString();
        
    }

    private void OnEnable()
    {
        random();

    }




    public void random()
    {

        Debug.Log("ReRoll Was Pushed");

        int i = Random.Range(0, GameSettings.numberOfTasksToEvalute);
        int temp = 0;

        while ((i == lastRoll  || GameSettings.backlogList[i].Role != "None") && temp > 299)
        {
            i = Random.Range(0, GameSettings.numberOfTasksToEvalute);

            temp++;

        }

        contenu[0].text = GameSettings.backlogList[i].Role;
        contenu[1].text = GameSettings.backlogList[i].Task;
        contenu[2].text = GameSettings.backlogList[i].Obj;

        lastRoll = i;

    }


}
