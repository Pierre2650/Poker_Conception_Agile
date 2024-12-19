using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/**@file
*@brief Class Description: Script Qui est chargee de la gestion de l'interface Coffee (Ou pause Cafe)
*/

public class Coffee_Controller : MonoBehaviour
{
   /**@class Coffee_Controller.
   * @brief Controlleur qui gere les differentes fonctionalites de cette interface. Il va sauvegarder le Backlog current dans un JSON dans le repertoire Documents de la machine.
   * Il va definir la functionalite des differentes buttons.
   * 
   * @var GameObject current
   * @brief Variable qui contient le GameObject de cette interface.
   * @var GameObject[] continueGame
   * @brief  Liste qui contient les GameObjects  a activer lorsqu'on veut retourner au jeu.
   * 
   * @var GameObject objFilePath
   * @brief Variable qui va contenir le GameObject du champ de texte qui decrit le chemin du repertoir ou a ete enregistre le JSON.
   * @var TMP_Text textFilePath
   * @brief Variable qui  contient la composante texte du GameObject objFilePath.
   * 
   * @var string documentsPath
   * @brief Variable qui contient le chemin du repertoir documents de la machine utilisateur.
   * 
   * @var Vote_Controller vote_Scrpt
   * @brief Script Controlleur de la partie vote du match
   * @var Results_Controller results_Scrpt
   * @brief Script Controlleur de la partie resultat du match
   * 
   */

    [Header("Continue")]
    public GameObject current;
    public GameObject[] continueGame = new GameObject[2];


    [Header("Path Folder")]
    public GameObject objFilePath;
    private TMP_Text textFilePath;
   
    private string documentsPath;


    [Header("Foreign Scripts")]
    public Vote_Controller vote_Scrpt;
    public Results_Controller results_Scrpt;


    private void Awake()
    {
        ///@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree. La methode  Awake s'excecute avant  la methode Start. Besoin de ceci car la methode OnEnable s'execute avant Start aussi

        textFilePath = objFilePath.GetComponent<TMP_Text>();
        documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        textFilePath.text = documentsPath;
    }

    private void OnEnable()
    {
        ///@brief Remplissage de variable text pour afficher a l'interface et sauvegarde du JSON
        documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        saveCurrentBacklogState();
        
    }


    private void saveCurrentBacklogState()
    {
        ///@brief Methode qui va serialiser le backlog en JSON dans son etat courante et va le sauvegarder dans le repertoire Documents

        //1.create a new json file
        //2.Take Backlog
        //3.trasform into json format
        //4.write in file
        //5.save file

        string json = "{\r\n\t\"Backlog\":[\r\n";
        json = serialiazeBacklog(json);

        json += "\t]\r\n}";

        //Save file
        string fileName = "Backlog_Current_State.json";
        documentsPath += "\\" + fileName;

        File.WriteAllText(documentsPath, json);

    }

    private string serialiazeBacklog(string json)
    {
        ///@brief Methode qui serialise le backlog

        int i = 0;
        //3.
        foreach (Backlog_Information x in GameSettings.backlogList)
        {
            if (i == (GameSettings.numberOfTaskEvaluted + GameSettings.numberOfTasksToEvalute) - 1)
            {
                json += "\t\t" + JsonUtility.ToJson(x) + "\r\n";

            }
            else
            {
                json += "\t\t" + JsonUtility.ToJson(x) + ",\r\n";

            }

            i++;
        }

        return json;

    }
    public void pressContinue()
    {
        ///@brief Methode qui est lance lorsqu'on appui sur le button continue. Il va revenir au jeux
        results_Scrpt.restart();
        vote_Scrpt.reStartVote();
        vote_Scrpt.round = 0;
        vote_Scrpt.textNotepad.text = "";
        vote_Scrpt.setRound(0);


        for (int i = 0; i < 2; i++) {
            continueGame[i].SetActive(true);
        }

        current.SetActive(false);

    }

    public void pressExitGame()
    {
        ///@brief Methode Utilise par le Button Exit qui ferme l'application
        Application.Quit();

    }


    public void pressMenu()
    {
        ///@brief Methode Utilise par le Button Menu qui retourne au menu du jeux et reinitialise la classe statique GameSettings
        GameSettings.reset();
        SceneManager.LoadScene("Menu");
    }
}
