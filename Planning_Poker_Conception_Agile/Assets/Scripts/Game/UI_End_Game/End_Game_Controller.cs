using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleFileBrowser;
using System.IO;

/**@file
*@brief Class Description: Script Qui est chargee de la gestion de l'interface End_Game (ou fin du jeu)
*/
public class End_Game_Controller : MonoBehaviour
{
    /**@class End_Game_Controller.
    * @brief Controlleur qui  gere les differentes fonctionalites de cette interface. Il va montrer recapitulatif de toute les taches qu'on peut reviser une par une.
    * Il va definir la functionalite des differentes buttons.
    * 
    * @var GameObject[] userStory
    * @brief Tableau contenant les GameObjects representant les recits utilisateur.
    * 
    * @var TMP_Text[] contenu
    * @brief Tableau de composante texte affichant les details des userStory.
    * 
    * @var string contenuValue
    * @brief Variable qui contient l'evaluation de la tache affiche.
    * 
    * @var GameObject nbTasks
    * @brief Variable qui va contenir le GameObject du champ de texte du  nombre total de taches.
    * 
    * @var TMP_Text textNbTasks
    * @brief Composant texte lie a l'objet nbTasks.
    * 
    * @var GameObject noteCard
    * @brief GameObject qui contient l'image de la carte utilisee pour afficher l'evaluation donee a la tache.
    * 
    * @var Image imageCard
    * @brief Composant image associe a noteCard.
    * 
    * @var Sprite[] cardImages
    * @brief Tableau contenant les differentes images des cartes.
    * 
    * @var int taskIndex
    * @brief Index de la tache actuellement selectionnee.
    * 
    * @var string jsonFolderPath
    * @brief Chemin vers le dossier contenant les fichiers JSON.
    * 
    */

    public GameObject[] userStory = new GameObject[3];
    private TMP_Text[] contenu = new TMP_Text[4];
    private string contenuValue;

    public GameObject nbTasks;
    private TMP_Text textNbTasks;

    public GameObject noteCard;
    private Image imageCard;

    public Sprite[] cardImages;

    private int taskIndex = 0;

    private string jsonFolderPath;


    // Start is called before the first frame update
    void Awake()
    {
        ///@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree. La methode  Awake s'excecute avant  la methode Start. Besoin de ceci car la methode OnEnable s'execute avant Start aussi

        textNbTasks = nbTasks.GetComponent<TMP_Text>();

        imageCard = noteCard.GetComponent<Image>();


        int i = 0;
        foreach (GameObject obj in userStory)
        {

            contenu[i] = obj.GetComponent<TMP_Text>();
            i++;
        }

        contenu[0].text = GameSettings.backlogList[taskIndex].Role;
        contenu[1].text = GameSettings.backlogList[taskIndex].Task;
        contenu[2].text = GameSettings.backlogList[taskIndex].Obj;
        contenuValue = GameSettings.backlogList[taskIndex].Value;

        findValueSprite();

        textNbTasks.text = GameSettings.numberOfTaskEvaluted.ToString();


    }

    public void openFileExplorer()
    {
        /**@brief Methode appele par le button pour Sauvergarder qui va declancher la creation et affichage de l'explorateur.
         */
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        /**@brief Methode de type coroutine qui prendre le chemin du repertoire choisi et va declencher la sérialisation  du JSON.
         */

        // Show a load file dialog and wait for a response from user
        // Load file/folder: file, Allow multiple selection: true
        // Initial path: default (Documents), Initial filename: empty
        // Title: "Load File", Submit button text: "Load"
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Folders, false, null, null, "Select Folder", "Save");


        // Print whether the user has selected some files or cancelled the operation (FileBrowser.Success)
        Debug.Log(FileBrowser.Success);

        if (FileBrowser.Success)
            OnFolderSelected(FileBrowser.Result); // FileBrowser.Result is null, if FileBrowser.Success is false
    }

    public void OnFolderSelected(string[] folderPath)
    {
        /**@param folderPath: le chemin du repertoire choisi.
         * 
         * @brief Méthode qui va serialiser le backlog en json et l'enregistrer dans un fichier json dans le repertoir choisi dans l'explorateur.
         * 
         * @var string json
         * @brief Contient l'information du fichier JSON.
         * 
         * @var string fileName
         * @brief nom du fichier JSON generee.
        **/


        jsonFolderPath = folderPath[0];
        string json = "{\r\n\t\"Backlog\":[\r\n";
        //1.create a new json file
        //2.Take Backlog
        //3.trasform into json format
        //4.write in file
        //5. save file


        //3.
        json = serialiazeBacklog(json);

        json += "\t]\r\n}";

        //Save file
        string fileName = "New_Backlog.json";
        jsonFolderPath += "\\" + fileName; 

        File.WriteAllText(jsonFolderPath, json);


        
        
    }

    private string serialiazeBacklog(string json)
    {
        ///@brief Fonction qui serialize le backlog
        int i = 0;
        
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



    public void pressNextTastk()
    {
        ///@brief Methode appele par le button next qui va afficher la tache suivante du backlog
        taskIndex++;

        if (taskIndex  == GameSettings.numberOfTaskEvaluted) {

            taskIndex = 0;
        }
       

        contenu[0].text = GameSettings.backlogList[taskIndex].Role;
        contenu[1].text = GameSettings.backlogList[taskIndex].Task;
        contenu[2].text = GameSettings.backlogList[taskIndex].Obj;
        contenuValue = GameSettings.backlogList[taskIndex].Value;

        findValueSprite();

    }


    private void findValueSprite()
    {
        ///@brief Methode pour chercher quelle image a afficher pour l'evaluation donnee
        int i = 0;

        if (int.TryParse(contenuValue, out int a))
        {
            i = a;

            switch (i) {
                case 5: 
                    i = 4;
                    break;

                case 8:
                    i = 5;
                    break;

                case 13:
                    i = 6;
                    break;

                case 20:
                    i = 7;
                    break;

                case 40:
                    i = 8;
                    break;

                case 100:
                    i = 9;
                    break;

            }

        }
        else
        {
            if(contenuValue == "?")
            {
                
               i = 10;
                 
            }

        }


        imageCard.sprite = cardImages[i];

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
