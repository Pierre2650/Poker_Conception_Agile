using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/**@file
*@brief Class Description: Script Qui est chargee de la gestion de l'interface Resultat
*/
public class Results_Controller : MonoBehaviour
{
    /**
    * @class Results_Controller
    * @brief Controleur responsable de la gestion et affichage des  resultats apres les votes.
    * 
    * @var Vote_Controller Vote_Scrpt
    * @brief Script controleur des votes, permettant d'acceder aux resultats des votes.
    * 
    * @var Game_Controller Game_Scrpt
    * @brief Script de controleur du jeu.
    * 
    * @var List<GameObject> players_results
    * @brief Liste des objets representant les resultats des joueurs.
    * 
    * @var int[] evaluations
    * @brief Tableau contenant les evaluations numeriques des resultats des joueurs.
    * 
    * @var List<string> maxDebateSide
    * @brief Liste des noms des joueurs du cote ayant la valeur maximale lors du debat.
    * 
    * @var List<string> minDebateSide
    * @brief Liste des noms des joueurs du cote ayant la valeur minimale lors du debat.
    * 
    * @var bool unanimity
    * @brief Indicateur de si tous les joueurs ont vote pour la meme valeur.
    * 
    * @var string undisputedValue
    * @brief Valeur non disputee choisie par l'unanimite.
    * 
    * @var int min
    * @brief Indice ou valeur minimale des resultats des joueurs.
    * 
    * @var int max
    * @brief Indice ou valeur maximale des resultats des joueurs.
    */

    public Vote_Controller Vote_Scrpt;
    public Game_Controller Game_Scrpt;
    
    public List<GameObject> players_results;

    public int[] evaluations ;

    public List<string> maxDebateSide = new List<string>();
    public List<string> minDebateSide = new List<string>();

    public bool unanimity = true;
    public string undisputedValue = "?";

    int min, max;


    private void Awake()
    {
       evaluations =  new int[GameSettings.numberOfPlayers];
    }


    private void OnEnable()
    {
        /**
         * @brief Methode executee lorsque le script est active.
         * Initialise les actions necessaires a la mise a jour des resultats.
         */
        doActions();
    }

    public void doActions()
    {
        /**
         * @brief Effectue les actions principales pour mettre a jour les resultats.
         * Reinitialise les marques, convertit les valeurs des votes en entiers,
         * verifie l'unanimite et, si necessaire, trouve et selectionne les valeurs extremes.
         */

        resetMarksFirstName();

        valuesToINT();
        unanimity = checkUnanimity();

        if (!unanimity)
        {
            findExtremes();
            chooseExtremes();
        }
       

    }

    public void resetMarksFirstName()
    {
        /**
         * @brief Reinitialise les marques et noms associes aux resultats des joueurs. Les marques etant le yin (Valeur Max) er le yang (Valeur Min)
         * Cache les marques maximales et minimales pour une mise a jour future.
         */

        GameObject fatherName = players_results[0].transform.GetChild(3).gameObject;
        GameObject childName = fatherName.transform.GetChild(1).gameObject;

        TMP_Text childNameText = childName.GetComponent<TMP_Text>();

        GameObject maxMark = players_results[0].transform.GetChild(0).gameObject;
        GameObject minMark = players_results[0].transform.GetChild(1).gameObject;


        maxMark.SetActive(false);
        minMark.SetActive(false);

    }


    private void valuesToINT()
    {
        /**
         * @brief Convertit les valeurs des votes en entiers et les stocke dans le tableau `evaluations`.
         * Traite egalement les valeurs speciales comme "?" et "Coffee".
         */
        int i = 0;

        foreach (var ex in Vote_Scrpt.results)
        {


            if (int.TryParse(ex.Value, out int a))
            {
                
                evaluations[i] = a;

            }
            else
            {
                switch (ex.Value)
                {
                    case "?":
                        evaluations[i] = -1;
                        break;
                    case "Coffee":
                        evaluations[i] = -2;
                        break;
                }


            }

            i++;
        }

    }

    private bool checkUnanimity()
    {
        /**
         * @brief Verifie si tous les votes sont unanimes.
         * @return True si tous les joueurs ont vote pour la meme valeur, sinon False.
         */
        int precedent = evaluations[0];
        int i;

        for ( i = 1; i < evaluations.Length; i++)
        {
            if (precedent != evaluations[i])
            {
                return false;
            }

            precedent = evaluations[i];
        }

        i--;

        if(evaluations[i] == -1)
        {
            undisputedValue = "?";

        }else if (evaluations[i] == -2)
        {
            undisputedValue= "Coffee";
        }
        else
        {
            undisputedValue = evaluations[i].ToString();
        }
        
        return true;
    }

