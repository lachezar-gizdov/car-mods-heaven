using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace CarModsHeaven.Services.Tests.UsersServiceTests
{
    [TestClass]
    public class GetAllShould
    {
        [TestMethod]
        public void CallUsersRepoGetAllMethod()
        {
            // Arrange
            var usersRepoMock = Mock.Create<IEfRepository<User>>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new UsersService(usersRepoMock, contextMock);

            // Act
            sut.GetAll();

            // Assert
            Mock.Assert(() => usersRepoMock.AllVisible, Occurs.Once());
        }
    }
}
