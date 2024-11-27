using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Ground_Singleton : MonoBehaviour
{
   
    /// @brief Fonction pour maintenir le Background Entre differentes Scenes
    public static Back_Ground_Singleton instance;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

}
