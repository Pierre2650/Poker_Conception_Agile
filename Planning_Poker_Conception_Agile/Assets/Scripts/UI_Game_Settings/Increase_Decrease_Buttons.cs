using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Increase_Decrease_Buttons : MonoBehaviour
{
    public GameObject minutes;
    public GameObject seconds;

    private TMP_Text minutesText;
    private TMP_Text secondsText;

    private void Start()
    {
        minutesText = minutes.GetComponent<TMP_Text>();
        secondsText = seconds.GetComponent<TMP_Text>();
    }

    public void increaseMinutes()
    {
        int temp = int.Parse(minutesText.text);

        temp++;

        if (temp > 5)
        {
            temp = 0;
        }
  
        
        minutesText.text = temp.ToString();

    }

    public void decreaseMinutes() {
        int temp = int.Parse(minutesText.text);

        temp--;

        if (temp < 0)
        {
            temp = 5;
        }


        minutesText.text = temp.ToString();
    }

    public void increaseSeconds()
    {
        int temp = int.Parse(secondsText.text);

        temp+= 5;

        if (temp > 55)
        {
            temp = 0;
        }

        if (temp < 10) {
            secondsText.text = "0"+temp.ToString();

        }
        else
        {
            secondsText.text = temp.ToString();

        }


        

    }

    public void decreaseSeconds()
    {
        int temp = int.Parse(secondsText.text);

        temp-= 5;

        if (temp < 0)
        {
            temp = 55;
        }


        if (temp < 10)
        {
            secondsText.text = "0" + temp.ToString();

        }
        else
        {
            secondsText.text = temp.ToString();

        }
    }


}
