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
    public class DeleteShould
    {
        [TestInitialize]
        public void InitAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Project, ProjectDetailsViewModel>();
                cfg.CreateMap<ProjectDetailsViewModel, Project>();
            });
        }

        [TestMethod]
        public void ReturnErrorViewWhenProjectIsNotFound()
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
            var emptyList = new List<Project>();
            Mock.Arrange(() => projectsServiceMock.GetById(projectId)).Returns(emptyList.AsQueryable());

            // Act
            controller.DeleteProject(projectId);

            // Assert
            controller
                .WithCallTo(c => c.DeleteProject(projectId))
                .ShouldRenderView("Error");
        }

        [TestMethod]
        public void ReturnDefaultView()
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
            controller.DeleteProject(projectId);

            //Assert
            controller
                .WithCallTo(c => c.DeleteProject(projectId))
                .ShouldRedirectToRoute("");
        }

        [TestMethod]
        public void ReturnErrorViewWhenPassedIdIsNull()
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
            controller.DeleteProject(projectId);

            //Assert
            controller
                .WithCallTo(c => c.DeleteProject((Guid?)null))
                .ShouldRenderView("Error");
        }

        [TestMethod]
        public void CallProjectsServiceMethodDeleteWhenModelIsValid()
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
            var list = new List<Project>() { project };

            var controller = new ProjectsController(projectsServiceMock, usersServiceMock, authMock);
            Mock.Arrange(() => projectsServiceMock.GetById(projectId)).Returns(list.AsQueryable);
            Mock.Arrange(() => projectsServiceMock.Delete(project));

            // Act
            controller.DeleteProject(projectId);

            // Assert
            Mock.Assert(() => projectsServiceMock.Delete(project), Occurs.Once());
        }
    }
}
