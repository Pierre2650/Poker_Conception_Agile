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
    protected RectTransform rtToGetPosition;

    public float distanceFromEachother;

    //variable for relative position\

    private void Awake()
    {
        rtToGetPosition = toGetPosition.GetComponent<RectTransform>();

        GameObject childObjTextToGetPosition = toGetPosition.transform.GetChild(1).gameObject;
        TMP_Text childText = childObjTextToGetPosition.GetComponent<TMP_Text>();
        childText.text = GameSettings.playerNames[0];

    }

    private void OnEnable()
    {
        generateNametags();
    }


    protected virtual void generateNametags()
    {

        //1.set parent
        //2. first instantiate set position
        //3. get text child
        //4. get text component
        //5. set text
        //6. continue to next child


        for (int i = 1; i < GameSettings.numberOfPlayers; i++)
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
