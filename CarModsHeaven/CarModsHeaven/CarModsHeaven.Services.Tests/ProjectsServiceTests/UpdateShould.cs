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
    public class UpdateShould
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
            Assert.ThrowsException<ArgumentNullException>(() => sut.Update(null));
        }

        [TestMethod]
        public void CallProjectsRepoUpdateMethod()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var projectMock = Mock.Create<Project>();

            // Act
            sut.Update(projectMock);

            // Assert
            Mock.Assert(() => projectsRepoMock.Update(projectMock), Occurs.Once());
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
            sut.Update(projectMock);

            // Assert
            Mock.Assert(() => contextMock.SaveChanges(), Occurs.Once());
        }
    }
}
