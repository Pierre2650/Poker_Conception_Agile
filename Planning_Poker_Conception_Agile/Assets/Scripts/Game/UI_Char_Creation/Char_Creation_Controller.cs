using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Char_Creation_Manager : MonoBehaviour
{
    public GameObject input;
    private TMP_InputField textInput;

    public GameObject[] next = new GameObject[2];
    public GameObject thisUI;

    public GameObject playerNumber;
    private TMP_Text textPlayerNumber;

    public GameObject exception;
    private TMP_Text textException;

    private int currentPlayer = 0;


    // Start is called before the first frame update
    void Start()
    {
        textInput = input.GetComponent<TMP_InputField>();
        textPlayerNumber = playerNumber.GetComponent<TMP_Text>();
        textException = exception.GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayer <= GameSettings.numberOfPlayers) { 
            int temp = currentPlayer + 1;
            textPlayerNumber.text = "Player " + temp.ToString();
        }
    }


    public void confirmNickName()
    {
        if(textInput.text != "")
        {
            GameSettings.playerNames.Add(textInput.text);

            currentPlayer++;
            textInput.text = "";

            if (currentPlayer == GameSettings.numberOfPlayers)
            {
                foreach (GameObject obj in next)
                {
                    obj.SetActive(true);
                }

                thisUI.SetActive(false);
            }

            showException(0);
        }
        else
        {
            showException(1);
        }
    }


    private void showException(int x)
    {
        switch (x)
        {
            case 0:

                exception.SetActive(false);

                break;

            case 1:

                textException.text = "*Nickname cant be null";
                exception.SetActive(true);

                break;

            case 2:

                textException.text = "*All fields must be Filled";
                exception.SetActive(true);

                break;

        }

    }
}
