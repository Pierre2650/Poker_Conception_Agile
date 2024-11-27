using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Description_Controller : MonoBehaviour
{
    public GameObject descriptionField;
    private TMP_InputField descriptionText;
    private void Start()
    {
        descriptionText = descriptionField.GetComponent<TMP_InputField>();

    }
    

    public void selection(int index)
    {

        switch (index)
        {
            case 0:
                descriptionText.text = "Hola como estas?";
                break;
            case 1:
                descriptionText.text = "Bien y tu?";
                break;

        }
    }
    
}
