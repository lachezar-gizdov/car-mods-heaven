using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace CarModsHeaven.Services.Tests.UsersServiceTests
{
    [TestClass]
    public class GetAllSortedShould
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
    }
}
