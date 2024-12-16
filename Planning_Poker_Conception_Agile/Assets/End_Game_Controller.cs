using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End_Game_Controller : MonoBehaviour
{
    public GameObject[] userStory = new GameObject[3];
    private TMP_Text[] contenu = new TMP_Text[3];

    public GameObject nbCompletedtasks;
    private TMP_Text textNbCompleted;

    public GameObject nbIncompletedtasks;
    private TMP_Text textNbIncomplete;

    public GameObject noteCard;
    private Image sprite;

    public Sprite[] cardImages;


    // Start is called before the first frame update
    void Awake()
    {
        textNbCompleted = nbCompletedtasks.GetComponent<TMP_Text>();
        textNbIncomplete = nbIncompletedtasks.GetComponent<TMP_Text>();

        sprite = noteCard.GetComponent<Image>();


        int i = 0;
        foreach (GameObject obj in userStory)
        {

            contenu[i] = obj.GetComponent<TMP_Text>();
            i++;
        }

        foreach (Backlog_Information temp in GameSettings.backlogList)
        {
            if (temp.Value == "None")
            {
                contenu[0].text = temp.Role;
                contenu[1].text = temp.Task;
                contenu[2].text = temp.Obj;

                break;
            }
        }




    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void pressExitGame()
    {
        Application.Quit();

    }


    public void pressMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
