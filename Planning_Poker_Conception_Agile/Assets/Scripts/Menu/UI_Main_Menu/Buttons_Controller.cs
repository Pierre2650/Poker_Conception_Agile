using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**@file
*@brief Class Description: Script Activation Start Game Button.
*/

public class Buttons_Controller : MonoBehaviour
{
    /**@class Buttons_Controller.
     * @brief Controleur des buttons Start Game, credits, Exit game and Next and back en fonction de l'UI actuelle .
     */

    [Header("List of Interfaces")]
    ///@var UIs: Tableau des Interfaces Existantes
     
    public GameObject[] UIs;

    [Header("Back Button")]
    /**@var GameObject currentUI 
    * @brief Game object de l'interface actuelle.
    *@var GameObject nextUI 
    *@brief Game object de l'interface suivante.
    *@var GameObject backUI 
    *@brief Game object de l'interface precedente. 
    */

    public GameObject currentUI;
    public GameObject backUI;
    public GameObject nextUI;


    public void pressStartGame()
    {
        ///@brief Methode pour changer l'interface du Menu principale a le choix du mode de jeux.

        UIs[0].SetActive(false);
        UIs[1].SetActive(true);

        currentUI = UIs[1];

        updateBackNextButtons();
    }

    public void pressCredits()
    {

    }


    public void pressExitGame()
    {
        ///@brief Methode qui quite l'applicattion.
        Application.Quit();
    }

    private void updateBackNextButtons()
    {
        /**@brief Methode qui va mettre a jour les differentes inderface en fonction de l'inderface actuelle.
        *On Utilise le tag du game object pour davoir ou on est situe.
        */
        string sceneTag = currentUI.gameObject.tag;

        switch (sceneTag)
        {
            case "Menu":

                nextUI = UIs[1];


                break;

            case "gMode":

                nextUI = UIs[2];
                backUI = UIs[0];

                break;

            case "gConfig":

                backUI = UIs[1];

                break;

        }
    }

    public void pressBack()
    {
        ///@brief Methode pour revenir a l'interface precedente.
        
        currentUI.SetActive(false);
        backUI.SetActive(true);

        currentUI = backUI;
        updateBackNextButtons();

    }

    public void pressNext() {

        ///@brief Methode pour aller a l'interface suivante.
      

        currentUI.SetActive(false);
        nextUI.SetActive(true);

        currentUI = nextUI;
        updateBackNextButtons();
    }



}
