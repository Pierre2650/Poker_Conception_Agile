using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Codice.CM.Common.CmCallContext;
using static PlasticGui.GetProcessName;

public class Vote_Controller : MonoBehaviour
{
    public GameObject objCurrentPlayer;
    private TMP_Text textCurrentPlayer;

    public GameObject objMinutes;
    private TMP_Text textMinutes;

    public GameObject objSeconds;
    private TMP_Text textSeconds;

    private float minutes = GameSettings.choiceTimer[0];
    private float seconds = GameSettings.choiceTimer[1];

    private int currentPlayerIndex = 0;

    public GameObject[] current = new GameObject[2];
    public GameObject next;

    public GameObject objNbRound;
    private TMP_Text textNbRound;
    private int round = 0;

    public GameObject objNotepad;
    public TMP_Text textNotepad;

    public Results_Controller results_Scrpt;

    public Dictionary<string, string> results = new Dictionary<string, string>();

    public List<string> temp = new List<string>();
    public List<string> temp2 = new List<string>();


    private void Awake()
    {
        textCurrentPlayer = objCurrentPlayer.GetComponent<TMP_Text>();

        textMinutes = objMinutes.GetComponent<TMP_Text>();
        textSeconds = objSeconds.GetComponent<TMP_Text>();

        textNbRound = objNbRound.GetComponent<TMP_Text>();

        textNotepad = objNotepad.GetComponent<TMP_Text>();

    }

    
    private void Start()
    {
        round++;
        textNbRound.text = "Round " + round.ToString();

        textCurrentPlayer.text = GameSettings.playerNames[0] + "'s Turn";

        resetTimer();
    }

    /*
    private void OnEnable()
    {
        round++;
        textNbRound.text = "Round " + round.ToString();

        results.Clear();

        textCurrentPlayer.text = GameSettings.playerNames[0] + "'s Turn";

        resetTimer();
    }*/


    // Update is called once per frame
    void Update()
    {

        if (currentPlayerIndex == GameSettings.numberOfPlayers) {

            currentPlayerIndex = 0;
            textCurrentPlayer.text = GameSettings.playerNames[currentPlayerIndex] + "'s Turn";

            reviewResults();
        }

        if (minutes >= 0)
        {
            countDown();
        }
        else
        {
            nextPlayer();
        }


        

    }

    private void updateDiction()
    {
        temp.Clear();
        temp2.Clear();

        foreach (var kvp in results)
        {
            temp.Add(kvp.Key);
            temp2.Add(kvp.Value);

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
        textCurrentPlayer.text = textCurrentPlayer.text.Replace("'s Turn", "");

        results.Add(textCurrentPlayer.text, value);

        currentPlayerIndex++;

        if (currentPlayerIndex < GameSettings.numberOfPlayers)
        {
            nextPlayer();
        }
       
        updateDiction();
        resetTimer();

      
    }

    private void resetTimer()
    {
        minutes = GameSettings.choiceTimer[0];
        textMinutes.text = minutes.ToString();

        seconds = GameSettings.choiceTimer[1];
        if (seconds == 0)
        {
            seconds = -1;
        }

    }

    private void nextPlayer()
    {
        textCurrentPlayer.text = GameSettings.playerNames[currentPlayerIndex] + "'s Turn";

    }


    public void reStartVote()
    {
       round++;
       currentPlayerIndex = 0;
       textNbRound.text = "Round "+ round.ToString();

       results.Clear();
       temp.Clear();
       temp2.Clear();

       textCurrentPlayer.text = GameSettings.playerNames[0] + "'s Turn";

       resetTimer();
    }


    private void reviewResults()
    {

        //dependence of game mode
        for (int i = 0; i < 2; i++) {

            current[i].SetActive(false);
            
        }

        next.SetActive(true);

       
    }


}
