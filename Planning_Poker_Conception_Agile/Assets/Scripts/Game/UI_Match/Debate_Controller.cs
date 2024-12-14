using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Debate_Controller : MonoBehaviour
{

    public GameObject objMaxPLNames;
    private TMP_Text textMaxPlNames;

    public GameObject objMinPLNames;
    private TMP_Text textMinPlNames;

    public Results_Controller  results_Scrpt;
    public Vote_Controller vote_scrpt;

    public Sprite[] cardSprites;
    public GameObject maxCard;
    public GameObject minCard;



    public GameObject objMinutes;
    private TMP_Text textMinutes;

    public GameObject objSeconds;
    private TMP_Text textSeconds;
    private bool thereIsTime = true;

    private float minutes = GameSettings.debateTimer[0];
    private float seconds = GameSettings.debateTimer[1];


    public GameObject objNotes;
    private TMP_Text  textNotes;

    public string notes;


    //check game Mode
    public GameObject[] current = new GameObject[2];
    public GameObject[] next = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        textMaxPlNames = objMaxPLNames.GetComponent<TMP_Text>();
        textMinPlNames = objMinPLNames.GetComponent<TMP_Text>();

        setNames();
        setCards();


        textMinutes = objMinutes.GetComponent<TMP_Text>();
        textSeconds = objSeconds.GetComponent<TMP_Text>();

        textMinutes.text = minutes.ToString();

        if (seconds == 0)
        {
            seconds = -1;
        }

        if(minutes == 99)
        {
            noTime();
        }

        textNotes = objNotes.GetComponent<TMP_Text>();

    }


    private void setNames()
    {
        textMaxPlNames.text = "";
        textMinPlNames.text = "";

        foreach (string name in results_Scrpt.maxDebateSide)
        {
            textMaxPlNames.text += name + "\r\n";
        }

        foreach (string name in results_Scrpt.minDebateSide)
        {
            textMinPlNames.text += name + "\r\n" ;
        }

    }

    private void setCards()
    {
        string min, max;

        max = vote_scrpt.results[results_Scrpt.maxDebateSide[0]];
        min = vote_scrpt.results[results_Scrpt.minDebateSide[0]];

        maxCard.GetComponent<SpriteRenderer>().sprite = cardSprites[findSprite(max)];
        minCard.GetComponent<SpriteRenderer>().sprite = cardSprites[findSprite(min)];

    }

    private int findSprite(string x)
    {
        switch (x)
        {
            case "0":
                return 0;


            case "1":
                return 1;

            case "2":
                return 2;

            case "3":
                return 3;

            case "5":
                return 4;

            case "8":
                return 5;

            case "13":
                return 6;

            case "20":
                return 7;

            case "40":
                return 8;

            case "100":
                return 9;

            case "?":
                return 10;

            case "Coffee":

                return 11;

            default:
                return -1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (thereIsTime)
        {
            if (minutes >= 0)
            {
                countDown();
            }
            else
            {
                endDebate();
            }
        }


        getNotes();

    }


    private void noTime()
    {
        thereIsTime = false;

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

    private void getNotes()
    {
        notes = textNotes.text;

    }

    public void endDebate()
    {
        //check game Mode
        vote_scrpt.textNotepad.text = notes;
        vote_scrpt.reStartVote();
        
        for (int i = 1; i < results_Scrpt.players_results.Count; i++)
        {
            Destroy(results_Scrpt.players_results[i]);
        }
        

        for (int i = 0; i < 2; i++) {
            current[i].SetActive(false);
            next[i].SetActive(true);
        }
    }
}
