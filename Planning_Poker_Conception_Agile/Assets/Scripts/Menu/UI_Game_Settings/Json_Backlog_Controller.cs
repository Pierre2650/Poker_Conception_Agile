using SimpleFileBrowser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui va permetre de charger un fichier JSON avec un Backlog avec des taches a valider et taches deja validee.
*/

public class Json_Backlog_Controller : MonoBehaviour
{
    /**@class Json_Backlog_Controller.
   * @brief Controlleur qui va permetre de ajouter backlog rempli de taches a valider et taches deja validee .
   * Attention, ce contrôleur implémente un plugin pour la génération d’un explorateur de fichiers, car Unity n’en a pas d’intégré.
   * 
   * @var GameObject exception 
   * @brief Variable qui va contenir le GameObject du champ de texte qui decrit une excepetion.
   
   * @var TMP_Text textException
   * @brief Variable qui  contient la composante texte du GameObject exception.
   * 
   * @var string jsonPath
   * @brief Variable qui contient le chemin du fichier Json.
   * 
   */
    public GameObject exceptions;
    private TMP_Text textException;
   
    
    private string jsonPath;


    public class Deserializer
    {
        /**@class Deserializer.
        * @brief SubClass qui va servir comme un conteneur pour recueillir l'information du JSON.
        * 
        * @var List<Backlog_Information> Backlo
        * @brief Liste de Backlog_Information Classe charge de variables pour la description d'une tache
        */

        public List<Backlog_Information> Backlog;
    }

    private void Start()
    {
        /**@brief Remplissage des variables grace a ces GameObject correspondants  quand l'objet est cree et parametrage du Explorateur de fichier.
         */
        textException = exceptions.GetComponent<TMP_Text>();


        // Set filters (optional)
        // It is sufficient to set the filters just once (instead of each time before showing the file browser dialog), 
        // if all the dialogs will be using the same filters
        FileBrowser.SetFilters(true, new FileBrowser.Filter("JSON Files", ".json"));

        // Set default filter that is selected when the dialog is shown (optional)
        // Returns true if the default filter is set successfully
        // In this case, set Images filter as the default filter
        FileBrowser.SetDefaultFilter(".json");


    }

    public void openFileExplorer()
    {
        /**@brief Methode appele par le button "Import backlog" qui va declancher la creation et affichage de l'explorateur.
         */
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        /**@brief Methode de type coroutine qui va  prendre le chemin du fichier choisi et va declencher la désérialisation  du JSON.
         */

        // Show a load file dialog and wait for a response from user
        // Load file/folder: file, Allow multiple selection: true
        // Initial path: default (Documents), Initial filename: empty
        // Title: "Load File", Submit button text: "Load"
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, null, null, "Select File", "Load");


        // Print whether the user has selected some files or cancelled the operation (FileBrowser.Success)
        Debug.Log(FileBrowser.Success);

        if (FileBrowser.Success)
            OnFilesSelected(FileBrowser.Result); // FileBrowser.Result is null, if FileBrowser.Success is false
    }

    public void OnFilesSelected(string[] filePaths)
    {
        /**@param filePaths: le chemin du fichier choisi.
         * 
         * @brief Méthode qui va vérifier si le fichier choisi est bien un JSON. Ensuite, elle lira son contenu dans la variable info, qui sera utilisée par une fonction d’une classe interne proposée par Unity pour désérialiser les fichiers JSON.
         * Ainsi, les informations désérialisées seront placées dans la variable temp, qui est un objet de type Deserializer. La méthode vérifiera si le backlog contenu dans temp respecte les conditions d’ajout 
         * (à savoir qu’il y ait un maximum de 15 tâches globalement et au moins une tâche validable). Sinon, elle affichera l’exception correspondante.
         * Enfin, si le JSON est valide, elle ajoutera les tâches dans la classe statique GameSettings.
         * 
         * @var string info
         * @brief Contient l'information du fichier JSON.
         * 
         * @var Deserializer temp
         * @brief Objet pour  recueillir l'information désérialisées du JSON.
        **/

        jsonPath = filePaths[0];

        if (Path.GetExtension(jsonPath) == ".json")
        {

            // Read File.
            string info;
            info = File.ReadAllText(jsonPath);



          
            //Deserialize
            Deserializer temp = JsonUtility.FromJson<Deserializer>(info);

            if (temp.Backlog.Count > 15)
            {
                showException(1);
            }
            else if (GameSettings.numberOfTasksToEvalute + temp.Backlog.Count > 15)
            {
                showException(3);
            }
            else
            {

                foreach (Backlog_Information x in temp.Backlog) { 
                    GameSettings.backlogList.Add(x);
                }

                
                GameSettings.countTasks();
                GameSettings.numberOfTasksToEvalute = GameSettings.backlogList.Count - GameSettings.numberOfTaskEvaluted;

                if(GameSettings.numberOfTasksToEvalute == 0)
                {
                    GameSettings.backlogList.Clear();
                    showException(4);

                }
                else
                {
                    showException(0);

                }

                


            }


        }
        else
        {
            showException(2);
        }
    }

    private void showException(int x)
    {
        ///@brief Methode charge de remplisage de text et affichage  des differentes exception possibles lies a l'addition de la nouvelle tache.

        switch (x) { 
            case 0:

                exceptions.SetActive(false);

                break;

            case 1:
     
                textException.text = "*NB of Tasks > 15 \r\n" +
                                    "Max Number of task reached";
                exceptions.SetActive(true);

                break;

            case 2:
                textException.text = "*Selected File is not a JSON";

                exceptions.SetActive(true);
                break;

            case 3:
                textException.text = "*Adding the JSON would surpass Max Number of tasks";

                exceptions.SetActive(true);

                break;

            case 4:

                textException.text = "*All tasks in the JSON Already Evaluated";

                exceptions.SetActive(true);
                break;


        }

    }


   

}
