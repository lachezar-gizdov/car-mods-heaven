using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Telerik.JustMock;
using System.Linq;

namespace CarModsHeaven.Services.Tests.ProjectsServiceTests
{
    [TestClass]
    public class GetByIdShould
    {
        [TestMethod]
        public void CallProjectsRepoGetAllMethod()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);

            // Act
            sut.GetAll();

            // Assert
            Mock.Assert(() => projectsRepoMock.AllVisible, Occurs.Once());
        }

        [TestMethod]
        public void ReturnOneResultIfProjectIsFound()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var project = new Project();
            var list = new List<Project>() { project };
            Mock.Arrange(() => projectsRepoMock.AllVisible).Returns(list.AsQueryable);

            // Act
            var result = sut.GetAll();

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void NotReturnResultIfProjectIsNotFound()
        {
            // Arrange
            var projectsRepoMock = Mock.Create<IEfRepository<Project>>();
            var usersServiceMock = Mock.Create<IUsersService>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var list = new List<Project>();
            Mock.Arrange(() => projectsRepoMock.AllVisible).Returns(list.AsQueryable);

            // Act
            var result = sut.GetAll();

            // Assert
            Assert.AreEqual(0, result.Count());
        }
    }
}
