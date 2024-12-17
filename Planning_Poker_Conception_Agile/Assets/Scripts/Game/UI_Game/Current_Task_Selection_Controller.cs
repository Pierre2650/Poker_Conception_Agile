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

    public GameObject nbTotaltasks;
    private TMP_Text textNbTotal;

    // Start is called before the first frame update
    void Awake()
    {
        textNbCompleted = nbCompletedtasks.GetComponent<TMP_Text>();
        textNbTotal = nbTotaltasks.GetComponent<TMP_Text>();

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

        int temp = GameSettings.numberOfTaskEvaluted + GameSettings.numberOfTasksToEvalute;
        textNbTotal.text = temp.ToString();
        
    }

    private void OnEnable()
    {
        reRoll();
        

    }




    public void reRoll()
    {

        Debug.Log("ReRoll Was Pushed");

        if (GameSettings.numberOfTasksToEvalute > 1)
        {
            int i = Random.Range(0, GameSettings.numberOfTasksToEvalute + GameSettings.numberOfTaskEvaluted);
            int temp = 0;

            while (temp < 9999)
            {
                i = Random.Range(0, GameSettings.numberOfTasksToEvalute + GameSettings.numberOfTaskEvaluted);

                if (GameSettings.backlogList[i].Value == "None")
                {
                    break;

                }

                temp++;

            }

            contenu[0].text = GameSettings.backlogList[i].Role;
            contenu[1].text = GameSettings.backlogList[i].Task;
            contenu[2].text = GameSettings.backlogList[i].Obj;

        }
        else
        {
            foreach (Backlog_Information temp in GameSettings.backlogList)
            {

                if (temp.Value == "None")
                {
                    contenu[0].text = temp.Role;
                    contenu[1].text = temp.Task;
                    contenu[2].text = temp.Obj;

                    break;

                }


            }

        }

       


    }


}
