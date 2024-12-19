using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**@file
*@brief Class Description: Script Qui gere le button pour lancer le jeux dans l'interface charge du parametrage du jeux
*/

public class Game_settings_Start_Button_Controller : MonoBehaviour
{

    /**@class Game_settings_Start_Button_Controller.
     * @brief Controleur qui va verifier les conditions pour pouvoir lancer le jeux. Les conditions etant la necessite de plus que 1 joeur et au moin 1 tache qu'on peut evaluer
     * 
     * @var GameObject next 
     * @brief Variable qui va contenir le GameObject du Button pour lancer le jeux.
     * 
     * @var Button buttonNext 
     * @brief Variable qui contien la composante  button  du GameObjet next
     */

    public GameObject next;
    private Button buttonNext;

    private void Start()
    {
        ///@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree.
        buttonNext = next.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        ///@brief Dans chaque frame verifie si les conditions sont verifie pour activer le button qui lance le jeux.
        if ( GameSettings.numberOfPlayers > 1 && GameSettings.numberOfTasksToEvalute > 0)
        {
            buttonNext.interactable = true;
        }
        else
        {
            buttonNext.interactable= false;
        }

        
    }

    public void startGame()
    {
        ///@brief Lance la scene de Unity du jeux.
        SceneManager.LoadScene("Game");
    }
}
