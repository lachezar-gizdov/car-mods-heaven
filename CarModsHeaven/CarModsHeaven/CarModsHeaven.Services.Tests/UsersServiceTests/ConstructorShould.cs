using CarModsHeaven.Data.Contracts;
using CarModsHeaven.Data.Models;
using CarModsHeaven.Data.Repositories.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Telerik.JustMock;

namespace CarModsHeaven.Services.Tests.UsersServiceTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void ThrowWhenUsersRepositoryIsNull()
        {
            // Arrange
            var contextMock = Mock.Create<IUnitOfWork>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UsersService(null, contextMock));
        }

        [TestMethod]
        public void ThrowWhenDbContextIsNull()
        {
            // Arrange
            var usersRepoMock = Mock.Create<IEfRepository<User>>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UsersService(usersRepoMock, null));
        }
    }
}
