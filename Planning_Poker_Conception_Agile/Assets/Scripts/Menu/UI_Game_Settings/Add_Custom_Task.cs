using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Add_Custom_Task : MonoBehaviour
{
    public GameObject[] Inputs = new GameObject[3];
    private TMP_InputField[] inputFields = new TMP_InputField[3];

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 3; i++) {
            inputFields[0] = Inputs[i].GetComponent<TMP_InputField>();
        }
        
    }

    public void addNewTask()
    {

    }
}
