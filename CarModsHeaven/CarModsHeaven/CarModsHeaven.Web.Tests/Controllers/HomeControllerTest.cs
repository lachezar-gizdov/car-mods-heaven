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
            var IProjectsServiceMock = Mock.Create<IProjectsService>();
            var IUsersServiceMock = Mock.Create<IUsersService>();
            HomeController controller = new HomeController(IProjectsServiceMock, IUsersServiceMock);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
