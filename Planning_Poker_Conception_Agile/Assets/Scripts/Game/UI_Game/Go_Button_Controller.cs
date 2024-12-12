using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go_button_controller : MonoBehaviour
{
    public GameObject[] disable = new GameObject[2];
    public GameObject[] next = new GameObject[2];

    public void goButton()
    {
        for (int i = 0; i < 2; i++)
        {
            disable[i].SetActive(false);
            next[i].SetActive(true);

        }
    }
}
