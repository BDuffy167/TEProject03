using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
namespace CapstoneTests
{
    [TestClass]
    public class CateringItemTest
    {
        [TestMethod]
        public void CateringItem_TypeBReturnsBeverage()
        {
            //Arrange
            CateringItem item = new CateringItem();
            item.Code = "B5";
            item.Name = "Jameson";
            item.Price = 30.00m;
            item.Type = "B";
            //Act
            string result = item.FullType;
            //Assert
            Assert.AreEqual("Beverage", result);
        }
        [TestMethod]
        public void CateringItem_TypeFReturnsEmpty()
        {
            //Arrange
            CateringItem item = new CateringItem();
            item.Code = "B5";
            item.Name = "Jameson";
            item.Price = 30.00m;
            item.Type = "F";
            //Act
            string result = item.FullType;
            //Assert
            Assert.AreEqual("", result);
        }

    }
    
}
