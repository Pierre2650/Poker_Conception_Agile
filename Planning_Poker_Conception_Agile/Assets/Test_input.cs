using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test_input : MonoBehaviour
{
    private TMP_Text output;
    public GameObject inputParent;
    private TMP_InputField input;

    // Start is called before the first frame update
    void Start()
    {
        output = GetComponent<TMP_Text>();
        input = inputParent.GetComponent<TMP_InputField>();
    }


    public void ButtonDemo()
    {
        output.text = input.text;
        input.text = "";
    }


}
