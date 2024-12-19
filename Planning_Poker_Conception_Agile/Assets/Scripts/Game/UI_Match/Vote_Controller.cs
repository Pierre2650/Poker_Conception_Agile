using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Codice.CM.Common.CmCallContext;
using static PlasticGui.GetProcessName;

/**@file
*@brief Class Description: Script Qui est chargee de la gestion de l'interface Vote
*/

public class Vote_Controller : MonoBehaviour
{
    /**@class Vote_Controller
    * @brief Controleur des actions liees a l'interface de vote, la classe permet de gerer les elements comme
    *  le suivi des joueurs actuels, du chronometre, des rounds et l'enregistrement des evaluations.
    * 
    * @var GameObject objCurrentPlayer
    * @brief GameObject representant l'affichage du nom du joueur actuel.
    * 
    * @var TMP_Text textCurrentPlayer
    * @brief Texte composant de le GameObject objCurrentPlayer
    * 
    * @var GameObject objMinutes
    * @brief GameObject representant l'affichage des minutes du chronometre.
    * 
    * @var TMP_Text textMinutes
    * @brief Texte composant de le GameObject objMinutes.
    * 
    * @var GameObject objSeconds
    * @brief GameObject representant l'affichage des secondes du chronometre.
    * 
    * @var TMP_Text textSeconds
    * @brief  Texte composant de objSeconds.
    *  
    * @var float minutes
    * @brief Nombre initial de minutes pour le chronometre.
    * 
    * @var float seconds
    * @brief Nombre initial de secondes pour le chronometre.
    * 
    * @var int currentPlayerIndex
    * @brief Index du joueur actuel dans la liste des joueurs.
    * 
    * @var GameObject[] current
    * @brief Tableau des GameObject representant les GameObjets en utilisation (Vote UI et Vote non UI qui contient les cartes).
    * 
    * @var GameObject next
    * @brief GameObject representant les GameObjets  suivant  (results_UI).
    * 
    * @var GameObject objNbRound
    * @brief GameObject representant l'affichage du nombre de rounds.
    * 
    * @var TMP_Text textNbRound
    * @brief  Texte composant de objNbRound.
    * 
    * @var int round
    * @brief Numero du round actuel.
    * 
    * @var GameObject objNotepad
    * @brief GameObject representant l'affichage du bloc-notes.
    * 
    * @var TMP_Text textNotepad
    * @brief  Texte composant de objNotepad
    * 
    * @var Results_Controller results_Scrpt
    * @brief Reference au script Results_Controller pour transmettre les information apres les votes.
    * 
    * @var Dictionary<string, string> results
    * @brief Dictionnaire stockant les resultats des votes sous forme de paires cle-valeur.
    */


    [Header("Current PLayer")]
    public GameObject objCurrentPlayer;
    private TMP_Text textCurrentPlayer;

    [Header("Time")]
    public GameObject objMinutes;
    private TMP_Text textMinutes;

    public GameObject objSeconds;
    private TMP_Text textSeconds;

    private float minutes = GameSettings.choiceTimer[0];
    private float seconds = GameSettings.choiceTimer[1];


    private int currentPlayerIndex = 0;

    [Header("Button Next")]
    public GameObject[] current = new GameObject[2];
    public GameObject next;

    [Header("Number of Rounds")]
    public GameObject objNbRound;
    private TMP_Text textNbRound;
    public int round = 0;

    [Header("NotePad")]
    public GameObject objNotepad;
    public TMP_Text textNotepad;


    [Header("Foreing Scripts")]
    public Results_Controller results_Scrpt;

    public Dictionary<string, string> results = new Dictionary<string, string>();

