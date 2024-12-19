using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui va gerer la mise a jour des valeur des secondes et minutes pour le temp de choix dans le jeux
*/

public class Choice_Timer_Controller : MonoBehaviour
{
    /**@class Choice_Timer_Controller.
     * @brief Controleur qui met a jour  le choix du temp des joueurs pour choisir les cartes dans la classe statique GameSettings
     * 
     * @var GameObject minute 
     * @brief Variable qui va contenir le GameObject du champ de texte qui defini la valeur des minutes.
     * @var GameObject seconds 
     * @brief Variable qui va contenir le GameObject du champ de texte qui definila valuer des secondes
     * 
     * @var minutesText 
     * @brief Variable qui  contient la composante texte du GameObject minute
     * @var secondsText 
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
        GameSettings.choiceTimer[0] = 1;
        GameSettings.choiceTimer[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ///@brief Dans chaque frame mets a jour les valeur du temp dans GameSettings.

        GameSettings.choiceTimer[0] = int.Parse(minutesText.text);
        GameSettings.choiceTimer[1] = int.Parse(secondsText.text);

    }
}
