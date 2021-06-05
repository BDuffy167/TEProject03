using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace CapstoneTests
{
    [TestClass]
    public class CateringTest
    {
        [TestMethod]
        public void CateringInstanceShouldBeCreated()
        {
            // Arrange 
            Catering catering = new Catering();

            // Act

            // Assert
            Assert.IsNotNull(catering);
        }
        [TestMethod]
        public void CateringTest_IndexZeroReturnsCode()
        {
            // Arrange 
            Catering catering = new Catering();

            // Act
            catering.AddItem("A5|Spaghetti|70.20|A");
            // Assert
            Assert.AreEqual("A5",catering.FullList[0].Code);
        }
        [TestMethod]
        public void CateringInstanceShouldBeCreate()
        {
            // Arrange 
            Catering catering = new Catering();

            // Act

            // Assert
            Assert.IsNotNull(catering);
        }
    }
}
