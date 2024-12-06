using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Backlog_Transfer_test : MonoBehaviour
{
    public GameObject Text;
    private TMP_Text message;

    private void Awake()
    {
        message = Text.GetComponent<TMP_Text>();

    }
    

    private void OnEnable()
    {
        message.text = GameSettings.backlogList[0].Role +" "+ GameSettings.backlogList[0].Task + " " + GameSettings.backlogList[0].Obj;
        
    }

}
