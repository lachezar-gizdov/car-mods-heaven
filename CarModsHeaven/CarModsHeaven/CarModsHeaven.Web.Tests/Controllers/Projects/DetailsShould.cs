﻿using AutoMapper;
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
    public class DetailsShould
    {
        [TestMethod]
        public void ReturnErrorViewWhenPassedTitleIsNullOrEmpty()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            this.InitializeMapper();

            // Act
            var controller = new ProjectsController(projectsServiceMock, usersServiceMock);

            // Assert
            controller
                .WithCallTo(c => c.Details(null))
                .ShouldRenderView("Error");
        }

        [TestMethod]
        public void ReturnErrorViewWhenProjectIsNotFound()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            this.InitializeMapper();
            var projectTitle = Guid.NewGuid();

            // Act
            var controller = new ProjectsController(projectsServiceMock, usersServiceMock);

            // Assert
            controller
                .WithCallTo(c => c.Details(projectTitle))
                .ShouldRenderView("Error");
        }

        [TestMethod]
        public void RenderDefaultViewWhenProjectIsFound()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            this.InitializeMapper();
            var projectId = Guid.NewGuid();
            var project = new Project
            {
                Id = projectId
            };

            var controller = new ProjectsController(projectsServiceMock, usersServiceMock);
            var list = new List<Project>() { project };
            Mock.Arrange(() => projectsServiceMock.GetById(projectId)).Returns(list.AsQueryable());

            // Act
            controller.Details(projectId);

            //Assert
            controller
                .WithCallTo(c => c.Details(projectId))
                .ShouldRenderDefaultView();
        }

        private void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
                    cfg.CreateMap<Project, ProjectViewModel>()
                        .ForMember(viewModel => viewModel.CarBrand,
                            opt => opt.MapFrom(project => project.CarBrand))
            );
        }
    }
}
