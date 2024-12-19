using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui est chargee de la gestion de l'interface Debate
*/
public class Debate_Controller : MonoBehaviour
{
    /**
     * @class Debate_Controller
     * @brief Controleur responsable de la gestion de l'interface de debat, incluant le chronometre, les cartes, et le input de notes.
     *
     * @var GameObject objMaxPLNames
     * @brief GameObject representant l'affichage des noms des joueurs avec la valeur d'evaluation maximale.
     * @var TMP_Text textMaxPlNames
     * @brief  Composant Texte de le GameObject objMaxPLNames.
     *
     * @var GameObject objMinPLNames
     * @brief GameObject representant l'affichage des noms des joueurs avec la valeur d'evaluation minimale.
     * @var TMP_Text textMinPlNames
     * @brief Composant Texte de le GameObject objMinPLNames.
     *
     * @var Results_Controller results_Scrpt
     * @brief Reference au Script controleur gerant les resultats.
     * @var Vote_Controller vote_scrpt
     * @brief Reference au Script controleur gerant les votes.
     * @var Game_Controller game_scrpt
     * @brief Reference au script controleur gerant le jeu global.
     *
     * @var Sprite[] cardSprites
     * @brief Tableau de sprites possibles pour les cartes.
     * @var GameObject maxCard
     * @brief GameObject representant la carte du/des joueur avec la valeur maximale.
     * @var GameObject minCard
     * @brief GameObject representant la carte du/des joueur avec la valeur minimale.
     *
     * @var GameObject objMinutes
     * @brief GameObject representant l'affichage des minutes du chronometre.
     * @var TMP_Text textMinutes
     * @brief Composant Texte de le GameObject objMinutes
     *
     * @var GameObject objColon
     * @brief GameObject representant l'affichage des deux-points ":" entre minutes et secondes.
     *
     * @var GameObject objSeconds
     * @brief GameObject representant l'affichage des secondes du chronometre.
     * @var TMP_Text textSeconds
     * @brief Composant Texte de le GameObject objSeconds
     * @var bool thereIsTime
     * @brief Indicateur de la presence d'un chronometre.
     *
     * @var float minutes
     * @brief Nombre initial de minutes pour le chronometre.
     * @var float seconds
     * @brief Nombre initial de secondes pour le chronometre.
     *
     * @var GameObject objNotes
     * @brief GameObject representant l'affichage des notes prises pendant le debat.
     * @var TMP_Text textNotes
     * @brief Composant texte pour objNotes.
     * @var string notes
     * @brief Chaine de caracteres representant les notes prises pendant le debat.
     *
     * @var GameObject[] current
     * @brief Tableau de GameObjects representant l'etat actuel.
     * @var GameObject[] next
     * @brief Tableau de GameObjects representant l'etat suivant.
     */

    public GameObject objMaxPLNames;
    private TMP_Text textMaxPlNames;

    public GameObject objMinPLNames;
    private TMP_Text textMinPlNames;

    [Header("Foreing Scripts")]
    public Results_Controller  results_Scrpt;
    public Vote_Controller vote_scrpt;
    public Game_Controller game_scrpt;

    public Sprite[] cardSprites;
    public GameObject maxCard;
    public GameObject minCard;



    public GameObject objMinutes;
    private TMP_Text textMinutes;

    public GameObject objColon;

    public GameObject objSeconds;
    private TMP_Text textSeconds;
    private bool thereIsTime = true;

    private float minutes = GameSettings.debateTimer[0];
    private float seconds = GameSettings.debateTimer[1];

    [Header("Notepad")]
    public GameObject objNotes;
    private TMP_Text  textNotes;

    public string notes;


    //check game Mode
    public GameObject[] current = new GameObject[2];
    public GameObject[] next = new GameObject[2];

    // Start is called before the first frame update

    private void Awake()
    {
        textMaxPlNames = objMaxPLNames.GetComponent<TMP_Text>();
        textMinPlNames = objMinPLNames.GetComponent<TMP_Text>();

        textMinutes = objMinutes.GetComponent<TMP_Text>();
        textSeconds = objSeconds.GetComponent<TMP_Text>();

        textNotes = objNotes.GetComponent<TMP_Text>();


        textMinutes.text = minutes.ToString();

        if (seconds == 0)
        {
            seconds = -1;
        }

        if (minutes == 99)
        {
            noTime();
        }

    }

    private void OnEnable()
    {

        setNames();
        setCards();


    }


    private void setNames()
    {
        /**
         * @brief Methode qui configure les noms des participants des deux cotes du debat (max et min).
         */

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
        /**
         * @brief Methode qui configure les images des cartes a afficher pour les participants avec les valeurs max et min.
         */
        string min, max;

        max = vote_scrpt.results[results_Scrpt.maxDebateSide[0]];
        min = vote_scrpt.results[results_Scrpt.minDebateSide[0]];



       maxCard.GetComponent<SpriteRenderer>().sprite = cardSprites[findSprite(max)];
       minCard.GetComponent<SpriteRenderer>().sprite = cardSprites[findSprite(min)];

     

    }


    private int findSprite(string x)
    {
        /**
         * @brief Methode qui retourne l'index du sprite correspondant a une valeur donnee.
         * @param x La valeur de la carte sous forme de chaine.
         * @return Index du sprite correspondant.
         */
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
        /**
         * @brief Methode appelee une fois par frame pour gerer le decompte du temps et verifier l'etat du debat.
         */
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
        /**
         * @brief Methode qui desactive le chronometre et cache les elements visuels lies au temps.
         */

        thereIsTime = false;
        objMinutes.SetActive(false);
        objColon.SetActive(false);
        objSeconds.SetActive(false);

    }


    private void countDown()
    {
        /**
         * @brief Methode qui gere le decompte du temps pour le chronometre du debat.
         */

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
        /**
         * @brief Methode qui recupere et met a jour les notes prises pendant le debat.
         */
        notes = textNotes.text;

    }


    public void endDebate()
    {
        /**
         * @brief Methode qui termine le debat, transfere les notes, et prepare l'interface pour le vote suivant.
         */

        vote_scrpt.textNotepad.text = notes;
        vote_scrpt.reStartVote();

        results_Scrpt.restart();

        

        for (int i = 0; i < 2; i++) {
            current[i].SetActive(false);
            next[i].SetActive(true);
        }
    }
}
