using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**@file
  *@brief Class Description: Script Qui va gerer l'addition d'une nouvelle tache personnalisé pendant le parametrage du jeu.
  */

public class Add_Custom_Task : MonoBehaviour
{
    /**@class Add_Custom_Task.
    * @brief Clase qui va permetre de ajoute ue nouvelle tache personalise sur place.
    * 
    * @var GameObject exception 
    * @brief Variable qui va contenir le GameObject du champ de texte qui decris une exception.
    * 
    * @var GameObject[] Inputs
    * @brief Tableau de GameObjects qui va contenir les GameObject du champ de texte qui definie le role, la tache, et l'objective de la nouvelle tache personalise..
    * 
    * @var TMP_Text textException
    * @brief Variable qui  contient la composante texte du GameObject exception.
    * 
    * @var TMP_InputField[] inputFields
    * @brief Tableau qui contient les composante texte du Tableau de GameObjects Inputs.
    * 
    */

    public GameObject exception;
    private TMP_Text textException;
    public GameObject[] Inputs = new GameObject[3];
    private TMP_InputField[] inputFields = new TMP_InputField[3];
    

    // Start is called before the first frame update
    void Start()
    {
        ///@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree.
        
        textException = exception.GetComponent<TMP_Text>();

        for (int i = 0; i < 3; i++) {
            inputFields[i] = Inputs[i].GetComponent<TMP_InputField>();
        }
        
    }

    public void addNewTask()
    {
        /**@brief Methode qui va verifier si tout les champs de texte on bien ete remplies (sinon il affiche une exception)  et ensuite  creer un nouveau objet Backlog_Information pour pouvoir ajouter
        *la nouvelle tache personalise dans le backlog a evaluer dedans la classe statique GameSettings.
        **/
 
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
                x.Value = "None";

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
        ///@brief Methode charge de remplisage de text et affichage  des differentes exception possibles lies a l'addition de la nouvelle tache.
        
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

