using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;
using TestStack.FluentMVCTesting;

namespace CarModsHeaven.Web.Tests.Controllers.Projects
{
    [TestClass]
    public class EditProjectShould
    {
        [TestMethod]
        public void ReturnDefaultView()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var controller = new ProjectsController(projectsServiceMock, usersServiceMock);

            // Act
            controller.EditProject("test");

            // Assert
            controller
                .WithCallTo(c => c.EditProject("test"))
                .ShouldRenderDefaultView();
        }

        //[TestMethod]
        //public void ReturnErrorViewWhenPassedTitleIsNull()
        //{
        //    // Arrange
        //    var projectsServiceMock = Mock.Create<IProjectsService>();
        //    var usersServiceMock = Mock.Create<IUsersService>();
        //    var controller = new ProjectsController(projectsServiceMock, usersServiceMock);

        //    // Act
        //    controller.EditProject(null);

        //    // Assert
        //    controller
        //        .WithCallTo(c => c.EditProject("test"))
        //        .ShouldRenderDefaultView();
        //}
    }
}
