using System.Web.Mvc;
using CarModsHeaven.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using CarModsHeaven.Services.Contracts;
using System;

namespace CarModsHeaven.Web.Tests.Controllers.Home
{
    [TestClass]
    public class HomeControllerShould
    {
        [TestMethod]
        public void IndexShouldReturnView()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
