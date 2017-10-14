using CarModsHeaven.Services.Contracts;
using ContactUS.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Telerik.JustMock;
using TestStack.FluentMVCTesting;

namespace CarModsHeaven.Web.Tests.Controllers.About
{
    [TestClass]
    public class IndexShould
    {
        [TestMethod]
        public void IndexShouldReturnView()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var controller = new AboutController(projectsServiceMock, usersServiceMock);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CallProjectsServiceGetAllMethod()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var controller = new AboutController(projectsServiceMock, usersServiceMock);

            // Act
            controller.Index();

            // Arrange
            Mock.Assert(() => projectsServiceMock.GetAll(), Occurs.Once());
        }

        [TestMethod]
        public void CallUsersServiceGetAllMethod()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var controller = new AboutController(projectsServiceMock, usersServiceMock);

            // Act
            controller.Index();

            // Arrange
            Mock.Assert(() => usersServiceMock.GetAll(), Occurs.Once());
        }

        [TestMethod]
        public void RenderDefaultView()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var controller = new AboutController(projectsServiceMock, usersServiceMock);

            // Act
            controller.Index();

            // Assert
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
