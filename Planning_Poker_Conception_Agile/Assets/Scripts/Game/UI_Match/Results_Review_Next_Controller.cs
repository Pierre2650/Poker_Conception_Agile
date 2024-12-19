using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui gere les actions a faire apres le recapitulatif des votes
*/

public class Results_Review_Next_Controller : MonoBehaviour
{
 /**@class Results_Review_Next_Controller
  * @brief Classe responsable de la gestion des transitions et actions liees a l'interface des resultats apres les votes.
  * 
  * @var GameObject currentSubUi
  * @brief GameObject qui contient le sous-UI "Results_Ui". L'interface du match est divisee en trois sous-interfaces : Vote_UI, Results_Ui, et Debate_UI.
  * 
  * @var GameObject[] vote
  * @brief Tableau contenant les GameObjects utilises pour l'interface des votes.
  * 
  * @var GameObject[] next
  * @brief Tableau contenant les GameObjects utilises pour les interfacesdu debat.
  * 
  * @var GameObject matchNotUi
  * @brief GameObject representant le GameObject lie au match  qui n'est pas une inteface (Unity divise les gameObject par des GameObject UI et pas UI).
  * 
  * @var GameObject currentParentUi
  * @brief GameObject representant l'UI parent actuelle de l'interface des resultats.
  * 
  * @var GameObject[] game
  * @brief Tableau contenant les GameObjects lies aux elements du jeux UI et pas UI.
  * 
  * @var GameObject coffeeUI
  * @brief GameObject representant l'interface pour une pause cafe entre les parties.
  * 
  * @var Results_Controller controller
  * @brief Reference au script Results_Controller pour gerer les actions et avoir comunication avec le controlleur des resultats.
  * 
  */

    [Header("Debate")]
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
        /**
         * @brief Methode appelee lors de l'appui sur le bouton "Next".
         * 
         * Cette methode verifie Si le mode de jeu est "Average" et que le round actuel est le deuxieme, la methode termine le match en appelant `endMatch`.
         * Sinon, elle verifie l'unanimite des votes en appelant `checkUnanimity`,  Dans les autres modes de jeu, elle appelle directement `checkUnanimity`.
         */

        if (GameSettings.gameMode == "Average")
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


    public void checkUnanimity()
    {
        /**
          * @brief Methode qui verifie l'unanimite des votes et effectue l'action appropriee.
          * 
          * Cette methode verifie Si l'unanimite est atteinte (`controller.unanimity` est vrai), si la valeur indisputee est "Coffee", elle lance une pause cafe en appelant `coffeeBreak`.
          * Sinon, elle termine le match en appelant `endMatch`, si l'unanimite n'est pas atteinte, elle lance un debat en appelant `startDebate`.
          */
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
        /**
         * @brief Methode qui lance l'interface de debat ,la methode desactive l'interface actuelle et active l'interface de debat. s
         */

        for (int i = 0; i < next.Length; i++)
        {
            next[i].SetActive(true);
        }

        currentSubUi.SetActive(false);
    }

    private void endMatch()
    {
        /**
         * @brief Methode qui termine le match, cette methode desactive l'interface actuelle et active l'interface Game.
         * Elle prepare ainsi la transition  en reinitialisant differentes variables
         */

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
        /**
         * @brief Methode qui lance l'interface de pause cafe, la methode affiche l'interface associee a la pause cafe en activant le GameObject correspondant
         * et masque les autres elements de l'interface actuelle.
         */

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
