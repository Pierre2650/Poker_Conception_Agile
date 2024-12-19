using Codice.Client.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui active ou desactive une partie de l'interface qui permet au joeur d'ajouter des taches.
*/

public class Custom_Tasks : MonoBehaviour
{
    /**@class Custom_Tasks.
     * @brief La classe va simplement activer et desactiver la visualisation d'une zone compose de 3 inputs pour la creation d'un tache "sur place"
     * 
     * @var GameObject customTWindow 
     * @brief Variable qui va contenir le GameObject de cette zone
     * 
     * @var bool on 
     * @brief Variable qui indique si activer ou desactiver la visualisation de la zone.
     */

    public GameObject customTWindow;

    private bool on = false;
    
    public void newCustomTask()
    {
        ///@brief Methode qui active ou desactive le GameObject de la zone.
        on = !on;

        if (on)
        {
            customTWindow.SetActive(true);

        }
        else
        {
            customTWindow.SetActive(false);
        }
        
    }

}
