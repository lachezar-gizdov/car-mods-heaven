using CarModsHeaven.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace CarModsHeaven.Web.Tests.Controllers.Account
{
    [TestClass]
    public class LoginShould
    {
        [TestMethod]
        public void LoginShould_ReturnView()
        {
            // Arrange
            var controller = new AccountController();

            // Act
            ViewResult result = controller.Login("/") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
