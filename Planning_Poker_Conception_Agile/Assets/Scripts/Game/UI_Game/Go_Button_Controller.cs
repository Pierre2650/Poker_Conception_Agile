using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui gere La fonctionalite du button Go dans l'interface Game
*/
public class Go_button_controller : MonoBehaviour
{
    /**@class Go_button_controller
    * @brief Controlleur qui va enregistrer la tache choisi pour evaluer dans la classe statique GameSettings.
    * Il va aussi definir la fonctionalite du button go pour passer de l'inteface jeu a l'interface match_vote.
    * 
    * @var GameObject[] disable
    * @brief Tableau contenant les GameObjects active actuellement .
    * @var GameObject[] next
    * @brief Tableau contenant les GameObjects suivants (a activer).
    * 
    * @var GameObject[] userStory
    * @brief Tableau contenant les GameObjects representant les recits utilisateur.
    * @var TMP_Text[] contenu
    * @brief Tableau de composante texte affichant les details des userStory.
    * 
    */

    public GameObject[] disable = new GameObject[2];
    public GameObject[] next = new GameObject[2];

    public GameObject[] userStory = new GameObject[3];
    private TMP_Text[] contenu = new TMP_Text[3];

    private void Start()
    {
        ///@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree

        int i = 0;
        foreach (GameObject obj in userStory)
        {

            contenu[i] = obj.GetComponent<TMP_Text>();
            i++;
        }
    }

    public void goButton()
    {
        ///@brief Methode utiliser par le butto "Go", elle enregistre le choix de la tache a evaluer et active les GameObject suivant et Desactive les GameObjects courrants.
        GameSettings.taskBeingEvaluated.Role = contenu[0].text;
        GameSettings.taskBeingEvaluated.Task = contenu[1].text;
        GameSettings.taskBeingEvaluated.Obj = contenu[2].text;
        GameSettings.taskBeingEvaluated.Value = "None";

        for (int i = 0; i < 2; i++)
        {
            disable[i].SetActive(false);
            next[i].SetActive(true);

        }
    }
}
