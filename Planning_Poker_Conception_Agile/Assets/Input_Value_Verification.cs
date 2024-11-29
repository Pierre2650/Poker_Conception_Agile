using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Input_Value_Verification : MonoBehaviour
{
    private TMP_InputField myInputField;
    

    // Start is called before the first frame update
    void Start()
    {
        myInputField = GetComponent<TMP_InputField>();
        
    }

    // Update is called once per frame
    void Update()
    {

        onlyNumbersCheck();
        
    }

    private void onlyNumbersCheck()
    {

        if (int.TryParse(myInputField.text,out int a))
        {
            Debug.Log(a);
        }
        else
        {
            myInputField.text = "";
        }

       
    }


}
