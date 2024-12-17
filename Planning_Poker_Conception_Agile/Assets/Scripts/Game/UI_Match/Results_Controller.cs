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

    private int[] evaluations = new int[GameSettings.numberOfPlayers];

    public List<string> maxDebateSide = new List<string>();
    public List<string> minDebateSide = new List<string>();

    public bool unanimity = true;
    public string undisputedValue = "?";

    int min, max;

    

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
    private void findExtremes()
    {
       
        
        min = max = evaluations[0];

        for(int i = 1; i < evaluations.Length; i++)
        {
            //Verifie this later for everyone chose coffe
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

    }

    private void chooseExtremes()
    {
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
            


            if (Vote_Scrpt.results[childNameText.text] == min.ToString())
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
