using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Results_Review_Next_Controller : MonoBehaviour
{
    public GameObject current;
    public GameObject[] next = new GameObject[2];

    public void startDebate()
    {
        current.SetActive(false);

        for (int i = 0; i < next.Length; i++)
        {
            next[i].SetActive(true);
        }
    }

}
