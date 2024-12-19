using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/**@file
*@brief Class Description: Script Qui gere la mise a jour l'User Story en cour d'evaluation
*/
public class OnGame_Current_Task_Texts_Controller : MonoBehaviour
{
    /**@class OnGame_Current_Task_Texts_Controller
    * @brief Controlleur qui gere la mise a jour  de l'affichage l'User Story en cour d'evaluation.
    * 
    * @var GameObject[] userStory
    * @brief Tableau contenant les GameObjects representant les recits utilisateur.
    * 
    * @var TMP_Text[] contenu
    * @brief Tableau de composante texte affichant les details des userStory.
    * 
    */

    public GameObject[] userStory = new GameObject[3];
    private TMP_Text[] contenu = new TMP_Text[3];

    // Start is called before the first frame update
    void Awake()
    {
        ///@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree. La methode  Awake s'excecute avant  la methode Start. Besoin de ceci car la methode OnEnable s'execute avant Start aussi

        int i = 0;
        foreach (GameObject obj in userStory)
        {

            contenu[i] = obj.GetComponent<TMP_Text>();
            i++;
        }



    }

    private void OnEnable()
    {
        ///@brief Remplissage de variable text pour affichage a l'interface.

        contenu[0].text = GameSettings.taskBeingEvaluated.Role;
        contenu[1].text = GameSettings.taskBeingEvaluated.Task;
        contenu[2].text = GameSettings.taskBeingEvaluated.Obj;

    }
}
