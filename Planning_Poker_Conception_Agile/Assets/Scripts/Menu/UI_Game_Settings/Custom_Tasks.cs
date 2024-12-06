using Codice.Client.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Tasks : MonoBehaviour
{
    public GameObject customTWindow;

    private bool on = false;
    
    public void newCustomTask()
    {
        on = !on;

        if (on)
        {
            customTWindow.SetActive(true);

        }
        else
        {
            customTWindow.SetActive(false);
        }
        
    }

}
