using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Result_Controller_FindAverage_Test

{
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScript1SimplePasses()
    {
        //Arrange
        UnitTest_Sum A = new UnitTest_Sum();
        Results_Controller toTest = new Results_Controller();

        //Act
        int[] arrayTest = {1,2,2,2,3,4,5,6};
        int avg = toTest.findAverage(arrayTest);


        //Assert
        Assert.AreEqual(3, avg, "Find Average Doesn't Work Correctly ");

    }

}
