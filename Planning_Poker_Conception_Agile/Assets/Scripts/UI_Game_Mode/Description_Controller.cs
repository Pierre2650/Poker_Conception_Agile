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
                    "-Le mode de jeu 'Strict' est le mode de base pour l'estimation de la difficult� des t�ches. Les parties se d�roulent avec un nombre de manches illimit�, et les joueurs votent jusqu'� ce que l'unanimit� soit atteinte.\r\n \r\n" +
                    "-� chaque tour, seuls les joueurs ayant attribu� les valeurs les plus extr�mes(le plus haut et le plus bas) peuvent prendre la parole pour expliquer leur choix. Ces m�mes joueurs ont �galement acc�s � un Notepad d�di�, o� ils peuvent consigner des notes importantes pour aider � clarifier les d�cisions.\r\n \r\n" +
                    "Ce mode encourage une analyse approfondie et une convergence progressive vers un consensus partag� par tous.";
                break;
            case 1:

                GameSettings.GameMode = "Average";

                descriptionText.text = "Regles :\r\n" +
                    "-Le mode 'Moyenne' propose une approche en deux manches pour estimer la difficult� des t�ches.\r\n \r\n" +
                    "Premi�re manche : Unanimit�\r\n" +
                    "-Le premier tour suit les r�gles du mode 'Strict': les joueurs votent pour atteindre une unanimit�. Si l'unanimit� n'est pas atteinte, seuls les joueurs ayant attribu� les valeurs les plus extr�mes (le plus haut et le plus bas) peuvent prendre la parole pour expliquer leur position.\r\n" +
                    "Un Notepad est disponible pour consigner des notes importantes, accessibles uniquement aux joueurs extr�mes.\r\n \r\n" +
                    "Deuxi�me manche : Moyenne\r\n" +
                    "-Lors du second tour, les joueurs revotent. Le niveau de difficult� retenu est celui avec la moyenne la plus haute parmi les votes exprim�s. \r\n \r\n"+
                    "Ce mode favorise un �quilibre entre la recherche de consensus initial et une prise de d�cision pragmatique bas�e sur une moyenne finale.";
                break;

        }
    }
    
}
