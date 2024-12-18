using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Results_Review_Next_Controller : MonoBehaviour
{

    [Header("EndMatch")]
    public GameObject currentSubUi;
    public GameObject[] vote = new GameObject[2];
    public GameObject[] next = new GameObject[2];


    [Header("EndMatch")]
    public GameObject matchNotUi;
    public GameObject currentParentUi;
    public GameObject[] game = new GameObject[2];

    [Header("Coffee Break")]
    public GameObject coffeeUI;

    [Header("Controller Script")]
    public Results_Controller controller;

    public void nextbutton()
    {
        if(GameSettings.gameMode == "Average")
        {
            if(controller.Vote_Scrpt.round == 2)
            {

                endMatch();


            }
            else
            {
                checkUnanimity();

            }
        }
        else
        {

            checkUnanimity();


        }

    }


    private void checkUnanimity()
    {
        if (controller.unanimity)
        {

            if (controller.undisputedValue == "Coffee")
            {
                coffeeBreak();
            }
            else
            {
                endMatch();
            }


        }
        else
        {
            startDebate();
        }

    }


    public void startDebate()
    {


        for (int i = 0; i < next.Length; i++)
        {
            next[i].SetActive(true);
        }

        currentSubUi.SetActive(false);
    }

    private void endMatch()
    {
        controller.restart();
        controller.Vote_Scrpt.reStartVote();
        controller.Vote_Scrpt.round = 1;
        controller.Vote_Scrpt.textNotepad.text = "";
        controller.Vote_Scrpt.setRound(1);

        if (GameSettings.gameMode == "Average") {

            string avgValue;
            int avg = controller.findAverage(controller.evaluations);

            if (avg == -1)
            {
                avgValue = "?";
            }
            else
            {
                avgValue = avg.ToString();
            }
            
            //Find average fonction, set as undisputed value

            controller.Game_Scrpt.updateTaskState(GameSettings.taskBeingEvaluated, avgValue);
        }
        else
        {
            controller.Game_Scrpt.updateTaskState(GameSettings.taskBeingEvaluated, controller.undisputedValue);

        }
        

        for (int i = 0; i < vote.Length; i++)
        {
            vote[i].SetActive(true);
            game[i].SetActive(true);
        }

        matchNotUi.SetActive(false);
        currentSubUi.SetActive(false);
        currentParentUi.SetActive(false);

        //end match, resets, go to game UI, update taches
    }


    private void coffeeBreak()
    {
        

        for (int i = 0; i < vote.Length; i++)
        {
            vote[i].SetActive(true);
        }

        coffeeUI.SetActive(true);

        matchNotUi.SetActive(false);
        currentSubUi.SetActive(false);
        currentParentUi.SetActive(false);

    }



}
