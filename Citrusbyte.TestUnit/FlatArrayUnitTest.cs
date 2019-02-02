using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CitrusByte.Computation;

namespace Citrusbyte.TestUnit
{
    [TestClass]
    public class FlatArrayUnitTest
    {
        
        [TestMethod]
        public void Nested_Array_Empty_Without_Split_Character()
        {
            // Arrange
            FlatArray flatArray = new FlatArray();
            
            // Act
            flatArray.BuildTheFlatArray("");

            // Assert

            Assert.AreEqual(0, flatArray.ConvertStringArrayToIntegerArray().Length);
        }

        [TestMethod]
        public void Nested_Array_Null_Without_Split_Character()
        {
            // Arrange
            FlatArray flatArray = new FlatArray();

            // Act
            flatArray.BuildTheFlatArray(null);

            // Assert

            Assert.AreEqual(0, flatArray.ConvertStringArrayToIntegerArray().Length);
        }

        [TestMethod]
        public void Nested_Array_Empty_With_blank_Split_Character()
        {
            // Arrange
            FlatArray flatArray = new FlatArray();

            char empty = ' ';
            // Act
            flatArray.BuildTheFlatArray("", empty);

            // Assert

            Assert.AreEqual(0, flatArray.ConvertStringArrayToIntegerArray().Length);
        }

        [TestMethod]
        public void Nested_Array_Empty_With_Null_Split_Character()
        {
            // Arrange
            FlatArray flatArray = new FlatArray();

            char empty = '\0';
            // Act
            flatArray.BuildTheFlatArray("", empty);

            // Assert

            Assert.AreEqual(0, flatArray.ConvertStringArrayToIntegerArray().Length);
        }

        [TestMethod]
        public void Nested_Array_Check_if_Empty_true()
        {
            // Arrange
            FlatArray flatArray = new FlatArray();

            char comma = ',';
            // Act
            flatArray.BuildTheFlatArray("", comma);

            // Assert

            Assert.AreEqual(true, flatArray.IsFlatArrayEmpty());
        }

        [TestMethod]
        public void Nested_Array_Check_if_Empty_false()
        {
            // Arrange
            FlatArray flatArray = new FlatArray();

            char comma = ',';
            // Act
            flatArray.BuildTheFlatArray("[1, 2,[3]],4]", comma);

            // Assert

            Assert.AreEqual(false, flatArray.IsFlatArrayEmpty());
        }

        [TestMethod]
        public void Nested_Array_Without_Intergers()
        {
            // Arrange
            FlatArray flatArray = new FlatArray();

            char comma = ',';
            // Act
            flatArray.BuildTheFlatArray("[A, D,[B]],C]", comma);

            // Assert

            Assert.AreEqual(true, flatArray.IsFlatArrayEmpty());
        }

        [TestMethod]
        public void Nested_Array_With_Expected_Output()
        {
            // Arrange
            FlatArray flatArray = new FlatArray();
            int[] expectedArray = new int[] {1,2,3,4};
            
            // Act
            flatArray.BuildTheFlatArray("[[1, 2,[3]],4]", ',');

            // Assert

            CollectionAssert.AreEqual(expectedArray, flatArray.ConvertStringArrayToIntegerArray());
        }
    }
}
