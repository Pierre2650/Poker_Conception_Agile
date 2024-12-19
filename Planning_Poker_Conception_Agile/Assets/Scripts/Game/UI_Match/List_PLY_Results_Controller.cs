using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui est chargee de la generation de Nametags dans l'interface Resultat
*/


public class List_PLY_Results_Controller: MonoBehaviour
{
    /**@class List_PLY_Results_Controller
    * @brief Controlleur qui va generer et afficher des names tags de chaque joueur dans l'interface avec leur choix de vote
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
    *@var Vote_Controller Rote_Scrpt
    *@brief Script Controlleur de la partie vote du match
    *@var Results_Controller Results_Scrpt
    *@brief Script Controlleur de la partie resultat du match
    *
    *@var List<GameObject> listOfResults
    *@brief Liste de GameObject des differentes valises
    *
    */

    public GameObject parentObject;

    public GameObject prefab;

    public GameObject toGetPosition;
    protected RectTransform rtToGetPosition;

    public float distanceFromEachother;



    public Vote_Controller Vote_Scrpt;
    public Results_Controller Results_Scpt;


    public List<GameObject> listOfResults = new List<GameObject>();


    private void OnEnable()
    {
        /** @brief On va generer les balises, ensuite on va transmetre au controlleur des resultat un liste avec toute les balises genere puis reinitialiser cette liste pour le prochain match
         * et reinitialiser rtToGetPosition avec la position de la seul balise qui n'est pas un prefab.
         *
         */

        generateNametags();
        
        Results_Scpt.players_results = new List<GameObject>(listOfResults);
        
        //reset
        listOfResults.Clear();
        rtToGetPosition = toGetPosition.GetComponent<RectTransform>();

    }


    private  void generateNametags()
    {
        ///@Brief Generation des noms en fonction de nombres de joueurs

        //First PLayer refence separarted
        
        rtToGetPosition = toGetPosition.GetComponent<RectTransform>();

        GameObject parentObjText_ToGetPosition = toGetPosition.transform.GetChild(3).gameObject;
        GameObject parentObjValue_ToGetPosition = toGetPosition.transform.GetChild(4).gameObject;

        GameObject childObjText_ToGetPosition = parentObjText_ToGetPosition.transform.GetChild(1).gameObject;
        GameObject childObjValue_ToGetPosition = parentObjValue_ToGetPosition.transform.GetChild(1).gameObject;

        TMP_Text childNameText = childObjText_ToGetPosition.GetComponent<TMP_Text>();
        TMP_Text childValueText = childObjValue_ToGetPosition.GetComponent<TMP_Text>();

        childNameText.text = GameSettings.playerNames[0];
        childValueText.text = Vote_Scrpt.results[GameSettings.playerNames[0]];

        listOfResults.Add(toGetPosition);


        if (GameSettings.numberOfPlayers <= 5)
        {
            for (int i = 1; i < GameSettings.numberOfPlayers ; i++)
            {

                generateAName(i);

            }

        }
        else
        {
            int i;
            float firstTogetPosition = rtToGetPosition.anchoredPosition.y;

            //Set new star position of rtToGetPosition
            rtToGetPosition.anchoredPosition = new Vector2(-463.82f, rtToGetPosition.anchoredPosition.y);

            for (i = 1; i <= 5; i++)
            {

                generateAName(i);


            }



            //Set new star position of rtToGetPosition
            rtToGetPosition.anchoredPosition = new Vector2(462.4f, firstTogetPosition);


            for (i = 6; i < GameSettings.numberOfPlayers; i++)
            {

                generateAName(i);
            }

        }


            



    }

    private void generateAName(int i)
    {
        //1.set parent
        //2. first instantiate set position
        //3. get text child
        //4. get text component
        //5. set text
        //6. continue to next child

        GameObject temp = Instantiate(prefab);

        listOfResults.Add(temp);

        //1.set parent
        temp.transform.parent = parentObject.transform;

        //2. first instantiate set position
        RectTransform rtTemp = temp.GetComponent<RectTransform>();
        rtTemp.localScale = Vector3.one;
        rtTemp.anchoredPosition = new Vector2(rtToGetPosition.anchoredPosition.x, rtToGetPosition.anchoredPosition.y - distanceFromEachother);

        //Set new rectTransform Reference for next prefab
        rtToGetPosition = rtTemp;

        //3.
        GameObject ParentChildObjNameText = temp.transform.GetChild(3).gameObject;
        GameObject ParentChildObjValueText = temp.transform.GetChild(4).gameObject;

        GameObject ChildObjNameText = ParentChildObjNameText.transform.GetChild(1).gameObject;
        GameObject ChildObjValueText = ParentChildObjValueText.transform.GetChild(1).gameObject;
        //4.
        TMP_Text childNameText = ChildObjNameText.GetComponent<TMP_Text>();
        TMP_Text childValueText = ChildObjValueText.GetComponent<TMP_Text>();

        //5. 
        //here different values
        childNameText.text = GameSettings.playerNames[i];
        childValueText.text = Vote_Scrpt.results[GameSettings.playerNames[i]];


    }


}
