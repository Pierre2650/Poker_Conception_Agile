using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/**@file d
*@brief Class Description: Script Qui va gerer la generation et enregistrement d'identifient Joueur
*/

public class Char_Creation_Manager : MonoBehaviour
{
    /**@class Char_Creation_Manager.
   * @brief Controlleur qui va enregistrer les pseudo de chaque joueur dans la classe GameSettings et ensuite passer a la prochaine interface.
   * 
   * @var GameObject input 
   * @brief Variable qui va contenir le GameObject du champ de texte de l'input.
   * @var TMP_Text textInput
   * @brief Variable qui  contient la composante texte du GameObject input.
   * 
   * @var GameObject[] next
   * @brief Liste qui contient les GameObjects  a activer lorsqu'on change d'UI
   * @var GameObject thisUI
   * @brief Variable qui contient le GameObject de cette interface.
   * 
   * @var GameObject playerNumber;
   * @brief Variable qui va contenir le GameObject du champ de texte qui affiche le numero du joueur.
   * @var TMP_Text textPlayerNumber;
   * @brief Variable qui  contient la composante texte du GameObject playerNumber.
   * 
   * @var GameObject exception 
   * @brief Variable qui va contenir le GameObject du champ de texte qui decris une excepetion.
   * @var TMP_Text textException
   * @brief Variable qui  contient la composante texte du GameObject exception.
   * 
   * @var int currentPlayer
   * @brief Variable qui va compter et indiquer dans quelle numero de joueur on ce trouve
   * 
   */

    public GameObject input;
    private TMP_InputField textInput;

    public GameObject[] next = new GameObject[2];
    public GameObject thisUI;

    public GameObject playerNumber;
    private TMP_Text textPlayerNumber;

    public GameObject exception;
    private TMP_Text textException;

    private int currentPlayer = 0;


    // Start is called before the first frame update
    void Start()
    {
        /**@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree.
         */ 
        textInput = input.GetComponent<TMP_InputField>();
        textPlayerNumber = playerNumber.GetComponent<TMP_Text>();
        textException = exception.GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ///@brief Chaque frame on va verifier si on a atteint le derniere joueur, sinon on met a jour l'interface
        
        if (currentPlayer <= GameSettings.numberOfPlayers) { 
            int temp = currentPlayer + 1;
            textPlayerNumber.text = "Player " + temp.ToString();
        }
    }

    private bool nameAlreadyTaken(string target)
    {
        ///@brief Methode qui verifie si le pseudo existe deja
        
        foreach (string names in GameSettings.playerNames) {
            if (names.Contains(target)) { 
                return true;
            }
        }

        return false;

    }

    public void confirmNickName()
    {
        /**@brief Methode appele par le button "Confirm" , la methode va verifier que le champ de texte n'est pa vide et que le pseudo n'existe pas encore, ensuite verifie si on a atteint 
        *le maximum nombre de joueur, lorsqu'on atteint le derniere joueur on passe a l'interface suivante.
        */

        if (textInput.text != "")
        {
            if (!nameAlreadyTaken(textInput.text)) { 
                GameSettings.playerNames.Add(textInput.text);

                currentPlayer++;
                textInput.text = "";

                if (currentPlayer == GameSettings.numberOfPlayers)
                {
                    foreach (GameObject obj in next)
                    {
                        obj.SetActive(true);
                    }

                    thisUI.SetActive(false);
                }

                showException(0);
            }
            else
            {
                showException(3);
            }
        }
        else
        {
            showException(1);
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

                textException.text = "*Nickname cant be null";
                exception.SetActive(true);

                break;

            case 2:

                textException.text = "*All fields must be Filled";
                exception.SetActive(true);

                break;

            case 3:

                textException.text = "*Nickname Already Taken";
                exception.SetActive(true);

                break;

        }

    }
}
