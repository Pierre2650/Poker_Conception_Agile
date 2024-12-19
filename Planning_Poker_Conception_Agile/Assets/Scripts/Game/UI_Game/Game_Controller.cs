using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui est chargee de la gestion de l'interface Game
*/

public class Game_Controller : MonoBehaviour
{
   /**@class Game_Controller
   * @brief Controlleur qui gere les fonctionalites principales du jeu.
   * 
   * @var GameObject[] current
   * @brief Tableau contenant les GameObjects active actuellement .
   * 
   * @var GameObject[] next
   * @brief Tableau contenant les GameObjects suivants (a activer).
   */

    public GameObject[] current = new GameObject[2];
    public GameObject next;


    private void Update()
    {
        ///@brief Chaque frame on verifie si on a evalue toute les fonctionalites, si c'est le cas, on lance la fin du jeux.
        
        if (GameSettings.numberOfTasksToEvalute == 0)
        {

            endGame();

        }
    }

    private void endGame()
    {
        ///@brief methode qui lance la fin du jeux , elle nous apporte a l'interface End_game
        next.SetActive(true);

        for (int i = 0; i < current.Length; i++)
        {

            current[i].SetActive(false);
        }

    }

   
     public void  updateTaskState(Backlog_Information target, string value)
    {
        /**@brief Methode qui va Evaluer la tache passe par parametre
        *@param target: La tache a evaluer
        *@param value: la valeur de l'evaluation.
        **/
      

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

    private int findTargetTask(Backlog_Information target)
    {
        ///@brief Methode pour trouver l;indexe de la tache passe par parametre dans la liste de tache de GameSettings.
        int i = 0;
        foreach (Backlog_Information search in GameSettings.backlogList)
        {

            if (search.Role == target.Role && search.Task == target.Task && search.Obj == target.Obj)
            {
                return i;
            }


            i++;
        }

        return -1;
    }


}
