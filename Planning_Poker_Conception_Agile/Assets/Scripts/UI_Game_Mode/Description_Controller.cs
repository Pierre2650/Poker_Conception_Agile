using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework.Internal;
using NUnit.Framework;

/**@file
*@brief Class Description: Script Manipulation du champ de description 
*/

public class Description_Controller : MonoBehaviour
{

    public GameObject descriptionField;
    private TMP_Text descriptionText;
    private void Start()
    {
        descriptionText = descriptionField.GetComponent<TMP_Text>();

    }
    

    public void selection(int index)
    {

        switch (index)
        {
            case 0:
                 
                GameSettings.GameMode = "Strict";

                descriptionText.text = "Regles :\r\n" +
                    "-Le mode de jeu 'Strict' est le mode de base pour l'estimation de la difficulté des tâches. Les parties se déroulent avec un nombre de manches illimité, et les joueurs votent jusqu'à ce que l'unanimité soit atteinte.\r\n \r\n" +
                    "-À chaque tour, seuls les joueurs ayant attribué les valeurs les plus extrêmes(le plus haut et le plus bas) peuvent prendre la parole pour expliquer leur choix. Ces mêmes joueurs ont également accès à un Notepad dédié, où ils peuvent consigner des notes importantes pour aider à clarifier les décisions.\r\n \r\n" +
                    "Ce mode encourage une analyse approfondie et une convergence progressive vers un consensus partagé par tous.";
                break;
            case 1:

                GameSettings.GameMode = "Average";

                descriptionText.text = "Regles :\r\n" +
                    "-Le mode 'Moyenne' propose une approche en deux manches pour estimer la difficulté des tâches.\r\n \r\n" +
                    "Première manche : Unanimité\r\n" +
                    "-Le premier tour suit les règles du mode 'Strict': les joueurs votent pour atteindre une unanimité. Si l'unanimité n'est pas atteinte, seuls les joueurs ayant attribué les valeurs les plus extrêmes (le plus haut et le plus bas) peuvent prendre la parole pour expliquer leur position.\r\n" +
                    "Un Notepad est disponible pour consigner des notes importantes, accessibles uniquement aux joueurs extrêmes.\r\n \r\n" +
                    "Deuxième manche : Moyenne\r\n" +
                    "-Lors du second tour, les joueurs revotent. Le niveau de difficulté retenu est celui avec la moyenne la plus haute parmi les votes exprimés. \r\n \r\n"+
                    "Ce mode favorise un équilibre entre la recherche de consensus initial et une prise de décision pragmatique basée sur une moyenne finale.";
                break;

        }
    }
    
}
