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
    public class DeleteShould
    {
        [TestMethod]
        public void ThrowWhenNullIsPassedAsProject()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.Delete(null));
        }

        [TestMethod]
        public void CallProjectsRepoDeleteMethod()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var projectMock = Mock.Create<Project>();

            // Act
            sut.Delete(projectMock);

            // Assert
            Mock.Assert(() => projectsRepoMock.Delete(projectMock), Occurs.Once());
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

            // Act
            sut.Delete(projectMock);

            // Assert
            Mock.Assert(() => contextMock.SaveChanges(), Occurs.Once());
        }
    }
}
