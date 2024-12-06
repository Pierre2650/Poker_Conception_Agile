using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Debate_Timer_Controller : MonoBehaviour
{

    public GameObject minutes;
    public GameObject seconds;
    private TMP_Text minutesText;
    private TMP_Text secondsText;

    public List<GameObject> buttons;

    private bool noTime = false;

    private void Start()
    {
        minutesText = minutes.GetComponent<TMP_Text>();
        secondsText = seconds.GetComponent<TMP_Text>();
        GameSettings.debateTimer[0] = 1;
        GameSettings.debateTimer[1] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!noTime)
        {
            GameSettings.debateTimer[0] = int.Parse(minutesText.text);
            GameSettings.debateTimer[1] = int.Parse(secondsText.text);
        }
       

    }

    public void noTimerButton()
    {
        
        noTime = !noTime;

        if (noTime)
        {
            foreach (GameObject button in buttons)
            { 
                Button temp = button.GetComponent<Button>();
                temp.interactable = false;

            }

            minutesText.text = "0";
            secondsText.text = "00";
            GameSettings.debateTimer[0] = 99;
            GameSettings.debateTimer[1] = 0;
        }
        else {
            foreach (GameObject button in buttons)
            {
                Button temp = button.GetComponent<Button>();
                temp.interactable = true;

            }

            minutesText.text = "1";
            secondsText.text = "00";

        }
        
    }
}
