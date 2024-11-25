using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UnitTest_Sum_Test
{
    // A Test behaves as an ordinary method
    [Test]
    public void UnitTest_Sum_TestSimplePasses()
    {
        //Arrange
        UnitTest_Sum A = new UnitTest_Sum();

        //Act
        int sum = A.add(5, 5);

        //Assert
        Assert.AreEqual(10, sum, "Test Not working ");

        // Use the Assert class to test conditions

    }

}
