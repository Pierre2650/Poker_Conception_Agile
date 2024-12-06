using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Choice_Timer_Controller : MonoBehaviour
{
    public GameObject minutes;
    public GameObject seconds;

    private TMP_Text minutesText;
    private TMP_Text secondsText;

    private void Start()
    {
        minutesText = minutes.GetComponent<TMP_Text>();
        secondsText = seconds.GetComponent<TMP_Text>();
        GameSettings.choiceTimer[0] = 1;
        GameSettings.choiceTimer[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {

        GameSettings.choiceTimer[0] = int.Parse(minutesText.text);
        GameSettings.choiceTimer[1] = int.Parse(secondsText.text);

    }
}
