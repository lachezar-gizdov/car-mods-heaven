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
            var IProjectsServiceMock = Mock.Create<IProjectsService>();
            var IUsersServiceMock = Mock.Create<IUsersService>();
            HomeController controller = new HomeController(IProjectsServiceMock, IUsersServiceMock);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ThrowWhenProjectsServiceIsNull()
        {
            // Arrange
            var usersServiceMock = Mock.Create<IUsersService>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new HomeController(null, usersServiceMock));
        }

        [TestMethod]
        public void ThrowWhenUsersServiceIsNull()
        {
            // Arrange
            var projectssServiceMock = Mock.Create<IProjectsService>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new HomeController(projectssServiceMock, null));
        }
    }
}
