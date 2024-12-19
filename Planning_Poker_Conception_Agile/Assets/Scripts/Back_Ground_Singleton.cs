using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**@file
*@brief Class Description: Script Qui va permetre mantenir le background entre differentes Scenes.
*/
public class Back_Ground_Singleton : MonoBehaviour
{
    /**@class Back_Ground_Singleton.
    * @brief ette classe garantit qu'il n'existe qu'une seule instance de l'objet de fond dans la scène, 
    * Le background  persiste entre les différentes scènes grâce à la methode `DontDestroyOnLoad`.
    * 
    * @var Back_Ground_Singleton instance
    * @brief Instance unique du singleton de la classe Back_Ground_Singleton.
    * 
    */
    public static Back_Ground_Singleton instance;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

}
