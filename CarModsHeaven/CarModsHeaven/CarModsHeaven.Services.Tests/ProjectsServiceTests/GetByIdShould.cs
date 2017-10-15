using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Telerik.JustMock;
using System.Linq;
using System;

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
            var service = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var projectId = Guid.NewGuid();
            var project = new Project() { Id = projectId };
            var list = new List<Project>() { project };
            Mock.Arrange(() => projectsRepoMock.AllVisible).Returns(list.AsQueryable);

            // Act
            service.GetById(projectId);

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
            var service = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var projectId = Guid.NewGuid();
            var project = new Project() { Id = projectId };
            var list = new List<Project>() { project };
            Mock.Arrange(() => projectsRepoMock.AllVisible).Returns(list.AsQueryable);

            // Act
            var result = service.GetById(projectId);

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
            var service = new ProjectsService(projectsRepoMock, usersServiceMock, contextMock);
            var projectId = Guid.NewGuid();
            var list = new List<Project>();
            Mock.Arrange(() => projectsRepoMock.AllVisible).Returns(list.AsQueryable);

            // Act
            var result = service.GetById(projectId);

            // Assert
            Assert.AreEqual(0, result.Count());
        }
    }
}
