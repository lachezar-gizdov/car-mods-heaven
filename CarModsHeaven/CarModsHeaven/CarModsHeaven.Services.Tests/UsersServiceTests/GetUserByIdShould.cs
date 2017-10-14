using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Telerik.JustMock;

namespace CarModsHeaven.Services.Tests.UsersServiceTests
{
    [TestClass]
    public class GetUserByIdShould
    {
        [TestMethod]
        public void CallUsersRepoGetAllVisible()
        {
            // Arrange
            var usersRepoMock = Mock.Create<IEfRepository<User>>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var sut = new UsersService(usersRepoMock, contextMock);
            var userId = Guid.NewGuid().ToString();

            // Act
            sut.GetUserById(userId);

            // Assert
            Mock.Assert(() => usersRepoMock.AllVisible, Occurs.Once());
        }
    }
}
