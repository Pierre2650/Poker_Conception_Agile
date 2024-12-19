using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui va permetre d'enlever des taches.
*/

public class Remove_Tasks_Controller : MonoBehaviour
{
    /**@class Remove_Tasks_Controller.
    * @brief Controlleur qui va permetre d'enlever la premiere tache a valider trouver ou le backlog entiere.
    * 
    * @var GameObject exception 
    * @brief Variable qui va contenir le GameObject du champ de texte qui decris une excepetion.
 
    * @var TMP_Text textException
    * @brief Variable qui  contient la composante texte du GameObject exception.
    *
    */

    public GameObject exceptions;
    private TMP_Text textException;

    private void Start()
    {
        /**@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree.
         */
        textException = exceptions.GetComponent<TMP_Text>();
    }

    public void removeTask()
    {
        /**@brief Methode utilise par le button "Remove last task". Elle va verifier s'il y en a  un backlog et va trouver et ensuite enlever la premiere Tache a valider posible.
         */

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
