using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            var userId = Guid.NewGuid();

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
            var userId = Guid.NewGuid();
            var project = Mock.Create<Project>();

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
            var projectMock = Mock.Create<Project>();
            var userId = Guid.NewGuid();

            // Act
            service.Add(projectMock, userId);

            // Assert
            Mock.Assert(() => contextMock.SaveChanges(), Occurs.Once());
        }
    }
}
