using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui gere L'affichage et selection de aleatoire d'une tache pas valide parmi le backlog.
*/

public class Current_Task_Selection_Controller : MonoBehaviour
{
    /**@class Current_Task_Selection_Controller
    * @brief Controlleur qui va afficher une tache non valide du backlog choisi aleatoirement. Il va permetre de relance un choix aleatoire pour changer la tache affiche
    * Le controlleur va afficher le nombre totale de taches dans le backlog et va mettre a jour le nombre de taches valide.
    * 
    * @var GameObject[] userStory
    * @brief Tableau contenant les GameObjects representant les recits utilisateur.
    * @var TMP_Text[] contenu
    * @brief Tableau de composante texte affichant les details des userStory.
    * 
    * 
    * @var GameObject nbCompletedtasks 
    * @brief Variable qui va contenir le GameObject du champ de texte qui defini le nombre de taches deja evalue
    * @var TMP_Text textNbCompleted
    * @brief Variable qui  contient la composante texte du GameObject nbCompletedtasks
    * 
    * @var GameObject nbTotaltasks 
    * @brief Variable qui va contenir le GameObject du champ de texte qui defini le nombre totale de taches
    * @var TMP_Text textNbTotal
    * @brief Variable qui  contient la composante texte du GameObject nbTotaltasks
    * 
    *
    */

    public GameObject[] userStory = new GameObject[3];
    private TMP_Text[] contenu = new TMP_Text[3];

    public GameObject nbCompletedtasks;
    private TMP_Text textNbCompleted;

    public GameObject nbTotaltasks;
    private TMP_Text textNbTotal;

    // Start is called before the first frame update
    void Awake()
    {
        ///@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree. La methode  Awake s'excecute avant  la methode Start. Besoin de ceci car la methode OnEnable s'execute avant Start aussi

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
        ///@brief Chaque frame on  mets a jour les valeurs du nombre total de taches et nombre de taches valides.

        textNbCompleted.text = GameSettings.numberOfTaskEvaluted.ToString();

        int temp = GameSettings.numberOfTaskEvaluted + GameSettings.numberOfTasksToEvalute;
        textNbTotal.text = temp.ToString();
        
    }

    private void OnEnable()
    {
        ///@brief Relance du choix aleatoire de tache.
        reRoll();
        

    }




    public void reRoll()
    {
        /**
         * @brief Methode qui permet de relancer la selection d'une tache aleatoire a evaluer
         * Cette methode  Verifie si le nombre de taches restantes a evaluer est superieur a 1 , genere un index aleatoire pour selectionner une tache dans la liste des taches,
         * si la tache selectionnee a une valeur "None", elle est affichee dans l'interface.
         * Si une seule tache reste a evaluer, elle est directement selectionnee et affichee.
         */

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
