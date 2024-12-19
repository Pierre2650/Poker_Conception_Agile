using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui affiche dans l'interface le nombre actuelle de tache a evaluer.
*/

public class Current_NB_Tasks : MonoBehaviour
{
    /**@class Current_NB_Tasks.
     * @brief La classe va mettre a jour le  le nombre actuelle de tache a evaluer.
     * 
     * @var GameObject nbText 
     * @brief Variable qui va contenir le GameObject du champ de texte qui defini le nombre actuelle de tache a evaluer
     * 
     * @var TMP_Text n
     * @brief Variable qui  contient la composante texte du GameObjcet nbText
     */

    public GameObject nbText;
    private TMP_Text n;

    private void Start()
    {
        ///@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree.
        n = nbText.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ///@brief Dans chaque frame mets a jour la valeur de n.
        n.text = GameSettings.numberOfTasksToEvalute.ToString();
        
    }
}
