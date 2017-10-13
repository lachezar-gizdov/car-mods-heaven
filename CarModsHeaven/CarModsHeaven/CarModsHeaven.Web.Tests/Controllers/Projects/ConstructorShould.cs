using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Telerik.JustMock;

namespace CarModsHeaven.Web.Tests.Controllers.Projects
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void ThrowWhenProjectsServiceIsNull()
        {
            // Arrange
            var usersServiceMock = Mock.Create<IUsersService>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ProjectsController(null, usersServiceMock));
        }

        [TestMethod]
        public void ThrowWhenUsersServiceIsNull()
        {
            // Arrange
            var projectssServiceMock = Mock.Create<IProjectsService>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ProjectsController(projectssServiceMock, null));
        }

        [TestMethod]
        public void SetPassedDataCorrectlyWhenDataIsNotNull()
        {
            // Arrange
            var projectssServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();

            // Act
            var controller = new ProjectsController(projectssServiceMock, usersServiceMock);

            // Assert
            Assert.IsNotNull(controller);
        }
    }
}
