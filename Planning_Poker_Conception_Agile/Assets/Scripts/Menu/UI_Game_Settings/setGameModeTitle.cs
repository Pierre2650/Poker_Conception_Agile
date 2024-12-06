using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class setGameModeTitle : MonoBehaviour
{
    public GameObject Title;
    private TMP_Text titleText;


    private void Awake()
    {
        titleText = Title.GetComponent<TMP_Text>();
        titleText.text = "Strict Mode";
    }

    private void OnEnable()
    {
        titleText.text = GameSettings.gameMode + " Mode";
        
    }
}
