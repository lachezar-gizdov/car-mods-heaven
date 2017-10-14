using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace CarModsHeaven.Data.Tests.UnitOfWorkTests
{
    [TestClass]
    public class SaveChangesShould
    {
        [TestMethod]
        public void CallDbContextSaveChangesMethod()
        {
            // Arrange
            var mockedDbContext = Mock.Create<CarModsContext>();

            // Act
            var unitOfWork = new UnitOfWork(mockedDbContext);
            unitOfWork.SaveChanges();

            Mock.Assert(() => mockedDbContext.SaveChanges(), Occurs.Once());
        }
    }
}
