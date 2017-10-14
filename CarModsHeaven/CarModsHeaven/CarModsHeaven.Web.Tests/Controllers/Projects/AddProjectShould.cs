using AutoMapper;
using CarModsHeaven.Auth.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Controllers;
using CarModsHeaven.Web.Models.ProjectsList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock;
using TestStack.FluentMVCTesting;

namespace CarModsHeaven.Web.Tests.Controllers.Projects
{
    [TestClass]
    public class AddProjectShould
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
        public void ReturnDefaultView()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var authMock = Mock.Create<IAuthProvider>();
            var controller = new ProjectsController(projectsServiceMock, usersServiceMock, authMock);

            // Act
            controller.AddProject();

            // Assert
            controller
                .WithCallTo(c => c.AddProject())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void ReturnSameViewIfModelIsNotValid()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var authMock = Mock.Create<IAuthProvider>();
            var controller = new ProjectsController(projectsServiceMock, usersServiceMock, authMock);
            var model = new ProjectAddViewModel();

            // Act
            controller.ModelState.AddModelError("key", "error");

            // Assert
            controller
                .WithCallTo(c => c.AddProject(model))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void ReturnDetailsViewIfModelIsValid()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var authMock = Mock.Create<IAuthProvider>();
            var projectId = Guid.NewGuid();
            var project = new Project
            {
                Id = projectId
            };

            var controller = new ProjectsController(projectsServiceMock, usersServiceMock, authMock);
            var list = new List<Project>() { project };
            Mock.Arrange(() => projectsServiceMock.GetById(projectId)).Returns(list.AsQueryable());

            // Act
            controller.Details(projectId);

            //Assert
            controller
                .WithCallTo(c => c.Details(projectId))
                .ShouldRenderView("Details");
        }

        [TestMethod]
        public void CallProjectsServiceMethodAddWhenModelIsValid()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var authMock = Mock.Create<IAuthProvider>();

            var controller = new ProjectsController(projectsServiceMock, usersServiceMock, authMock);
            var userId = Guid.NewGuid().ToString();
            var project = new Project();
            var model = new ProjectAddViewModel();
            Mock.Arrange(() => authMock.CurrentUserId).Returns(userId);
            Mock.Arrange(() => projectsServiceMock.Add(project, userId));

            // Act
            controller.AddProject(model);

            // Assert
            Mock.Assert(() => projectsServiceMock.Add(project, userId), Occurs.Once());
        }
    }
}
