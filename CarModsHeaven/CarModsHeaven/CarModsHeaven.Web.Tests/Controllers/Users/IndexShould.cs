using AutoMapper;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Controllers;
using CarModsHeaven.Web.Models.ProjectsList;
using CarModsHeaven.Web.Models.UsersList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using TestStack.FluentMVCTesting;

namespace CarModsHeaven.Web.Tests.Controllers.Users
{
    [TestClass]
    public class IndexShould
    {
        [TestMethod]
        public void RenderDefaultView()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            this.InitializeMapper();

            // Act
            var controller = new UsersController(usersServiceMock, projectsServiceMock);

            //Assert
            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void CallUsersServiceMethodGetAll()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            this.InitializeMapper();

            // Act
            var controller = new UsersController(usersServiceMock, projectsServiceMock);
            controller.Index();

            // Assert
            Mock.Assert(() => usersServiceMock.GetAll(), Occurs.Once());
        }

        private void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
                    cfg.CreateMap<User, UserViewModel>()
                        .ForMember(viewModel => viewModel.,
                            opt => opt.MapFrom(user => user.))
            );
        }
    }
}
