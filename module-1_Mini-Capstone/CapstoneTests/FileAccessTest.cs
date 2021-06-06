using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
namespace CapstoneTests
{
        [TestClass]
   public class FileAccessTest
    {
        [TestMethod]
        public void FileAccess_()
        {
            //Arrange
            Catering catering = new Catering();
            FileAccess fileAccess = new FileAccess(catering);
            
            //Act
            fileAccess.AuditBalance(5.00m, 5.00m);
            //Assert

            Assert.AreEqual(FileAccess.fileBalance,5.00m);
        }
    }
}
