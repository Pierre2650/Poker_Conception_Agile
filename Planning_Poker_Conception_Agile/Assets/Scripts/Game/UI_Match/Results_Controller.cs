using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Results_Controller : MonoBehaviour
{
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
        doActions();
    }

    public void doActions()
    {
        resetMarksFirstName();

        valuesToINT();
        unanimity = checkUnanimity();

        if (!unanimity)
        {
            findExtremes();
            chooseExtremes();
        }
       

    }

    private void resetMarksFirstName()
    {
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

        if (min == max)
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

    }

    private void chooseExtremes()
    {
        //verifie value of min
        string minValue;

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



        foreach (GameObject temp in players_results)
        {
            GameObject fatherName = temp.transform.GetChild(3).gameObject;
            GameObject childName = fatherName.transform.GetChild(1).gameObject;

            TMP_Text childNameText = childName.GetComponent<TMP_Text>();

            GameObject maxMark = temp.transform.GetChild(0).gameObject;
            GameObject minMark = temp.transform.GetChild(1).gameObject;


            if (Vote_Scrpt.results[childNameText.text] == max.ToString())
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
        maxDebateSide.Clear();
        minDebateSide.Clear();

        for (int i = 1; i < players_results.Count; i++)
        {
            Destroy(players_results[i]);
        }
    }

   

  
}
