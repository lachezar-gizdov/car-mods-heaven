using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.JustMock;

namespace CarModsHeaven.Services.Tests.ProjectsServiceTests
{
    [TestClass]
    public class AddShould
    {
        [TestMethod]
        public void ThrowWhenNullIsPassedAsProject()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var service = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var userId = Guid.NewGuid().ToString();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => service.Add(null, userId));
        }

        [TestMethod]
        public void CallRepositoryAddMethod()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var service = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var userId = Guid.NewGuid().ToString();
            var project = new Project();
            var user = new User() { Id = userId, Projects = new List<Project>() };
            var list = new List<User>() { user };
            Mock.Arrange(() => usersServiceMock.GetUserById(userId)).Returns(list.AsQueryable);

            // Act
            service.Add(project, userId);

            // Assert
            Mock.Assert(() => projectsRepoMock.Add(project), Occurs.Once());
        }

        [TestMethod]
        public void CallDbContextSaveChangesMethod()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var service = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var userId = Guid.NewGuid().ToString();
            var project = new Project();
            var user = new User() { Id = userId, Projects = new List<Project>() };
            var list = new List<User>() { user };
            Mock.Arrange(() => usersServiceMock.GetUserById(userId)).Returns(list.AsQueryable);

            // Act
            service.Add(project, userId);

            // Assert
            Mock.Assert(() => contextMock.SaveChanges(), Occurs.Once());
        }
    }
}
