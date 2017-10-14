using CarModsHeaven.Data.Repositories;
using CarModsHeaven.Data.Tests.EfRepositoryTests.Fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Telerik.JustMock;

namespace CarModsHeaven.Data.Tests.UnitOfWorkTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedDbContextIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new UnitOfWork(null));
        }

        [TestMethod]
        public void DoesNotThrowWhenPassedDbContextIsNotNull()
        {
            // Arrange
            var mockedDbContext = Mock.Create<CarModsContext>();

            // Act
            var unitOfWork = new UnitOfWork(mockedDbContext);

            Assert.IsNotNull(unitOfWork);
        }

        [TestMethod]
        public void PassDbContextCorrectlyShouldInitializeCorrectly()
        {
            var mockedDbContext = Mock.Create<CarModsContext>();

            var repository = new EfRepostory<FakeEFRepository>(mockedDbContext);

            Assert.IsNotNull(repository);
        }
    }
}
