using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Telerik.JustMock;

namespace CarModsHeaven.Web.Tests.Controllers.Contact
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void ThrowWhenContactServiceIsNull()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ContactController(null));
        }

        [TestMethod]
        public void SetPassedDataCorrectlyWhenDataIsNotNull()
        {
            // Arrange
            var ContactServiceMock = Mock.Create<IContactService>();

            // Act
            var controller = new ContactController(ContactServiceMock);

            // Assert
            Assert.IsNotNull(controller);
        }
    }
}
