using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarModsHeaven.Data.Tests.UnitOfWork
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void ThrowArgumentNullExceptionWhenPassedDbContextIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new UnitOfWork(null));
        }
    }
}
