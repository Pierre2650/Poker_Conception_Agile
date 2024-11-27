using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**@file
*@brief Class Description: Script Activation Start Game Button.
*@author Larmat jean
*/
public class Buttons_Controller : MonoBehaviour
{
    [Header("List of Interfaces")]
    public GameObject[] UIs;



    [Header("Star Game Button")]
     /**@var UIMenu: Game object de l'interface du menu principale
     *@var UISelectGameMode: Game object de l'interface pour choisir mode de jeux
     */

    public GameObject UIMenu;
    public GameObject UISelectGameMode;

    [Header("Back Button")]
    /**@var currentUI: Game object de l'interface du menu principale
    /@var toGoUI: Game object de l'interface pour choisir mode de jeux
    */

    public GameObject currentUI;
    public GameObject toGoUI;


    public void pressStartGame()
    {
         ///@brief Methode pour changer l'interface du Menu principale a le choix du mode de jeux.

        currentUI = UISelectGameMode;

        UIMenu.SetActive(false);
        UISelectGameMode.SetActive(true);
    }

    public void pressBack()
    {

        ///@brief Methode pour revenir a l'interface precedente.
        string sceneTag = "";

        currentUI.SetActive(false);
        toGoUI.SetActive(true);

        currentUI = toGoUI;

        switch (sceneTag)
        {
            case "Menu":

                break;

            case "gMode":

                break;

            case "gConfig":

                break;
        }



    }



}
