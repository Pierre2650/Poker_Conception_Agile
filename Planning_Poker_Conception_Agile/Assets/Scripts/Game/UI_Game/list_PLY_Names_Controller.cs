using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class list_PLY_Names_Controller : MonoBehaviour
{
    public GameObject parentObject;

    public GameObject prefab;

    public string testTxt;

    public GameObject toGetPosition;
    private RectTransform rtToGetPosition;

    //variable for relative position\

    private void Start()
    {
        rtToGetPosition = toGetPosition.GetComponent<RectTransform>();
        generateNametags();
    }


    private void generateNametags()
    {

        //1.set parent
        //2. first instantiate set position
        //3. get text child
        //4. get text component
        //5. set text
        //6. continue to next child


        for (int i = 0; i < GameSettings.numberOfPlayers; i++)
        {

            GameObject temp = Instantiate(prefab);

            //1.
            temp.transform.parent = parentObject.transform;

            //2.
            RectTransform rtTemp = temp.GetComponent<RectTransform>();
            rtTemp.localScale = Vector3.one;
            rtTemp.anchoredPosition = new Vector2(rtToGetPosition.anchoredPosition.x, rtToGetPosition.anchoredPosition.y - 110);
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
