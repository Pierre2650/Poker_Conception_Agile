using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Input_Value_Verification : MonoBehaviour
{
    private TMP_InputField myInputField;
    public GameObject exception;
    private TMP_Text textException;
    

    // Start is called before the first frame update
    void Start()
    {
        myInputField = GetComponent<TMP_InputField>();
        textException = exception.GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myInputField.text == "") {
            GameSettings.numberOfPlayers = 0;
        }
        else
        {
            onlyNumbersCheck();
        }
        
        
    }

    private void onlyNumbersCheck()
    {

        if (int.TryParse(myInputField.text,out int a))
        {
            if(a > 10)
            {
                myInputField.text = "10";
            }

            if( GameSettings.numberOfPlayers != a)
            {

                GameSettings.numberOfPlayers = a;

            }


            showException(0);
        }
        else
        {
            if (myInputField.text != "")
            {
                myInputField.text = "";
                showException(2);
            }
            
            
        }

       
    }

    private void showException(int x)
    {
        switch (x)
        {
            case 0:

                exception.SetActive(false);

                break;

            case 2:

                textException.text = "*Input is not a number";
                exception.SetActive(true);

                break;

        }

    }




}
