using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/**@file
*@brief Class Description: Script Qui Teste Unitaire en Editmode
*/
public class Result_Controller_FindAverage_Test
{
    /**
     * @class Result_Controller_FindAverage_Test
     * @brief Cette classe implémente un test unitaire pour la méthode findAverage de la classe Results_Controller.
     * 
     * Ce test suit la structure AAA (Arrange, Act, Assert) pour valider que la méthode findAverage retourne la moyenne
     * correcte parmi les valeurs possibles spécifiées.
     * 
     */

   

    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScript1SimplePasses()
    {
        /**@brief Utilisiation de la structure AAA
        * 
        * Ce test suit les étapes suivantes :
        *  - **Arrange** : Prépare l'environnement de test en instanciant un objet Results_Controller et initialisant un tableau de test.
        *  - **Act** : Exécute la méthode findAverage avec le tableau de test.
        *  - **Assert** : Vérifie que le résultat retourné par la méthode correspond à la valeur attendue.
        * 
        * Le tableau utilisé contient des valeurs mixtes, et la valeur moyenne attendue parmi les valeurs possibles est 3.
        */

        //Arrange
        Results_Controller toTest = new Results_Controller();

        //Act
        int[] arrayTest = {1,2,2,2,3,4,5,6};
        int avg = toTest.findAverage(arrayTest);


        //Assert
        Assert.AreEqual(3, avg, "Find Average Doesn't Work Correctly ");

    }

}
