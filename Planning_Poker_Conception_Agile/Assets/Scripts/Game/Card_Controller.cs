using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Controller : MonoBehaviour
{
    public string value;

    private bool onObject = false;
    static bool bugPrevention = false;

    public Vote_Controller vote_scrpt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && onObject && !bugPrevention) {
            Debug.Log("Card Was clicked");
         

            vote_scrpt.choiceMade(value);

        }
        
    }

    void OnMouseOver()
    {
        onObject = true;
    }

    void OnMouseExit()
    {
        onObject = false;
    }

    private void OnDisable()
    {
        onObject = false;
    }
}
