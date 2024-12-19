using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**@file
*@brief Class Description: Script Qui va gerer la functionalite des buttons pour augmenter et decrementer les valeur de minutes et secondes.
*/
public class Increase_Decrease_Buttons : MonoBehaviour
{
    /**@class Increase_Decrease_Buttons.
    * @brief La classe va se charger de augmenter ou  decrementer les valeur de minutes et secondes de temp pour le choix d'evaluations des joueur ou du debat.
    * 
    * @var GameObject minutes 
    * @brief Variable qui va contenir le GameObject du champ de texte qui defini des minutes
    * @var GameObject seconds 
    * @brief Variable qui va contenir le GameObject du champ de texte qui defini des secondes
    * 
    * @var TMP_Text minutesText;
    * @brief Variable qui  contient la composante texte du GameObject minutes
    * @var TMP_Text secondsText;
    * @brief Variable qui  contient la composante texte du GameObject seconds
    */


    public GameObject minutes;
    public GameObject seconds;

    private TMP_Text minutesText;
    private TMP_Text secondsText;

    private void Start()
    {
        ///@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree.
        minutesText = minutes.GetComponent<TMP_Text>();
        secondsText = seconds.GetComponent<TMP_Text>();
    }

    public void increaseMinutes()
    {
        /** @brief Methode declenche par le button d'incrementation lie aux minutes. La methode va prendre la valeur textuel qui est dedans la variable minutes , va la transformer en
         * un nombre entier, va l'augmenter, va verifier si elle devienne plus grande que 5 ( si c'est le cas elle devienne 0) la limite des minutes possibles et va la metre ajour dans cette meme varaiable textuelle
         * 
         * @var int temp
         * @brief Variable qui sert comme un tampon pour transformer des valeur textuel en nombre entier et ainsi pouvoir additioner de 1.
         */
        int temp = int.Parse(minutesText.text);

        temp++;

        if (temp > 5)
        {
            temp = 0;
        }
  
        
        minutesText.text = temp.ToString();

    }

    public void decreaseMinutes() {
        /** @brief Methode declenche par le button de decrementation lie aux minutes. La methode va prendre la valeur textuel qui est dedans la variable minutes , va la transformer en
         * un nombre entier, va la decrementer, va verifier si elle devienne plus petite que 0 ( si c'est le cas elle devienne 5) la limite des minutes possibles et va la metre ajour dans cette meme varaiable textuelle
         * 
         * @var int temp
         * @brief Variable qui sert comme un tampon pour transformer des valeur textuel en nombre entier et ainsi pouvoir soustrer de 1.
         */

        int temp = int.Parse(minutesText.text);

        temp--;

        if (temp < 0)
        {
            temp = 5;
        }


        minutesText.text = temp.ToString();
    }

    public void increaseSeconds()
    {
        /** @brief Methode declenche par le button d'incrementation lie aux minutes. La methode va prendre la valeur textuel qui est dedans la variable secondes , va la transformer en
         * un nombre entier, va l'augmenter, va verifier si elle devienne plus grande que 55 ( si c'est le cas elle devienne 0) la limite des secondes possibles et va la metre ajour dans cette meme varaiable textuelle
         * 
         * @var int temp
         * @brief Variable qui sert comme un tampon pour transformer des valeur textuel en nombre entier et ainsi pouvoir additioner de 5.
         */

        int temp = int.Parse(secondsText.text);

        temp+= 5;

        if (temp > 55)
        {
            temp = 0;
        }

        if (temp < 10) {
            secondsText.text = "0"+temp.ToString();

        }
        else
        {
            secondsText.text = temp.ToString();

        }


        

    }

    public void decreaseSeconds()
    {
        /** @brief Methode declenche par le button de decrementation lie aux secondes. La methode va prendre la valeur textuel qui est dedans la variable secondes , va la transformer en
         * un nombre entier, va la decrementer, va verifier si elle devienne plus petite que 0 ( si c'est le cas elle devienne 55) la limite des secondes possibles et va la metre ajour dans cette meme varaiable textuelle
         * 
         * @var int temp
         * @brief Variable qui sert comme un tampon pour transformer des valeur textuel en nombre entier et ainsi pouvoir soustrer de 5.
         */

        int temp = int.Parse(secondsText.text);

        temp-= 5;

        if (temp < 0)
        {
            temp = 55;
        }


        if (temp < 10)
        {
            secondsText.text = "0" + temp.ToString();

        }
        else
        {
            secondsText.text = temp.ToString();

        }
    }


}
