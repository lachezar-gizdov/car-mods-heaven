using AutoMapper;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Controllers;
using CarModsHeaven.Web.Models.ProjectsList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Telerik.JustMock;
using TestStack.FluentMVCTesting;

namespace CarModsHeaven.Web.Tests.Controllers.Projects
{
    [TestClass]
    public class DetailsShould
    {
        private void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
                    cfg.CreateMap<Project, ProjectViewModel>()
                        .ForMember(viewModel => viewModel.CarBrand,
                            opt => opt.MapFrom(project => project.CarBrand))
            );
        }

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
            var projectTitle = "test";

            // Act
            var controller = new ProjectsController(projectsServiceMock, usersServiceMock);

            // Assert
            controller
                .WithCallTo(c => c.Details(projectTitle))
                .ShouldRenderView("Error");
        }

        //[TestMethod]
        //public void RenderDefaultView()
        //{
        //    // Arrange
        //    var projectsServiceMock = Mock.Create<IProjectsService>();
        //    var usersServiceMock = Mock.Create<IUsersService>();
        //    this.InitializeMapper();
        //    var projectTitle = "test";
        //    var project = new Project
        //    {
        //        Title = projectTitle
        //    };

        //    var controller = new ProjectsController(projectsServiceMock, usersServiceMock);
        //    Mock.ArrangeSet(() => projectsServiceMock.);

        //    //Assert
        //    controller
        //        .WithCallTo(c => c.Index(null))
        //        .ShouldRenderDefaultView();
        //}
    }
}
