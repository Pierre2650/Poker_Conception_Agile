using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui est chargee de la generation de Nametags dans l'interface Game
*/


public class list_PLY_Names_Controller : MonoBehaviour
{
    /**@class list_PLY_Names_Controller
    * @brief Controlleur qui va generer et afficher des names tags de chaque joueur dans l'interface
    * 
    * @var GameObject parentObject
    * @brief GameObject parent des Tags a generer.
    * 
    * @var GameObject prefab
    * @brief Prefab d'un modele de tag de base
    * 
    * @var GameObject toGetPosition
    * @brief Cette GameObject Commence avec la reference du seul nametag qui n'est pas un prefab (le premiere), besoin de ce si pour avoir un position relative pour les autres balises.
    * 
    * @var RectTransform rtToGetPosition
    * @brief Variable qui  contient la composante RectTransform du GameObject toGetPosition.
    * 
    * @var float distanceFromEachother
    * @brief La distance entre chaque name tag
    * 
    */

    public GameObject parentObject;

    public GameObject prefab;

    public GameObject toGetPosition;
    private RectTransform rtToGetPosition;

    public float distanceFromEachother;

    private void Awake()
    {

        rtToGetPosition = toGetPosition.GetComponent<RectTransform>();

        GameObject childObjTextToGetPosition = toGetPosition.transform.GetChild(1).gameObject;
        TMP_Text childText = childObjTextToGetPosition.GetComponent<TMP_Text>();
        childText.text = GameSettings.playerNames[0];

    }

    private void Start()
    {

        generateNametags();

    }
   


    public void generateNametags()
    {
        /**
         * @brief Methode qui genere des etiquettes de nom pour chaque joueur en fonction des parametres de configuration.
         * 
         * Cette methode effectue les etapes suivantes :
         * 1. Definit le parent de l'objet genere.
         * 2. Instancie l'objet prefab et definit sa position.
         * 3. Recupere l'enfant contenant le texte.
         * 4. Recupere le composant texte de l'enfant.
         * 5. Definit le texte avec le nom du joueur.
         * 6. Passe a l'objet suivant.
         */


        for (int i = 1; i < GameSettings.numberOfPlayers ; i++)
        {

            GameObject temp = Instantiate(prefab);

            //1.
            temp.transform.parent = parentObject.transform;

            //2.
            RectTransform rtTemp = temp.GetComponent<RectTransform>();
            rtTemp.localScale = Vector3.one;
            rtTemp.anchoredPosition = new Vector2(rtToGetPosition.anchoredPosition.x, rtToGetPosition.anchoredPosition.y - distanceFromEachother);
            rtToGetPosition = rtTemp;

            //3.
            GameObject childObjText = temp.transform.GetChild(1).gameObject;


            //4.
            TMP_Text childText = childObjText.GetComponent<TMP_Text>();

            //5. 
            childText.text = GameSettings.playerNames[i];

        }
         



}


}
