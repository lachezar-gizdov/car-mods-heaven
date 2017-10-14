using CarModsHeaven.Data.Repositories;
using CarModsHeaven.Data.Tests.EfRepositoryTests.Fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarModsHeaven.Data.Tests.EfRepositoryTests
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedDbContextIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new EfRepostory<FakeEFRepository>(null));
        }
    }
}
