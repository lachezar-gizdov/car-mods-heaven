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
    public class GetProjectsShould
    {
        [TestMethod]
        public void RenderDefaultView()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var authMock = Mock.Create<IAuthProvider>();
            this.InitializeMapper();

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
            this.InitializeMapper();

            // Act
            var controller = new ProjectsController(projectsServiceMock, usersServiceMock, authMock);
            controller.Index(null);

            // Assert
            Mock.Assert(() => projectsServiceMock.GetAll(), Occurs.Once());
        }

        private void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
                    cfg.CreateMap<Project, ProjectDetailsViewModel>()
                        .ForMember(viewModel => viewModel.CarBrand,
                            opt => opt.MapFrom(project => project.CarBrand))
            );
        }
    }
}
