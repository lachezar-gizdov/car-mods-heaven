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

            this.InitializeMapper();

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
            this.InitializeMapper();
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
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void ReturnErrorViewWhenPassedIdIsNull()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var authMock = Mock.Create<IAuthProvider>();
            this.InitializeMapper();
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

        //[TestMethod]
        //public void ReturnDetailsViewIfModelIsValid()
        //{
        //    // Arrange
        //    var projectsServiceMock = Mock.Create<IProjectsService>();
        //    var usersServiceMock = Mock.Create<IUsersService>();
        //    var authMock = Mock.Create<IAuthProvider>();

        //    this.ProjectToProjectDetailsViewModel();

        //    var projectId = Guid.NewGuid();
        //    var project = new Project
        //    {
        //        Id = projectId
        //    };

        //    var model = new ProjectDetailsViewModel();
        //    var controller = new ProjectsController(projectsServiceMock, usersServiceMock, authMock);
        //    var list = new List<Project>() { project };
        //    Mock.Arrange(() => projectsServiceMock.GetById(projectId)).Returns(list.AsQueryable());

        //    // Act
        //    controller.EditProject(model);

        //    //Assert
        //    controller
        //        .WithCallTo(c => c.EditProject(model))
        //        .ShouldRenderView("Details");
        //}

        //        [TestMethod]
        //        public void ReturnSameView_WhenModelIsNotValid()
        //        {
        //            // Arrange
        //            var projectsServiceMock = Mock.Create<IProjectsService>();
        //            var usersServiceMock = Mock.Create<IUsersService>();
        //            var authMock = Mock.Create<IAuthProvider>();
        //            var model = new ProjectDetailsViewModel();
        //            var controller = new ProjectsController(projectsServiceMock, usersServiceMock, authMock);

        //            // Act
        //            controller.ModelState.AddModelError("key", "message");
        //;
        //            // Assert
        //            controller
        //                .WithCallTo(c => c.EditProject(model))
        //                .ShouldRenderDefaultView();
        //        }

        //[TestMethod]
        //public void CallProjectsServiceMethodEditWhenModelIsValid()
        //{
        //    // Arrange
        //    var projectsServiceMock = Mock.Create<IProjectsService>();
        //    var usersServiceMock = Mock.Create<IUsersService>();
        //    var authMock = Mock.Create<IAuthProvider>();
        //    //this.InitializeMapper();
        //    var projectId = Guid.NewGuid();
        //    var userId = Guid.NewGuid();
        //    var project = new Project
        //    {
        //        Id = projectId
        //    };
        //    var model = new ProjectAddViewModel();

        //    var controller = new ProjectsController(projectsServiceMock, usersServiceMock, authMock);
        //    Mock.Arrange(() => projectsServiceMock.Update(project));

        //    // Act
        //    controller.EditProject(projectId);

        //    // Assert
        //    Mock.Assert(() => projectsServiceMock.Update(project), Occurs.Once());
        //}

        private void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
                    cfg.CreateMap<Project, ProjectDetailsViewModel>()
                        .ForMember(project => project.Id,
                            opt => opt.MapFrom(viewModel => viewModel.Id))
            );
        }

        private void ProjectToProjectDetailsViewModel()
        {
            Mapper.Initialize(cfg =>
                    cfg.CreateMap<Project, ProjectDetailsViewModel>()
                        .ForMember(viewModel => viewModel.Title,
                            opt => opt.MapFrom(project => project.Title)));
        }
    }
}
