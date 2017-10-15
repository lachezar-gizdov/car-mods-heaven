using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using CarModsHeaven.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Telerik.JustMock;

namespace CarModsHeaven.Services.Tests.UsersServiceTests
{
    [TestClass]
    public class DeleteShould
    {
        [TestMethod]
        public void ThrowWhenNullIsPassedAsUser()
        {
            // Arrange
            var usersRepoMock = Mock.Create<IEfRepository<User>>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var service = new UsersService(usersRepoMock, contextMock);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => service.Delete(null));
        }

        [TestMethod]
        public void CallUsersRepoDeleteMethod()
        {
            // Arrange
            var usersRepoMock = Mock.Create<IEfRepository<User>>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var service = new UsersService(usersRepoMock, contextMock);
            var userMock = Mock.Create<User>();

            // Act
            service.Delete(userMock);

            // Assert
            Mock.Assert(() => usersRepoMock.Delete(userMock), Occurs.Once());
        }

        [TestMethod]
        public void CallDbContextSaveChangesMethod()
        {
            // Arrange
            var usersRepoMock = Mock.Create<IEfRepository<User>>();
            var contextMock = Mock.Create<IUnitOfWork>();
            var service = new UsersService(usersRepoMock, contextMock);
            var userMock = Mock.Create<User>();

            // Act
            service.Delete(userMock);

            // Assert
            Mock.Assert(() => contextMock.SaveChanges(), Occurs.Once());
        }
    }
}
