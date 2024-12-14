using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_sceneChange : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
           SceneManager.LoadScene("Game"); 

        }


        if (Input.GetKeyDown(KeyCode.O))
        {
            //Debug.Log("DEBATE -> Minutes: "+GameSettings.debateTimer[0]+ "  Seconds: " + GameSettings.debateTimer[1]);


        }


    }
}
