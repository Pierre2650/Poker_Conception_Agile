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
    /**@var UIs: Tableau des Interfaces Existantes
     */
    public GameObject[] UIs;

    [Header("Back Button")]
    /**@var currentUI: Game object de l'interface du menu principale
    /@var toGoUI: Game object de l'interface pour choisir mode de jeux
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

    private void updateBackNextButtons()
    {
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
                // change scene

                backUI = UIs[1];

                break;

        }
    }

    public void pressBack()
    {
        ///@brief Methode pour revenir a l'interface precedente.
        ///
        currentUI.SetActive(false);
        backUI.SetActive(true);

        currentUI = backUI;
        updateBackNextButtons();

    }

    public void pressNext() {

        ///@brief Methode pour aller a l'interface suivante.
        ///

        currentUI.SetActive(false);
        nextUI.SetActive(true);

        currentUI = nextUI;
        updateBackNextButtons();
    }



}
