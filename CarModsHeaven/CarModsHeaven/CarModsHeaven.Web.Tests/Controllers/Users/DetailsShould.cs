using AutoMapper;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Web.Controllers;
using CarModsHeaven.Web.Models.UsersList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;
using TestStack.FluentMVCTesting;

namespace CarModsHeaven.Web.Tests.Controllers.Users
{
    [TestClass]
    public class DetailsShould
    {
        [TestMethod]
        public void ReturnErrorViewWhenPassedUserNameIsNullOrEmpty()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            this.InitializeMapper();

            // Act
            var controller = new UsersController(usersServiceMock, projectsServiceMock);

            // Assert
            controller
                .WithCallTo(c => c.Details(null))
                .ShouldRenderView("Error");
        }

        [TestMethod]
        public void ReturnErrorViewWhenUserIsNotFound()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            this.InitializeMapper();
            var userName = "test";

            // Act
            var controller = new UsersController(usersServiceMock, projectsServiceMock);

            // Assert
            controller
                .WithCallTo(c => c.Details(userName))
                .ShouldRenderView("Error");
        }

        [TestMethod]
        public void RenderDefaultViewWhenUserIsFound()
        {
            // Arrange
            var projectsServiceMock = Mock.Create<IProjectsService>();
            var usersServiceMock = Mock.Create<IUsersService>();
            this.InitializeMapper();
            var userId = Guid.NewGuid().ToString();
            var user = new User() { };

            var controller = new UsersController(usersServiceMock, projectsServiceMock);
            var list = new List<User>() { user };
            Mock.Arrange(() => usersServiceMock.GetUserById(userId)).Returns(list.AsQueryable());

            // Act
            controller.Details(userId);

            //Assert
            controller
                .WithCallTo(c => c.Details(userId))
                .ShouldRenderDefaultView();
        }

        private void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
                    cfg.CreateMap<User, UserViewModel>()
                        .ForMember(viewModel => viewModel.FullName,
                            opt => opt.MapFrom(user => user.FullName))
            );
        }
    }
}
