using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using CarModsHeaven.Services.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Data.Contracts;

namespace CarModsHeaven.Services.Tests.ProjectsServiceTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void ThrowWhenProjectsRepositoryIsNull()
        {
            // Arrange
            var IUsersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ProjectsService(null, IUsersServiceMock, contextMock));
        }

        [TestMethod]
        public void ThrowWhenUsersServiceIsNull()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var contextMock = Mock.Create<IUnitOfWork>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ProjectsService(projectsRepoMock, null, contextMock));
        }

        [TestMethod]
        public void ThrowWhenDbContextIsNull()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var IUsersServiceMock = Mock.Create<IUsersService>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ProjectsService(projectsRepoMock, IUsersServiceMock, null));
        }
    }
}
