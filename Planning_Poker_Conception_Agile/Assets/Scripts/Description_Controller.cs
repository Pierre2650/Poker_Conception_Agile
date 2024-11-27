using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework.Internal;
using NUnit.Framework;

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
                descriptionText.text = "Mode de jeu :\r\n" +
                    "Le mode de jeu Strict est le mode de base pour l'estimation de la difficult� des t�ches. Les parties se d�roulent avec un nombre de manches illimit�, et les joueurs votent jusqu'� ce que l'unanimit� soit atteinte.\r\n \r\n" +
                    "� chaque tour, seuls les joueurs ayant attribu� les valeurs les plus extr�mes(le plus haut et le plus bas) peuvent prendre la parole pour expliquer leur choix. Ces m�mes joueurs ont �galement acc�s � un Notepad d�di�, o� ils peuvent consigner des notes importantes pour aider � clarifier les d�cisions.\r\n \r\n" +
                    "Ce mode encourage une analyse approfondie et une convergence progressive vers un consensus partag� par tous.";
                break;
            case 1:
                descriptionText.text = "Bien y tu?";
                break;

        }
    }
    
}
