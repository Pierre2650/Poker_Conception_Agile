using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Current_NB_Tasks : MonoBehaviour
{
    public GameObject nbText;
    private TMP_Text n;

    private void Start()
    {
        n = nbText.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        n.text = GameSettings.numberOfTasks.ToString();
        
    }
}
