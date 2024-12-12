using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Add_Custom_Task : MonoBehaviour
{
    public GameObject exception;
    private TMP_Text textException;
    public GameObject[] Inputs = new GameObject[3];
    private TMP_InputField[] inputFields = new TMP_InputField[3];
    

    // Start is called before the first frame update
    void Start()
    {
        textException = exception.GetComponent<TMP_Text>();

        for (int i = 0; i < 3; i++) {
            inputFields[i] = Inputs[i].GetComponent<TMP_InputField>();
        }
        
    }

    public void addNewTask()
    {
        bool isEmpty = false;

        for (int i = 0; i < 3; i++)
        {
            if (inputFields[i].text == "")
            {
                isEmpty = true;
                showException(2);
                
            }

           
        }

        if (!isEmpty) {

            Backlog_Information x = new Backlog_Information();

            if (GameSettings.numberOfTasksToEvalute < 15)
            {
                x.Role = inputFields[0].text;
                x.Task = inputFields[1].text;
                x.Obj = inputFields[2].text;

                GameSettings.backlogList.Add(x);
                GameSettings.numberOfTasksToEvalute++;


                inputFields[0].text = "";
                inputFields[1].text = "";
                inputFields[2].text = "";
                showException(0);

                 

            }
            else
            {
                showException(1);

                 
            }

        }

        

        

    }


    private void showException(int x)
    {
        switch (x)
        {
            case 0:

                exception.SetActive(false);

                break;

            case 1:

                textException.text = "*Tasks > 15 Max Number of task reached";
                exception.SetActive(true);

                break;

            case 2:

                textException.text = "*All fields must be Filled";
                exception.SetActive(true);

                break;

        }

    }




}