    public int findAverage(int[] eval)
    {

        /**
         * @brief Calcule la moyenne des évaluations et trouve la valeur possible la plus proche de cette moyenne.
         * @param eval Tableau des évaluations.
         * @return La valeur la plus proche de la moyenne parmi les valeurs possibles.
         */

        float moyenne = 0;

        for (int i = 0; i < eval.Length; i++)
        {
            moyenne += eval[i];
        }

        moyenne = moyenne/ eval.Length;


        return findClosestPossibleValue(moyenne);

    }

    private int findClosestPossibleValue(float moyenne)
    {
        /**
         * @brief Trouve la valeur possible la plus proche d'une moyenne donnée.
         * @param moyenne La moyenne calculée.
         * @return La valeur possible la plus proche sous forme d'entier.
         */

        float[] possibleValues = { -1, 0, 1, 2, 3, 5, 8, 13, 20, 40, 100 };

        float res = possibleValues[0];

        for (int i = 1; i < possibleValues.Length; i++) {
            if (Mathf.Abs(possibleValues[i] - moyenne) < Mathf.Abs(res - moyenne)){ 

                res = possibleValues[i];
            }
        }

        return (int)res;



    }
    private void findExtremes()
    {
        /**
         * @brief Identifie les valeurs extrêmes (minimale et maximale) parmi les évaluations.
         * Ignore les valeurs spéciales telles que "?" et "Coffee" dans un premier temp
         * Ensuite si il y en a que 1 valeur numerique et que des valeur especial ( ? ou Coffee) prend un des 2 valeur especial comme la valeur minimale (Coffee <  ?)
         */

        min = 9999;
        max = 0;

        for(int i = 0; i < evaluations.Length; i++)
        {
            if (evaluations[i] < 0)
            {
                continue;
            }


            if(evaluations[i] < min)
            {
               
                min = evaluations[i];
            }

            if(evaluations[i] > max)
            {
               
                max = evaluations[i];
            }
        }

        Debug.Log("Min = " + min + "  Max = " + max);

        if (min == max)
        {
            noMinimum();
            
        }

        if(max == 0 &&  min == 9999)
        {
            max = -1;
            min = -2;

        }

    }

    private void noMinimum()
    {
        int countCoffee, countInterro;
        countCoffee = countInterro = 0;
        //problem , just 1 numeric value,  others euther coffee or ?

        for (int i = 0; i < evaluations.Length; i++)
        {

            if (evaluations[i] == -1)
            {
                countInterro++;
            }

            if (evaluations[i] == -2)
            {
                countCoffee++;
            }


        }

        if (countCoffee > countInterro)
        {
            min = -2;
        }
        else
        {
            min = -1;
        }

    }

    private void chooseExtremes()
    {
        /**
         * @brief Sélectionne les joueurs associés aux valeurs minimales et maximales, et active les marques correspondantes.
         */
    
        string minValue;
        string maxValue;


        if(min == -1)
        {
            minValue = "?";

        }else if(min == -2)
        {
            minValue = "Coffee";
        }
        else
        {
            minValue = min.ToString();
        }

        if (max == -1)
        {
            maxValue = "?";

        }
        else
        {
            maxValue = max.ToString();
        }




        foreach (GameObject temp in players_results)
        {
            GameObject fatherName = temp.transform.GetChild(3).gameObject;
            GameObject childName = fatherName.transform.GetChild(1).gameObject;

            TMP_Text childNameText = childName.GetComponent<TMP_Text>();

            GameObject maxMark = temp.transform.GetChild(0).gameObject;
            GameObject minMark = temp.transform.GetChild(1).gameObject;


            if (Vote_Scrpt.results[childNameText.text] == maxValue)
            {
                
                maxMark.SetActive(true);
                minMark.SetActive(false);

                maxDebateSide.Add(childNameText.text);
            }
            


            if (Vote_Scrpt.results[childNameText.text] == minValue)
            {
                maxMark.SetActive(false);
                minMark.SetActive(true);

                minDebateSide.Add(childNameText.text);
            }
          



        }

    }

    public void restart()
    {
        /**
         * @brief Réinitialise les données liées au débat et détruit les objets de résultats
         */

        maxDebateSide.Clear();
        minDebateSide.Clear();

        for (int i = 1; i < players_results.Count; i++)
        {
            Destroy(players_results[i]);
        }
    }

   

  
}
