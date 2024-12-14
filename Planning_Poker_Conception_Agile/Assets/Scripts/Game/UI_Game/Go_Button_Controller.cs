using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Go_button_controller : MonoBehaviour
{
    public GameObject[] disable = new GameObject[2];
    public GameObject[] next = new GameObject[2];

    public GameObject[] userStory = new GameObject[3];
    private TMP_Text[] contenu = new TMP_Text[3];

    private void Start()
    {
        int i = 0;
        foreach (GameObject obj in userStory)
        {

            contenu[i] = obj.GetComponent<TMP_Text>();
            i++;
        }
    }

    public void goButton()
    {
        GameSettings.taskBeingEvaluated.Role = contenu[0].text;
        GameSettings.taskBeingEvaluated.Task = contenu[1].text;
        GameSettings.taskBeingEvaluated.Obj = contenu[2].text;
        GameSettings.taskBeingEvaluated.Value = "None";

        for (int i = 0; i < 2; i++)
        {
            disable[i].SetActive(false);
            next[i].SetActive(true);

        }
    }
}
