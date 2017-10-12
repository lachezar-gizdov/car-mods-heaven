using System.Web.Mvc;
using CarModsHeaven.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using CarModsHeaven.Services.Contracts;

namespace CarModsHeaven.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
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
