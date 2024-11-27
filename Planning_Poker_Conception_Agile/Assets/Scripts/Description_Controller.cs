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
                    "Le mode de jeu Strict est le mode de base pour l'estimation de la difficulté des tâches. Les parties se déroulent avec un nombre de manches illimité, et les joueurs votent jusqu'à ce que l'unanimité soit atteinte.\r\n \r\n" +
                    "À chaque tour, seuls les joueurs ayant attribué les valeurs les plus extrêmes(le plus haut et le plus bas) peuvent prendre la parole pour expliquer leur choix. Ces mêmes joueurs ont également accès à un Notepad dédié, où ils peuvent consigner des notes importantes pour aider à clarifier les décisions.\r\n \r\n" +
                    "Ce mode encourage une analyse approfondie et une convergence progressive vers un consensus partagé par tous.";
                break;
            case 1:
                descriptionText.text = "Bien y tu?";
                break;

        }
    }
    
}
