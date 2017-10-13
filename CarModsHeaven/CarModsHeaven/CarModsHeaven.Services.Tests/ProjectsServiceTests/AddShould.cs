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
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var userId = Guid.NewGuid();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.Add(null, userId));
        }

        [TestMethod]
        public void ThrowWhenNullIsPassedAsUserId()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var project = Mock.Create<Project>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.Add(project, null));
        }

        [TestMethod]
        public void CallRepositoryAddMethod()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var userId = Guid.NewGuid();
            var project = Mock.Create<Project>();

            // Act
            sut.Add(project, userId);

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
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var projectMock = Mock.Create<Project>();
            var userId = Guid.NewGuid();

            // Act
            sut.Add(projectMock, userId);

            // Assert
            Mock.Assert(() => contextMock.SaveChanges(), Occurs.Once());
        }
    }
}
