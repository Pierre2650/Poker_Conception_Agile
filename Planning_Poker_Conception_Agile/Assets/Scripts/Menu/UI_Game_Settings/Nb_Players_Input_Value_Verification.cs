using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/**@file
*@brief Class Description: Script Qui est chargee de verifier le input du champ number of players.
*/

public class Input_Value_Verification : MonoBehaviour
{
    /**@class Input_Value_Verification.
   * @brief Classe qui va mettre a jour le nombre de joueurs choisi et va verifier en meme temp si la valeur du input dans l'UI est valide.
   * 
   * @var TMP_InputField myInputField
   * @brief Variable qui contient la composante texte du GameObject lequel cette script est attache.
   * 
   * @var GameObject exception 
   * @brief Variable qui va contenir le GameObject du champ de texte qui decris une excepetion.
   
   * @var TMP_Text textException
   * @brief Variable qui  contient la composante texte du GameObject exception.
   * 
   */

    private TMP_InputField myInputField;
    public GameObject exception;
    private TMP_Text textException;
    

    // Start is called before the first frame update
    void Start()
    {
        /**@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree.
         */

        myInputField = GetComponent<TMP_InputField>();
        textException = exception.GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ///@brief Chaque frame: Si le champ est vide le nombre de joeur par defaut est 0. Si le champ n'est pas vide on verifie les conditions de input valables.

        if (myInputField.text == "") {
            GameSettings.numberOfPlayers = 0;
        }
        else
        {
            onlyNumbersCheck();
        }
        
        
    }

    private void onlyNumbersCheck()
    {
        ///@brief Methode qui verifie si le input du champ est un chiffre entre 0 et 10 et mets a jour le nombre de joueurs. 
      
        if (int.TryParse(myInputField.text,out int a))
        {
            if(a > 10)
            {
                myInputField.text = "10";
            }

            if( GameSettings.numberOfPlayers != a)
            {

                GameSettings.numberOfPlayers = a;

            }


            showException(0);
        }
        else
        {
            if (myInputField.text != "")
            {
                myInputField.text = "";
                showException(2);
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

            case 2:

                textException.text = "*Input is not a number";
                exception.SetActive(true);

                break;

        }

    }




}
