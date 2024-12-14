using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnGame_Current_Task_Texts_Controller : MonoBehaviour
{

    public GameObject[] userStory = new GameObject[3];
    private TMP_Text[] contenu = new TMP_Text[3];

    // Start is called before the first frame update
    void Awake()
    {
        int i = 0;
        foreach (GameObject obj in userStory)
        {

            contenu[i] = obj.GetComponent<TMP_Text>();
            i++;
        }



    }

    private void OnEnable()
    {
        contenu[0].text = GameSettings.backlogList[0].Role;
        contenu[1].text = GameSettings.backlogList[0].Task;
        contenu[2].text = GameSettings.backlogList[0].Obj;

    }
}
