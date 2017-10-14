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
    public class GetAllShould
    {
        [TestMethod]
        public void CallProjectsRepoGetAllVisibleMethod()
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
    }
}
