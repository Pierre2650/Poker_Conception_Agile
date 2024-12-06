using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_settings_NextButton_Controller : MonoBehaviour
{
    public GameObject next;
    private Button buttonNext;

    private void Start()
    {
        buttonNext = next.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( GameSettings.numberOfPlayers > 0 && GameSettings.numberOfTasks > 0)
        {
            buttonNext.interactable = true;
        }
        else
        {
            buttonNext.interactable= false;
        }

        
    }

    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }
}
