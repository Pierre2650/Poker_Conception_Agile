using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vote_Controller : MonoBehaviour
{
    public GameObject objCurrentPlayer;
    private TMP_Text textCurrentPlayer;

    public GameObject objMinutes;
    private TMP_Text textMinutes;

    public GameObject objSeconds;
    private TMP_Text textSeconds;


    private float minutes = 2;//GameSettings.choiceTimer[0];
    private float seconds = -1;


    private Dictionary<string, string> results = new Dictionary<string, string>();

    // Start is called before the first frame update
    void Start()
    {
        textCurrentPlayer = objCurrentPlayer.GetComponent<TMP_Text>();
        textMinutes = objMinutes.GetComponent<TMP_Text>();
        textSeconds = objSeconds.GetComponent<TMP_Text>();

        textMinutes.text = minutes.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        if (minutes >= 0)
        {
            countDown();
        }



    }

    private void countDown()
    {
        if (seconds >= 0)
        {
            seconds -= Time.deltaTime;
            int temp = (int)seconds;

            if (temp < 10)
            {
                textSeconds.text = "0" + temp.ToString();

            }
            else
            {
                textSeconds.text = temp.ToString();

            }

        }
        else
        {
            minutes--;
            textMinutes.text = minutes.ToString();
            seconds = 60;

        }
       
        
        
    }

    public void choiceMade(string value)
    {

        // Careful with 's Turn
        results.Add(textCurrentPlayer.text, value);
        resetParam();

    }

    private void resetParam()
    {
        //next player
        //textCurrentPlayer.text = GameSettings.playerNames[next];
        minutes = 2;
        textMinutes.text = minutes.ToString();
        seconds = -1;


    }

}