    private void Awake()
    {
        ///@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree
        textCurrentPlayer = objCurrentPlayer.GetComponent<TMP_Text>();

        textMinutes = objMinutes.GetComponent<TMP_Text>();
        textSeconds = objSeconds.GetComponent<TMP_Text>();

        textNbRound = objNbRound.GetComponent<TMP_Text>();

        textNotepad = objNotepad.GetComponent<TMP_Text>();

    }

    
    private void Start()
    {
        ///@brief Au Debut commencer dans le round 1 pas 0,  afficher le nombre du premiere joeur  et declancher le timer
        round++;
        setRound(round);

        textCurrentPlayer.text = GameSettings.playerNames[0] + "'s Turn";

        resetTimer();
    }




    // Update is called once per frame
    void Update()
    {
        /**
         * @brief Methode appelee a chaque frame pour verifier les conditions de jeu et mettre a jour l'interface 
         * si tous les joueurs ont joue remet a zero l'index du joueur et lance la revue des resultats.
         * Met a jour le chronometre tant que les minutes ne sont pas a zero.
         * Si le temps est ecoule, appelle `choiceMade` avec une valeur par defaut ("?").
         */

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
            choiceMade("?");
        }
        

    }


    public void setRound(int round)
    {
        /**
         * @brief Methode qui configure et affiche le numero du round actuel.s
         * @param round Numero du round a afficher.
         */
        textNbRound.text = "Round " + round.ToString();
    }

    private void countDown()
    {
        /**
         * @brief Methode qui gere le decompte du chronometre pendant le tour d'un joueur et met a jour l'affichage des minutes et secondes.
         * Reduit les secondes chaque frame, lorsque les secondes atteignent zero, reduit les minutes et reinitialise les secondes a 60.
         * 
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

    public void choiceMade(string value)
    {
        /**
         * @brief Methode appelee lorsque le joueur fait un choix. Enregistre le choix du joueur actuel dans le dictionnaire `results`.
         * Passe au joueur suivant en appelant `nextPlayer`, sauf si tous les joueurs ont deja joue et reinitialise le chronometre pour le prochain joueur.
         * 
         * @param value Valeur choisie par le joueur dedans une carte.
         */


        textCurrentPlayer.text = textCurrentPlayer.text.Replace("'s Turn", "");

        results.Add(textCurrentPlayer.text, value);

        currentPlayerIndex++;

        if (currentPlayerIndex < GameSettings.numberOfPlayers)
        {
            nextPlayer();
        }
       
      
        resetTimer();

      
    }

    private void resetTimer()
    {
        /**
         * @brief Methode qui reinitialise le chronometre pour le prochain joueur. Configure les minutes et les secondes avec les valeurs definies dans `GameSettings.choiceTimer`.
         * Si les secondes valent zero, elles sont reglees a -1 pour signaler que le temps est ecoule.
         */
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
        /**
        * @brief Methode qui passe au joueur suivant et met a jour l'affichage de son nom, affiche le nom du prochain joueur suivi de "'s Turn".
        */

        textCurrentPlayer.text = GameSettings.playerNames[currentPlayerIndex] + "'s Turn";

    }


    public void reStartVote()
    {
        /**
         * @brief Methode qui reinitialise le vote pour un nouveau round.Elle va incrementer le numero de round et met a jour l'affichage correspondant,
         * reinitialiser l'index du joueur actuel a zero, vide le dictionnaire `results` pour preparer la collecte des nouveaux votes,
         * afficher le nom du premier joueur suivi de "'s Turn" et reinitialise le chronometre pour le debut du nouveau round.
         */
        round++;
       currentPlayerIndex = 0;
       textNbRound.text = "Round "+ round.ToString();

       results.Clear();


       textCurrentPlayer.text = GameSettings.playerNames[0] + "'s Turn";

       resetTimer();
    }


    private void reviewResults()
    {
        /**
         * @brief Methode activee  lorsque le derniere joeur a fait son choix pour  pour passer a l'etape suivante.
         * 
         */

        next.SetActive(true);


        //dependence of game mode
        for (int i = 0; i < 2; i++) {

            current[i].SetActive(false);
            
        }

       
    }


}
