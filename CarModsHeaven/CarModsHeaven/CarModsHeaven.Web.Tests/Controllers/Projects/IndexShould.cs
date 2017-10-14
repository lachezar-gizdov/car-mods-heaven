using AutoMapper;
using CarModsHeaven.Auth.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Controllers;
using CarModsHeaven.Web.Models.ProjectsList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using TestStack.FluentMVCTesting;

namespace CarModsHeaven.Web.Tests.Controllers.Projects
{
    [TestClass]
    public class IndexShould
    {
        [TestInitialize]
        public void InitAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Project, ProjectAddViewModel>();
                cfg.CreateMap<ProjectAddViewModel, Project>();
                cfg.CreateMap<Project, ProjectDetailsViewModel>();
                cfg.CreateMap<ProjectDetailsViewModel, Project>();
            });
        }

        [TestMethod]
        public void RenderDefaultView()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var authMock = Mock.Create<IAuthProvider>();

            // Act
            var controller = new ProjectsController(projectsServiceMock, usersServiceMock, authMock);

            //Assert
            controller
                .WithCallTo(c => c.Index(null))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void CallProjectsServiceMethodGetAll()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var authMock = Mock.Create<IAuthProvider>();

            // Act
            var controller = new ProjectsController(projectsServiceMock, usersServiceMock, authMock);
            controller.Index(null);

            // Assert
            Mock.Assert(() => projectsServiceMock.GetAll(), Occurs.Once());
        }
    }
}
