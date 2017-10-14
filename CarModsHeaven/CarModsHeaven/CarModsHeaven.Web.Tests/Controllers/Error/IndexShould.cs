using CarModsHeaven.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace CarModsHeaven.Web.Tests.Controllers.Error
{
    [TestClass]
    public class IndexShould
    {
        [TestMethod]
        public void IndexShouldReturnView()
        {
            // Arrange
            var controller = new DiscussionsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
