using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**@file
  *@brief Class Description: Script Qui va gerer la mise a jour des valeur des secondes et minutes pour le temp de debat dans le jeux
  */

public class Debate_Timer_Controller : MonoBehaviour
{

    /**@class Debate_Timer_Controller.
    * @brief Controleur qui met a jour le temp de debat du jeux grace  a la classe statique GameSettings.
    * 
    * @var GameObject minutes 
    * @brief Variable qui va contenir le GameObject du champ de texte qui defini des minutes
    * @var GameObject seconds 
    * @brief Variable qui va contenir le GameObject du champ de texte qui defini des secondes
    * 
    * @var TMP_Text minutesText
    * @brief Variable qui  contient la composante texte du GameObject minutes
    * @var TMP_Text secondsText
    * @brief Variable qui  contient la composante texte du GameObject seconds
    * 
    * @var List<GameObject> buttons
    * @brief Liste  qui contiens les buttons de incrementation et decrementation lie au temp du debat dans l'interface
    * 
    * @var bool noTime
    * @brief Boolean qui defini si on choisie de ne pas avoir du temp pour le  debat
    * 
    */

    public GameObject minutes;
    public GameObject seconds;
    private TMP_Text minutesText;
    private TMP_Text secondsText;

    public List<GameObject> buttons;

    private bool noTime = false;

    private void Start()
    {
        ///@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree et les valeur de minutes et secondes de base pour le debat.
        minutesText = minutes.GetComponent<TMP_Text>();
        secondsText = seconds.GetComponent<TMP_Text>();

        GameSettings.debateTimer[0] = 1;
        GameSettings.debateTimer[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ///@brief Si l'option "pas de temp " est false,  chaque frame on  mets a jour la valeur les valeur de minutes et secondes de base pour le debat..
        if (!noTime)
        {
            GameSettings.debateTimer[0] = int.Parse(minutesText.text);
            GameSettings.debateTimer[1] = int.Parse(secondsText.text);
        }
       

    }

    public void noTimerButton()
    {
        ///@brief Methode qui est declenche par le button NoTime qui va desactiver ou activer l'option de parametrer du temp pour le debat du jeux.
        
        noTime = !noTime;

        if (noTime)
        {
            foreach (GameObject button in buttons)
            { 
                Button temp = button.GetComponent<Button>();
                temp.interactable = false;

            }

            minutesText.text = "0";
            secondsText.text = "00";
            GameSettings.debateTimer[0] = 99;
            GameSettings.debateTimer[1] = 0;
        }
        else {
            foreach (GameObject button in buttons)
            {
                Button temp = button.GetComponent<Button>();
                temp.interactable = true;

            }

            minutesText.text = "1";
            secondsText.text = "00";

        }
        
    }
}
