using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**@file
*@brief Class Description: Script Qui met a jour  et affiche le choix du mode du jeux.
*/

public class setGameModeTitle : MonoBehaviour
{
    /**@class setGameModeTitle.
     * @brief La classe va simplement  mettre a jour  le choix du mode du jeux et l'affiche dans l'interface.
     * 
     * @var GameObject Title 
     * @brief Variable qui va contenir le GameObject du champ de texte qui affiche le nom du mode du jeux dans l'interface
     * 
     * @var TMP_Text titleText 
     * @brief Variable qui contient la composante texte du GameObjet nbText
     */

    public GameObject Title;
    private TMP_Text titleText;


    private void Awake()
    {
        ///@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree. La methode  Awake s'excecute avant  la methode Start. Besoin de ceci car la methode OnEnable s'execute avant Start aussi
        titleText = Title.GetComponent<TMP_Text>();
        titleText.text = "Strict Mode";
    }

    private void OnEnable()
    {
        ///@brief Remplissage des variable text pour afficher a l'interface
        titleText.text = GameSettings.gameMode + " Mode";
        
    }
}
